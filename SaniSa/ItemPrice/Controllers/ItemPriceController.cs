using Common.DTO;
using Common.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ItemPrice.Command;
using ItemPrice.DTO;

namespace ItemMaster.Controllers
{
    public class ItemPriceController : BaseApiController
    {
        APISettings _settings;
        protected readonly IEncryptDecrypt _encryptDecrypt;
        private ILogger<ItemPriceController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ItemPriceController(IOptions<APISettings> settings, IEncryptDecrypt encryptDecrypt, IWebHostEnvironment webHostEnvironment, ILogger<ItemPriceController> logger)
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
            healthCheckResponseDTO.Key = "Item Master API";
            healthCheckResponseDTO.Value = "Running Successfully!!";
            return Ok(healthCheckResponseDTO);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ItemPriceCreateRequestDTO requestDTO)
        {

            ItemPriceDTO response = new ItemPriceDTO();
            response = await mediator.Send(new ItemPriceCreateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] ItemPriceUpdateRequestDTO requestDTO)
        {

            ItemPriceDTO response = new ItemPriceDTO();
            response = await mediator.Send(new ItemPriceUpdateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadById")]
        public async Task<IActionResult> ReadById([FromBody] ItemPriceReadByIdRequestDTO requestDTO)
        {

            ItemPriceDTO response = new ItemPriceDTO();
            response = await mediator.Send(new ItemPriceReadByIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadByItemId")]
        public async Task<IActionResult> ReadByItemId([FromBody] ItemPriceReadByItemIdRequestDTO requestDTO)
        {

            ItemPriceDTO response = new ItemPriceDTO();
            response = await mediator.Send(new ItemPriceReadByItemIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] ItemPriceDeleteRequestDTO requestDTO)
        {

            await mediator.Send(new ItemPriceDeleteCommand
            {
                reqDTO = requestDTO
            });

            return Ok();
        }
        [HttpGet("ReadAll")]
        public async Task<IActionResult> ReadAll()
        {
            //_logger.LogInformation("This is for Graylog Testing");
            ItemPriceList response = new ItemPriceList();
            response = await mediator.Send(new ItemPriceReadAllCommand
            {
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }

    }
}
