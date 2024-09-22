using Common.DTO;
using Common.Interface;
using CompanyBankAccount.Command;
using CompanyBankAccount.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CompanyBankAccount.Controllers
{
    public class CompanyBankAccountController : BaseApiController
    {
        APISettings _settings;
        protected readonly IEncryptDecrypt _encryptDecrypt;
        private ILogger<CompanyBankAccountController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CompanyBankAccountController(IOptions<APISettings> settings, IEncryptDecrypt encryptDecrypt, IWebHostEnvironment webHostEnvironment, ILogger<CompanyBankAccountController> logger)
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
            healthCheckResponseDTO.Key = "Company Bank Account API";
            healthCheckResponseDTO.Value = "Running Successfully!!";
            return Ok(healthCheckResponseDTO);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CompanyBankAccountCreateRequestDTO requestDTO)
        {

            CompanyBankAccountDTO response = new CompanyBankAccountDTO();
            response = await mediator.Send(new CompanyBankAccountCreateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] CompanyBankAccountUpdateRequestDTO requestDTO)
        {

            CompanyBankAccountDTO response = new CompanyBankAccountDTO();
            response = await mediator.Send(new CompanyBankAccountUpdateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadById")]
        public async Task<IActionResult> ReadById([FromBody] CompanyBankAccountReadByIdRequestDTO requestDTO)
        {

            CompanyBankAccountDTO response = new CompanyBankAccountDTO();
            response = await mediator.Send(new CompanyBankAccountReadByIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] CompanyBankAccountDeleteRequestDTO requestDTO)
        {

            CompanyBankAccountDTO response = new CompanyBankAccountDTO();
            await mediator.Send(new CompanyBankAccountDeleteCommand
            {
                reqDTO = requestDTO
            });

            return Ok();
        }
        [HttpGet("ReadAll")]
        public async Task<IActionResult> ReadAll()
        {

            CompanyBankAccountList response = new CompanyBankAccountList();
            response = await mediator.Send(new CompanyBankAccountReadAllCommand
            {
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadByBankId")]
        public async Task<IActionResult> ReadByBankId([FromBody] CompanyBankAccountReadByBankIdRequestDTO requestDTO)
        {

            CompanyBankAccountList response = new CompanyBankAccountList();
            response = await mediator.Send(new CompanyBankAccountReadByBankIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadByCompanyId")]
        public async Task<IActionResult> ReadByCompanyId([FromBody] CompanyBankAccountReadByCompanyIdRequestDTO requestDTO)
        {

            CompanyBankAccountList response = new CompanyBankAccountList();
            response = await mediator.Send(new CompanyBankAccountReadByCompanyIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
    }
}
