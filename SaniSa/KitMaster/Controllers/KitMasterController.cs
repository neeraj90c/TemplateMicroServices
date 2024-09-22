using Common.DTO;
using Common.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using KitMaster.Command;
using KitMaster.DTO;

namespace KitMaster.Controllers
{
    public class KitMasterController : BaseApiController
    {
        APISettings _settings;
        protected readonly IEncryptDecrypt _encryptDecrypt;
        private ILogger<KitMasterController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public KitMasterController(IOptions<APISettings> settings, IEncryptDecrypt encryptDecrypt, IWebHostEnvironment webHostEnvironment, ILogger<KitMasterController> logger)
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
        public async Task<IActionResult> Create([FromBody] KitMasterCreateRequestDTO requestDTO)
        {

            KitMasterDTO response = new KitMasterDTO();
            response = await mediator.Send(new KitMasterCreateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] KitMasterUpdateRequestDTO requestDTO)
        {

            KitMasterDTO response = new KitMasterDTO();
            response = await mediator.Send(new KitMasterUpdateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadById")]
        public async Task<IActionResult> ReadById([FromBody] KitMasterReadByIdRequestDTO requestDTO)
        {

            KitMasterDTO response = new KitMasterDTO();
            response = await mediator.Send(new KitMasterReadByIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] KitMasterDeleteRequestDTO requestDTO)
        {

            await mediator.Send(new KitMasterDeleteCommand
            {
                reqDTO = requestDTO
            });

            return Ok();
        }
        [HttpGet("ReadAll")]
        public async Task<IActionResult> ReadAll()
        {
            //_logger.LogInformation("This is for Graylog Testing");
            KitMasterList response = new KitMasterList();
            response = await mediator.Send(new KitMasterReadAllCommand
            {
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }

        [HttpPost("ReadAllPaginated")]
        public async Task<IActionResult> ReadAllPaginated([FromBody] KitMasterReadAllPaginatedRequestDTO requestDTO)
        {

            KitMasterList response = new KitMasterList();
            response = await mediator.Send(new KitMasterReadAllPaginatedCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }

    }
}
