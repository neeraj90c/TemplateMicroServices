using Common.DTO;
using Common.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ImageMaster.Command;
using ImageMaster.DTO;

namespace ImageMaster.Controllers
{
    public class ImageMasterController : BaseApiController
    {
        APISettings _settings;
        protected readonly IEncryptDecrypt _encryptDecrypt;
        private ILogger<ImageMasterController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ImageMasterController(IOptions<APISettings> settings, IEncryptDecrypt encryptDecrypt, IWebHostEnvironment webHostEnvironment, ILogger<ImageMasterController> logger)
        {
            _logger = logger;
            _settings = settings.Value;
            _encryptDecrypt = encryptDecrypt;
            _webHostEnvironment = webHostEnvironment;

            SessionObj.WebRootPath = _webHostEnvironment.WebRootPath;
        }
        [HttpGet("healthCheck")]
        public async Task<IActionResult> HealthCheck()
        {
            HealthCheckResponseDTO healthCheckResponseDTO = new HealthCheckResponseDTO();
            healthCheckResponseDTO.Key = "Image Master API";
            healthCheckResponseDTO.Value = "Running Successfully!!";
            return Ok(healthCheckResponseDTO);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ImageMasterCreateRequestDTO requestDTO)
        {

            ImageMasterDTO response = new ImageMasterDTO();
            response = await mediator.Send(new ImageMasterCreateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] ImageMasterUpdateRequestDTO requestDTO)
        {

            ImageMasterDTO response = new ImageMasterDTO();
            response = await mediator.Send(new ImageMasterUpdateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadById")]
        public async Task<IActionResult> ReadById([FromBody] ImageMasterReadByIdRequestDTO requestDTO)
        {

            ImageMasterDTO response = new ImageMasterDTO();
            response = await mediator.Send(new ImageMasterReadByIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadByMasterId")]
        public async Task<IActionResult> ReadByMasterId([FromBody] ImageMasterReadByMasterIdRequestDTO requestDTO)
        {

            ImageMasterList response = new ImageMasterList();
            response = await mediator.Send(new ImageMasterReadByMasterIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] ImageMasterDeleteRequestDTO requestDTO)
        {

            await mediator.Send(new ImageMasterDeleteCommand
            {
                reqDTO = requestDTO
            });

            return Ok();
        }
        [HttpGet("ReadAll")]
        public async Task<IActionResult> ReadAll()
        {
            //_logger.LogInformation("This is for Graylog Testing");
            ImageMasterList response = new ImageMasterList();
            response = await mediator.Send(new ImageMasterReadAllCommand
            {
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }

    }
}
