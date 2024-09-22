using Common.DTO;
using Common.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ComboDetail.Command;
using ComboDetail.DTO;

namespace ComboDetail.Controllers
{
    public class ComboDetailController : BaseApiController
    {
        APISettings _settings;
        protected readonly IEncryptDecrypt _encryptDecrypt;
        private ILogger<ComboDetailController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ComboDetailController(IOptions<APISettings> settings, IEncryptDecrypt encryptDecrypt, IWebHostEnvironment webHostEnvironment, ILogger<ComboDetailController> logger)
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
            healthCheckResponseDTO.Key = "Combo Detail API";
            healthCheckResponseDTO.Value = "Running Successfully!!";
            return Ok(healthCheckResponseDTO);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ComboDetailCreateRequestDTO requestDTO)
        {

            ComboDetailDTO response = new ComboDetailDTO();
            response = await mediator.Send(new ComboDetailCreateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadByItemId")]
        public async Task<IActionResult> ReadByItemId([FromBody] ComboDetailReadByItemIdRequestDTO requestDTO)
        {

            ComboDetailDTO response = new ComboDetailDTO();
            response = await mediator.Send(new ComboDetailReadByItemIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadById")]
        public async Task<IActionResult> ReadById([FromBody] ComboDetailReadByIdRequestDTO requestDTO)
        {

            ComboDetailDTO response = new ComboDetailDTO();
            response = await mediator.Send(new ComboDetailReadByIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadByComboId")]
        public async Task<IActionResult> ReadByComboId([FromBody] ComboDetailReadByComboIdRequestDTO requestDTO)
        {

            ComboDetailDTO response = new ComboDetailDTO();
            response = await mediator.Send(new ComboDetailReadByComboIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] ComboDetailDeleteRequestDTO requestDTO)
        {

            await mediator.Send(new ComboDetailDeleteCommand
            {
                reqDTO = requestDTO
            });

            return Ok();
        }
        [HttpGet("ReadAll")]
        public async Task<IActionResult> ReadAll()
        {
            //_logger.LogInformation("This is for Graylog Testing");
            ComboDetailList response = new ComboDetailList();
            response = await mediator.Send(new ComboDetailReadAllCommand
            {
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }

    }
}
