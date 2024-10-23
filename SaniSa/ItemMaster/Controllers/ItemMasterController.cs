using Common.DTO;
using Common.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ItemMaster.Command;
using ItemMaster.DTO;

namespace ItemMaster.Controllers
{
    public class ItemMasterController : BaseApiController
    {
        APISettings _settings;
        protected readonly IEncryptDecrypt _encryptDecrypt;
        private ILogger<ItemMasterController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ItemMasterController(IOptions<APISettings> settings, IEncryptDecrypt encryptDecrypt, IWebHostEnvironment webHostEnvironment, ILogger<ItemMasterController> logger)
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
        public async Task<IActionResult> Create([FromBody] ItemMasterCreateRequestDTO requestDTO)
        {

            ItemMasterDTO response = new ItemMasterDTO();
            response = await mediator.Send(new ItemMasterCreateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] ItemMasterUpdateRequestDTO requestDTO)
        {

            ItemMasterDTO response = new ItemMasterDTO();
            response = await mediator.Send(new ItemMasterUpdateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadById")]
        public async Task<IActionResult> ReadById([FromBody] ItemMasterReadByIdRequestDTO requestDTO)
        {

            ItemMasterDTO response = new ItemMasterDTO();
            response = await mediator.Send(new ItemMasterReadByIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadByKitId")]
        public async Task<IActionResult> ReadByKitId([FromBody] ItemMasterReadByKitIdRequestDTO requestDTO)
        {

            ItemMasterList response = new ItemMasterList();
            response = await mediator.Send(new ItemMasterReadByKitIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] ItemMasterrDeleteRequestDTO requestDTO)
        {

            await mediator.Send(new ItemMasterDeleteCommand
            {
                reqDTO = requestDTO
            });

            return Ok();
        }
        [HttpGet("ReadAll")]
        public async Task<IActionResult> ReadAll()
        {
            //_logger.LogInformation("This is for Graylog Testing");
            ItemMasterList response = new ItemMasterList();
            response = await mediator.Send(new ItemMasterReadAllCommand
            {
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }

        [HttpPost("ReadAllPaginated")]
        public async Task<IActionResult> ReadAllPaginated([FromBody] ItemMasterReadAllPaginatedRequestDTO requestDTO)
        {

            ItemMasterList response = new ItemMasterList();
            response = await mediator.Send(new ItemMasterReadAllPaginatedCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }

        [HttpPost("SearchByName")]
        public async Task<IActionResult> SearchByName([FromBody] ItemMasterSearchByNameRequestDTO requestDTO)
        {

            ItemMasterList response = new ItemMasterList();
            response = await mediator.Send(new ItemMasterSearchByNameCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }

        [HttpPost("ReadByCategoryId")]
        public async Task<IActionResult> ReadByCategoryId([FromBody] ItemMasterReadByCategoryIdRequestDTO requestDTO)
        {

            ItemMasterList response = new ItemMasterList();
            response = await mediator.Send(new ItemMasterReadByCategoryIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }

    }
}
