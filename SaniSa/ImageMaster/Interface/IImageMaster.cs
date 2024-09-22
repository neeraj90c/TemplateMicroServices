using Common.DTO;
using ImageMaster.DTO;

namespace ImageMaster.Interface
{
    public interface IImageMaster
    {
        Task<ImageMasterDTO> Create(ImageMasterCreateRequestDTO reqDTO);
        Task<ImageMasterDTO> Update(ImageMasterUpdateRequestDTO reqDTO);
        Task Delete(ImageMasterDeleteRequestDTO reqDTO);
        Task<ImageMasterDTO> ReadById(ImageMasterReadByIdRequestDTO reqDTO);
        Task<ImageMasterDTO> ReadByMasterId(ImageMasterReadByMasterIdRequestDTO reqDTO);
        Task<ImageMasterList> ReadAll();
    }
}
