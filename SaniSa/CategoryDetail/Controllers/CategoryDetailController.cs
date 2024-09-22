using Common.DTO;
using Common.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using CategoryDetail.Command;
using CategoryDetail.DTO;

namespace CategoryDetail.Controllers
{
    public class CategoryDetailController : BaseApiController
    {
        APISettings _settings;
        protected readonly IEncryptDecrypt _encryptDecrypt;
        private ILogger<CategoryDetailController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoryDetailController(IOptions<APISettings> settings, IEncryptDecrypt encryptDecrypt, IWebHostEnvironment webHostEnvironment, ILogger<CategoryDetailController> logger)
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
            healthCheckResponseDTO.Key = "Category Detail API";
            healthCheckResponseDTO.Value = "Running Successfully!!";
            return Ok(healthCheckResponseDTO);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CategoryDetailCreateRequestDTO requestDTO)
        {

            CategoryDetailDTO response = new CategoryDetailDTO();
            response = await mediator.Send(new CategoryDetailCreateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] CategoryDetailUpdateRequestDTO requestDTO)
        {

            CategoryDetailDTO response = new CategoryDetailDTO();
            response = await mediator.Send(new CategoryDetailUpdateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadById")]
        public async Task<IActionResult> ReadById([FromBody] CategoryDetailReadByIdRequestDTO requestDTO)
        {

            CategoryDetailDTO response = new CategoryDetailDTO();
            response = await mediator.Send(new CategoryDetailReadByIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadByCategoryId")]
        public async Task<IActionResult> ReadByCategoryId([FromBody] CategoryDetailReadByCategoryIdRequestDTO requestDTO)
        {

            CategoryDetailDTO response = new CategoryDetailDTO();
            response = await mediator.Send(new CategoryDetailReadByCategoryIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] CategoryDetailDeleteRequestDTO requestDTO)
        {

            await mediator.Send(new CategoryDetailDeleteCommand
            {
                reqDTO = requestDTO
            });

            return Ok();
        }
        [HttpGet("ReadAll")]
        public async Task<IActionResult> ReadAll()
        {
            //_logger.LogInformation("This is for Graylog Testing");
            CategoryDetailList response = new CategoryDetailList();
            response = await mediator.Send(new CategoryDetailReadAllCommand
            {
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }

    }
}
