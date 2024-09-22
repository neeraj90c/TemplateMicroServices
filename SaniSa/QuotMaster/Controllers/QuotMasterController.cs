using Common.DTO;
using Common.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using QuotMaster.Command;
using QuotMaster.DTO;

namespace QuotMaster.Controllers
{
    public class QuotMasterController : BaseApiController
    {
        APISettings _settings;
        protected readonly IEncryptDecrypt _encryptDecrypt;
        private ILogger<QuotMasterController> _logger;

        public QuotMasterController(IOptions<APISettings> settings, IEncryptDecrypt encryptDecrypt, ILogger<QuotMasterController> logger)
        {
            _logger = logger;
            _settings = settings.Value;
            _encryptDecrypt = encryptDecrypt;

        }
        [HttpGet("healthCheck")]
        public async Task<IActionResult> HealthCheck()
        {
            HealthCheckResponseDTO healthCheckResponseDTO = new HealthCheckResponseDTO();
            healthCheckResponseDTO.Key = "Quot Master API";
            healthCheckResponseDTO.Value = "Running Successfully!!";
            return Ok(healthCheckResponseDTO);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] QuotMasterCreateRequestDTO requestDTO)
        {

            QuotMasterDTO response = new QuotMasterDTO();
            response = await mediator.Send(new QuotMasterCreateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] QuotMasterUpdateRequestDTO requestDTO)
        {

            QuotMasterDTO response = new QuotMasterDTO();
            response = await mediator.Send(new QuotMasterUpdateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadById")]
        public async Task<IActionResult> ReadById([FromBody] QuotMasterReadByIdRequestDTO requestDTO)
        {

            QuotMasterDTO response = new QuotMasterDTO();
            response = await mediator.Send(new QuotMasterReadByIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] QuotMasterDeleteRequestDTO requestDTO)
        {

            await mediator.Send(new QuotMasterDeleteCommand
            {
                reqDTO = requestDTO
            });

            return Ok();
        }
        [HttpGet("ReadAll")]
        public async Task<IActionResult> ReadAll()
        {
            //_logger.LogInformation("This is for Graylog Testing");
            QuotMasterList response = new QuotMasterList();
            response = await mediator.Send(new QuotMasterReadAllCommand
            {
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }

        [HttpPost("ReadAllPaginated")]
        public async Task<IActionResult> ReadAllPaginated([FromBody] QuotMasterReadAllPaginatedRequestDTO requestDTO)
        {

            QuotMasterList response = new QuotMasterList();
            response = await mediator.Send(new QuotMasterReadAllPaginatedCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }

    }
}
