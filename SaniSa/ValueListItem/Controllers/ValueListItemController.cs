using Common.DTO;
using Common.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ValueListItem.Command;
using ValueListItem.DTO;

namespace ValueListItem.Controllers
{
    public class ValueListItemController : BaseApiController
    {
        APISettings _settings;
        protected readonly IEncryptDecrypt _encryptDecrypt;
        private ILogger<ValueListItemController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ValueListItemController(IOptions<APISettings> settings, IEncryptDecrypt encryptDecrypt, IWebHostEnvironment webHostEnvironment, ILogger<ValueListItemController> logger)
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
            healthCheckResponseDTO.Key = "Value List Item API";
            healthCheckResponseDTO.Value = "Running Successfully!!";
            return Ok(healthCheckResponseDTO);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ValueListItemCreateRequestDTO requestDTO)
        {

            ValueListItemDTO response = new ValueListItemDTO();
            response = await mediator.Send(new ValueListItemCreateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] ValueListItemUpdateRequestDTO requestDTO)
        {

            ValueListItemDTO response = new ValueListItemDTO();
            response = await mediator.Send(new ValueListItemUpdateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadById")]
        public async Task<IActionResult> ReadById([FromBody] ValueListItemReadByIdRequestDTO requestDTO)
        {

            ValueListItemDTO response = new ValueListItemDTO();
            response = await mediator.Send(new ValueListItemReadByIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] ValueListItemDeleteRequestDTO requestDTO)
        {

            ValueListItemDTO response = new ValueListItemDTO();
            await mediator.Send(new ValueListItemDeleteCommand
            {
                reqDTO = requestDTO
            });

            return Ok();
        }
        [HttpPost("ReadByValueListId")]
        public async Task<IActionResult> ReadByValueListId([FromBody] ValueListItemReadByValueListIdRequestDTO requestDTO)
        {

            ValueListItemList response = new ValueListItemList();
            response = await mediator.Send(new ValueListItemReadByValueListIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadByVlCode")]
        public async Task<IActionResult> ReadByVlCode([FromBody] ValueListItemReadByVlCodeRequestDTO requestDTO)
        {

            ValueListItemList response = new ValueListItemList();
            response = await mediator.Send(new ValueListItemReadByVlCodeCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadByVlName")]
        public async Task<IActionResult> ReadByVlName([FromBody] ValueListItemReadByVlNameRequestDTO requestDTO)
        {

            ValueListItemList response = new ValueListItemList();
            response = await mediator.Send(new ValueListItemReadByVlNameCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
    }
}
