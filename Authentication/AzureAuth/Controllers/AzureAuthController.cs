using AzureAuth.Command;
using AzureAuth.DTO;
using Common.DTO;
using Common.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AzureAuth.Controllers
{
    public class AzureAuthController : BaseApiController
    {
        APISettings _settings;
        protected readonly IEncryptDecrypt _encryptDecrypt;
        private ILogger<AzureAuthController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AzureAuthController(IOptions<APISettings> settings, IEncryptDecrypt encryptDecrypt, IWebHostEnvironment webHostEnvironment, ILogger<AzureAuthController> logger)
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
            healthCheckResponseDTO.Key = "Azure Auth API";
            healthCheckResponseDTO.Value = "Running Successfully!!";
            return Ok(healthCheckResponseDTO);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] AzureAuthCreateRequestDTO requestDTO)
        {

            AzureAuthDTO response = new AzureAuthDTO();
            response = await mediator.Send(new AzureAuthCreateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] AzureAuthUpdateRequestDTO requestDTO)
        {

            AzureAuthDTO response = new AzureAuthDTO();
            response = await mediator.Send(new AzureAuthUpdateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadById")]
        public async Task<IActionResult> ReadById([FromBody] AzureAuthReadByIdRequestDTO requestDTO)
        {

            AzureAuthDTO response = new AzureAuthDTO();
            response = await mediator.Send(new AzureAuthReadByIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadByAzureUUId")]
        public async Task<IActionResult> ReadByAzureUUId([FromBody] AzureAuthReadByAzureUUIdRequestDTO requestDTO)
        {

            AzureAuthDTO response = new AzureAuthDTO();
            response = await mediator.Send(new AzureAuthReadByAzureUUIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check AzureUUID"));

            return Ok(response);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] AzureAuthDeleteRequestDTO requestDTO)
        {

            await mediator.Send(new AzureAuthDeleteCommand
            {
                reqDTO = requestDTO
            });

            return Ok();
        }
        [HttpGet("ReadAll")]
        public async Task<IActionResult> ReadAll()
        {

            AzureAuthList response = new AzureAuthList();
            response = await mediator.Send(new AzureAuthReadAllCommand
            {
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
    }
}
