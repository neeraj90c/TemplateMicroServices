using Common.DTO;
using Common.Interface;
using EventDetail.Command;
using EventDetail.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EventDetail.Controllers
{
    public class EventDetailController : BaseApiController
    {
        APISettings _settings;
        protected readonly IEncryptDecrypt _encryptDecrypt;
        private ILogger<EventDetailController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EventDetailController(IOptions<APISettings> settings, IEncryptDecrypt encryptDecrypt, IWebHostEnvironment webHostEnvironment, ILogger<EventDetailController> logger)
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
            healthCheckResponseDTO.Key = "Event Detail API";
            healthCheckResponseDTO.Value = "Running Successfully!!";
            return Ok(healthCheckResponseDTO);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] EventDetailCreateRequestDTO requestDTO)
        {

            EventDetailResponseDTO response = new EventDetailResponseDTO();
            response = await mediator.Send(new EventDetailCreateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] EventDetailUpdateRequestDTO requestDTO)
        {

            EventDetailResponseDTO response = new EventDetailResponseDTO();
            response = await mediator.Send(new EventDetailUpdateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadById")]
        public async Task<IActionResult> ReadById([FromBody] EventDetailReadByIdRequestDTO requestDTO)
        {

            EventDetailResponseDTO response = new EventDetailResponseDTO();
            response = await mediator.Send(new EventDetailReadByIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] EventDetailDeleteRequestDTO requestDTO)
        {
            EventDetailResponseDTO response = new EventDetailResponseDTO();
            await mediator.Send(new EventDetailDeleteCommand
            {
                reqDTO = requestDTO
            });

            return Ok();
        }
        [HttpGet("ReadAll")]
        public async Task<IActionResult> ReadAll()
        {
            EventDetailList response = new EventDetailList();
            response = await mediator.Send(new EventDetailReadAllCommand
            {
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpGet("ReadByEventId")]
        public async Task<IActionResult> ReadByEventId(EventdetailReadByEventIdRequestDTO requestDTO)
        {
            EventDetailList response = new EventDetailList();
            response = await mediator.Send(new EventDetailReadByEventIdCommand
            {
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
    }
}
