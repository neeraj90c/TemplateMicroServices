using Common.DTO;
using Common.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PackagingMaster.Command;
using PackagingMaster.DTO;

namespace PackagingMaster.Controllers
{
    public class PackagingMasterController : BaseApiController
    {
        APISettings _settings;
        protected readonly IEncryptDecrypt _encryptDecrypt;
        private ILogger<PackagingMasterController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PackagingMasterController(IOptions<APISettings> settings, IEncryptDecrypt encryptDecrypt, IWebHostEnvironment webHostEnvironment, ILogger<PackagingMasterController> logger)
        {
            _logger = logger;
            _settings = settings.Value;
            _encryptDecrypt = encryptDecrypt;
            _webHostEnvironment = webHostEnvironment;

            SessionObj.WebRootPath = _webHostEnvironment.ContentRootPath;
        }
        [HttpGet("healthCheck")]
        public async Task<IActionResult> HealthCheck()
        {
            HealthCheckResponseDTO healthCheckResponseDTO = new HealthCheckResponseDTO();
            healthCheckResponseDTO.Key = "Kit Master API";
            healthCheckResponseDTO.Value = "Running Successfully!!";
            return Ok(healthCheckResponseDTO);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] PackagingMasterCreateRequestDTO requestDTO)
        {

            PackagingMasterDTO response = new PackagingMasterDTO();
            response = await mediator.Send(new PackagingMasterCreateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] PackagingMasterUpdateRequestDTO requestDTO)
        {

            PackagingMasterDTO response = new PackagingMasterDTO();
            response = await mediator.Send(new PackagingMasterUpdateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadById")]
        public async Task<IActionResult> ReadById([FromBody] PackagingMasterReadByIdRequestDTO requestDTO)
        {

            PackagingMasterDTO response = new PackagingMasterDTO();
            response = await mediator.Send(new PackagingMasterReadByIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] PackagingMasterDeleteRequestDTO requestDTO)
        {

            await mediator.Send(new PackagingMasterDeleteCommand
            {
                reqDTO = requestDTO
            });

            return Ok();
        }
        [HttpGet("ReadAll")]
        public async Task<IActionResult> ReadAll()
        {
            //_logger.LogInformation("This is for Graylog Testing");
            PackagingMasterList response = new PackagingMasterList();
            response = await mediator.Send(new PackagingMasterReadAllCommand
            {
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }

        [HttpPost("ReadAllPaginated")]
        public async Task<IActionResult> ReadAllPaginated([FromBody] PackagingMasterReadAllPaginatedRequestDTO requestDTO)
        {

            PackagingMasterList response = new PackagingMasterList();
            response = await mediator.Send(new PackagingMasterReadAllPaginatedCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }

    }
}
