using Common.DTO;
using Common.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using QuoteDetail.Command;
using QuoteDetail.DTO;

namespace QuoteDetail.Controllers
{
    public class QuoteDetailController : BaseApiController
    {
        APISettings _settings;
        protected readonly IEncryptDecrypt _encryptDecrypt;
        private ILogger<QuoteDetailController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public QuoteDetailController(IOptions<APISettings> settings, IEncryptDecrypt encryptDecrypt, IWebHostEnvironment webHostEnvironment, ILogger<QuoteDetailController> logger)
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
            healthCheckResponseDTO.Key = "Quote Detail API";
            healthCheckResponseDTO.Value = "Running Successfully!!";
            return Ok(healthCheckResponseDTO);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] QuoteDetailCreateRequestDTO requestDTO)
        {

            QuoteDetailDTO response = new QuoteDetailDTO();
            response = await mediator.Send(new QuoteDetailCreateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] QuoteDetailUpdateRequestDTO requestDTO)
        {

            QuoteDetailDTO response = new QuoteDetailDTO();
            response = await mediator.Send(new QuoteDetailUpdateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadById")]
        public async Task<IActionResult> ReadById([FromBody] QuoteDetailReadByIdRequestDTO requestDTO)
        {

            QuoteDetailDTO response = new QuoteDetailDTO();
            response = await mediator.Send(new QuoteDetailReadByIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadByQuotId")]
        public async Task<IActionResult> ReadByQuotId([FromBody] QuoteDetailReadByQuotIdRequestDTO requestDTO)
        {

            QuoteDetailDTO response = new QuoteDetailDTO();
            response = await mediator.Send(new QuoteDetailReadByQuotIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] QuoteDetailDeleteRequestDTO requestDTO)
        {

            await mediator.Send(new QuoteDetailDeleteCommand
            {
                reqDTO = requestDTO
            });

            return Ok();
        }
        [HttpGet("ReadAll")]
        public async Task<IActionResult> ReadAll()
        {
            //_logger.LogInformation("This is for Graylog Testing");
            QuoteDetailList response = new QuoteDetailList();
            response = await mediator.Send(new QuoteDetailReadAllCommand
            {
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }

    }
}
