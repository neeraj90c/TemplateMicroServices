using BankMaster.Command;
using BankMaster.DTO;
using Common.DTO;
using Common.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BankMaster.Controllers
{
    public class BankMasterController : BaseApiController
    {
        APISettings _settings;
        protected readonly IEncryptDecrypt _encryptDecrypt;
        private ILogger<BankMasterController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BankMasterController(IOptions<APISettings> settings, IEncryptDecrypt encryptDecrypt, IWebHostEnvironment webHostEnvironment, ILogger<BankMasterController> logger)
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
            healthCheckResponseDTO.Key = "Bank Master API";
            healthCheckResponseDTO.Value = "Running Successfully!!";
            return Ok(healthCheckResponseDTO);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] BankMasterCreateRequestDTO requestDTO)
        {

            BankMasterDTO response = new BankMasterDTO();
            response = await mediator.Send(new BankMasterCreateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] BankMasterUpdateRequestDTO requestDTO)
        {

            BankMasterDTO response = new BankMasterDTO();
            response = await mediator.Send(new BankMasterUpdateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadById")]
        public async Task<IActionResult> ReadById([FromBody] BankMasterReadByIdRequestDTO requestDTO)
        {

            BankMasterDTO response = new BankMasterDTO();
            response = await mediator.Send(new BankMasterReadByIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] BankMasterDeleteRequestDTO requestDTO)
        {

            BankMasterDTO response = new BankMasterDTO();
            await mediator.Send(new BankMasterDeleteCommand
            {
                reqDTO = requestDTO
            });

            return Ok();
        }
        [HttpGet("ReadAll")]
        public async Task<IActionResult> ReadAll()
        {

            BankMasterList response = new BankMasterList();
            response = await mediator.Send(new BankMasterReadAllCommand
            {
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadAllPaginated")]
        public async Task<IActionResult> ReadAllPaginated([FromBody] PaginationDTO requestDTO)
        {

            BankMasterList response = new BankMasterList();
            response = await mediator.Send(new BankMasterReadAllPaginatedCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
    }
}
