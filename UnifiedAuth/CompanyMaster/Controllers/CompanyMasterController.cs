using Common.DTO;
using Common.Interface;
using CompanyMaster.Command;
using CompanyMaster.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CompanyMaster.Controllers
{
    public class CompanyMasterController : BaseApiController
    {
        APISettings _settings;
        protected readonly IEncryptDecrypt _encryptDecrypt;
        private ILogger<CompanyMasterController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CompanyMasterController(IOptions<APISettings> settings, IEncryptDecrypt encryptDecrypt, IWebHostEnvironment webHostEnvironment, ILogger<CompanyMasterController> logger)
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
            healthCheckResponseDTO.Key = "Company Master API";
            healthCheckResponseDTO.Value = "Running Successfully!!";
            return Ok(healthCheckResponseDTO);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CompanyMasterCreateRequestDTO requestDTO)
        {
            CompanyMasterDTO response = new CompanyMasterDTO();
            response = await mediator.Send(new CompanyMasterCreateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] CompanyMasterUpdateRequestDTO requestDTO)
        {
            CompanyMasterDTO response = new CompanyMasterDTO();
            response = await mediator.Send(new CompanyMasterUpdateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadById")]
        public async Task<IActionResult> ReadById([FromBody] CompanyMasterReadByIdRequestDTO requestDTO)
        {

            CompanyMasterDTO response = new CompanyMasterDTO();
            response = await mediator.Send(new CompanyMasterReadByIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] CompanyMasterDeleteRequestDTO requestDTO)
        {

            await mediator.Send(new CompanyMasterDeleteCommand
            {
                reqDTO = requestDTO
            });

            return Ok();
        }
        [HttpGet("ReadAll")]
        public async Task<IActionResult> ReadAll()
        {

            CompanyMasterList response = new CompanyMasterList();
            response = await mediator.Send(new CompanyMasterReadAllCommand
            {
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
    }
}
