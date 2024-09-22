using Common.DTO;
using Common.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using KitDetail.Command;
using KitDetail.DTO;

namespace KitDetail.Controllers
{
    public class KitDetailController : BaseApiController
    {
        APISettings _settings;
        protected readonly IEncryptDecrypt _encryptDecrypt;
        private ILogger<KitDetailController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public KitDetailController(IOptions<APISettings> settings, IEncryptDecrypt encryptDecrypt, IWebHostEnvironment webHostEnvironment, ILogger<KitDetailController> logger)
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
            healthCheckResponseDTO.Key = "Kit Detail API";
            healthCheckResponseDTO.Value = "Running Successfully!!";
            return Ok(healthCheckResponseDTO);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] KitDetailCreateRequestDTO requestDTO)
        {

            KitDetailDTO response = new KitDetailDTO();
            response = await mediator.Send(new KitDetailCreateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] KitDetailUpdateRequestDTO requestDTO)
        {

            KitDetailDTO response = new KitDetailDTO();
            response = await mediator.Send(new KitDetailUpdateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadById")]
        public async Task<IActionResult> ReadById([FromBody] KitDetailReadByIdRequestDTO requestDTO)
        {

            KitDetailDTO response = new KitDetailDTO();
            response = await mediator.Send(new KitDetailReadByIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadByKitId")]
        public async Task<IActionResult> ReadByKitId([FromBody] KitDetailReadByKitIdRequestDTO requestDTO)
        {

            KitDetailDTO response = new KitDetailDTO();
            response = await mediator.Send(new KitDetailReadByKitIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] KitDetailDeleteRequestDTO requestDTO)
        {

            await mediator.Send(new KitDetailDeleteCommand
            {
                reqDTO = requestDTO
            });

            return Ok();
        }
        [HttpGet("ReadAll")]
        public async Task<IActionResult> ReadAll()
        {
            //_logger.LogInformation("This is for Graylog Testing");
            KitDetailList response = new KitDetailList();
            response = await mediator.Send(new KitDetailReadAllCommand
            {
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }

    }
}
