using Common.Service;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;
using ImageMaster.DTO;
using Dapper;
using ImageMaster.Interface;
using Common.DTO;
using Microsoft.AspNetCore.Server.IISIntegration;
using static Dapper.SqlMapper;


namespace ImageMaster.Service
{
    public class ImageMasterService : DABase, IImageMaster
    {
        APISettings _settings;
        private const string SP_ImageMaster_Create = "ImageMaster_Create";
        private const string SP_ImageMaster_Delete = "ImageMaster_Delete";
        private const string SP_ImageMaster_ReadAll = "ImageMaster_ReadAll";
        private const string SP_ImageMaster_ReadById = "ImageMaster_ReadById";
        private const string SP_ImageMaster_ReadByMasterId = "ImageMaster_ReadByMasterId";
        private const string SP_ImageMaster_Update = "ImageMaster_Update";
        private readonly string _WebRootPath;
        private ILogger<ImageMasterService> _logger;
        public ImageMasterService(IOptions<ConnectionSettings> connectionSettings, ILogger<ImageMasterService> logger, IOptions<APISettings> settings) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
            _settings = settings.Value;
            _WebRootPath = SessionObj.WebRootPath;
        }
        //public async Task<ImageMasterDTO> Create(ImageMasterCreateRequestDTO reqDTO)
        //{

        //    ImageMasterDTO retObj = null;


        //    var filename = (DateTime.Now).Ticks;
        //    var filepath = " ";
        //    //Save the file
        //    if (!System.String.IsNullOrEmpty(reqDTO.IURL) && reqDTO.IURL.Trim() != "")
        //    {
        //        var fileName = _settings.ImageUploadPath + "\\" + filename;

        //        filepath = Utilities.SaveFileFromBase64(SessionObj.WebRootPath, fileName, reqDTO.IURL);
        //    }
        //    else
        //    {
        //        filepath = reqDTO.IURL;
        //    }



        //    _logger.LogInformation($"Started Item Images Create for MasterId: {reqDTO.MasterId}, ImageName: {reqDTO.IName}");

        //    try
        //    {
        //        // Save the image and get the URL


        //        using (SqlConnection connection = new SqlConnection(ConnectionString))
        //        {
        //            retObj = await connection.QuerySingleAsync<ImageMasterDTO>(SP_ImageMaster_Create, new
        //            {
        //                MasterId = reqDTO.MasterId,
        //                MasterType = reqDTO.MasterType,
        //                IName = reqDTO.IName,
        //                IType = reqDTO.IType,
        //                IURL = filepath,
        //                IsDefault = reqDTO.IsDefault,
        //                ActionUser = reqDTO.ActionUser,
        //            }, commandType: CommandType.StoredProcedure);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error occurred while creating image.");
        //        throw;  // Optionally re-throw or handle as needed
        //    }

        //    return retObj;
        //}

        public async Task<ImageMasterDTO> Create(ImageMasterCreateRequestDTO reqDTO)
        {
            ImageMasterDTO retObj = null;
            FileSaveResponse filepath = new FileSaveResponse();

            // Generate a filename based on current timestamp
            var filename = DateTime.Now.Ticks.ToString().ToString();
            var uploadPath = _settings.ImageUploadPath;

            // Save the file
            if (!string.IsNullOrWhiteSpace(reqDTO.IURL))
            {
                
                filepath = await Utilities.SaveFileFromBase64Async(uploadPath, filename, reqDTO.IURL);
            }
            else
            {
                filepath.filePath = reqDTO.IURL;
            }

            _logger.LogInformation($"Started Item Images Create for MasterId: {reqDTO.MasterId}, ImageName: {reqDTO.IName}");

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    retObj = await connection.QuerySingleAsync<ImageMasterDTO>(SP_ImageMaster_Create, new
                    {
                        MasterId = reqDTO.MasterId,
                        MasterType = reqDTO.MasterType,
                        IName = filepath.fileName,
                        IType = reqDTO.IType,
                        IURL = filepath.filePath,
                        IsDefault = reqDTO.IsDefault,
                        ActionUser = reqDTO.ActionUser,
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException sqlEx)
            {
                _logger.LogError(sqlEx, "SQL error occurred while creating image.");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating image.");
                throw;
            }

            return retObj;
        }

        public async Task<ImageMasterDTO> Update(ImageMasterUpdateRequestDTO reqDTO)
        {

            ImageMasterDTO retObj = null;
            _logger.LogInformation($"Started Item Images Update {reqDTO.ImageId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<ImageMasterDTO>(SP_ImageMaster_Update, new
                {
                    ImageId = reqDTO.ImageId,
                    MasterId = reqDTO.MasterId,
                    MasterType = reqDTO.MasterType,
                    IName = reqDTO.IName,
                    IType = reqDTO.IType,
                    IURL = reqDTO.IURL,
                    IsDefault = reqDTO.IsDefault,
                    IsActive = reqDTO.IsActive,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task Delete(ImageMasterDeleteRequestDTO reqDTO)
        {

            _logger.LogInformation($"Started Item Images Delete {reqDTO.ImageId} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(SP_ImageMaster_Delete, new
                {
                    ImageId = reqDTO.ImageId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }
            //return Task.CompletedTask;
        }
        public async Task<ImageMasterDTO> ReadById(ImageMasterReadByIdRequestDTO reqDTO)
        {

            ImageMasterDTO retObj = null;
            _logger.LogInformation($"Started Item Images ReadById {reqDTO.ImageId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<ImageMasterDTO>(SP_ImageMaster_ReadById, new
                {
                    ImageId = reqDTO.ImageId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }

        public async Task<ImageMasterList> ReadByMasterId(ImageMasterReadByMasterIdRequestDTO reqDTO)
        {

            ImageMasterList retObj = new ImageMasterList();
            _logger.LogInformation($"Started Item Images ReadById {reqDTO.MasterId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<ImageMasterDTO>(SP_ImageMaster_ReadByMasterId, new
                {
                    MasterId = reqDTO.MasterId,
                    MasterType = reqDTO.MasterType
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }

        public async Task<ImageMasterList> ReadAll()
        {

            ImageMasterList retObj = new ImageMasterList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<ImageMasterDTO>(SP_ImageMaster_ReadAll, new
                {

                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }

        private async Task<string> SaveImageAsync(string base64Image, string imageName)
        {
            if (string.IsNullOrEmpty(base64Image))
            {
                throw new ArgumentException("Base64 image data cannot be null or empty", nameof(base64Image));
            }

            // Remove the header part if present (e.g., "data:image/png;base64,")
            var base64Data = base64Image.Substring(base64Image.IndexOf(',') + 1);
            var imageBytes = Convert.FromBase64String(base64Data);

            // Generate a unique filename if imageName is not provided
            var fileName = string.IsNullOrEmpty(imageName) ? $"{Guid.NewGuid()}.png" : imageName;
            var filePath = Path.Combine(_settings.UploadPath, fileName);

            // Save image to disk
            await File.WriteAllBytesAsync(filePath, imageBytes);

            // Return URL to access the image
            return $"/Client/Images/{fileName}";
        }

    }
}
