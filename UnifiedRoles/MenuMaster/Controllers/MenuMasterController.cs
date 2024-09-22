using Common.DTO;
using Common.Interface;
using MenuMaster.Command;
using MenuMaster.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MenuMaster.Controllers
{
    public class MenuMasterController : BaseApiController
    {
        APISettings _settings;
        protected readonly IEncryptDecrypt _encryptDecrypt;
        private ILogger<MenuMasterController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MenuMasterController(IOptions<APISettings> settings, IEncryptDecrypt encryptDecrypt, IWebHostEnvironment webHostEnvironment, ILogger<MenuMasterController> logger)
        {
            _logger = logger;
            _settings = settings.Value;
            _encryptDecrypt = encryptDecrypt;
            _webHostEnvironment = webHostEnvironment;

            //SessionObj.WebRootPath = _webHostEnvironment.ContentRootPath;
        }
        [HttpGet("healthCheck")]
        public async Task<IActionResult> HealthCheck()
        {
            HealthCheckResponseDTO healthCheckResponseDTO = new HealthCheckResponseDTO();
            healthCheckResponseDTO.Key = "Menu Master API";
            healthCheckResponseDTO.Value = "Running Successfully!!";
            return Ok(healthCheckResponseDTO);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] MenuMasterCreateRequestDTO requestDTO)
        {

            MenuMasterDTO response = new MenuMasterDTO();
            response = await mediator.Send(new MenuMasterCreateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] MenuMasterUpdateRequestDTO requestDTO)
        {

            MenuMasterDTO response = new MenuMasterDTO();
            response = await mediator.Send(new MenuMasterUpdateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadById")]
        public async Task<IActionResult> ReadById([FromBody] MenuMasterReadByIdRequestDTO requestDTO)
        {

            MenuMasterDTO response = new MenuMasterDTO();
            response = await mediator.Send(new MenuMasterReadByIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] MenuMasterDeleteRequestDTO requestDTO)
        {

            MenuMasterDTO response = new MenuMasterDTO();
            await mediator.Send(new MenuMasterDeleteCommand
            {
                reqDTO = requestDTO
            });

            return Ok();
        }
        [HttpPost("ReadByProjectId")]
        public async Task<IActionResult> ReadByProjectId([FromBody] MenuMasterReadByProjectIdRequestDTO requestDTO)
        {

            MenuMasterList response = new MenuMasterList();
            response = await mediator.Send(new MenuMasterReadByProjectIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpGet("ReadAll")]
        public async Task<IActionResult> ReadAll()
        {

            MenuMasterList response = new MenuMasterList();
            response = await mediator.Send(new MenuMasterReadAllCommand
            {
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
    }
}
