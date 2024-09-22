using Common.DTO;
using Common.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EncryptDecryptService.Controllers
{
    [EnableCors("systel")]
    public class EncryptDecryptController : Controller
    {
        APISettings _settings;
        protected readonly IEncryptDecrypt _encryptDecrypt;
        private ILogger<EncryptDecryptController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EncryptDecryptController(IOptions<APISettings> settings, IEncryptDecrypt encryptDecrypt, IWebHostEnvironment webHostEnvironment, ILogger<EncryptDecryptController> logger)
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
            healthCheckResponseDTO.Key = "Encrypt Decrypt API";
            healthCheckResponseDTO.Value = "Running Successfully!!";
            return Ok(healthCheckResponseDTO);
        }

        [HttpPost("Encrypt")]
        public async Task<IActionResult> Encrypt(string value)
        {
            _logger.LogInformation($" Application Web root Path : {_webHostEnvironment.WebRootPath}");
            SessionObj.WebRootPath = _webHostEnvironment.ContentRootPath;
            string EncryptedValue = _encryptDecrypt.EncryptValue(value);
            return Ok(EncryptedValue);
        }
        [HttpPost("Decrypt")]
        public async Task<IActionResult> Decrypt(string value)
        {
            _logger.LogInformation($" Application Web root Path : {_webHostEnvironment.WebRootPath}");
            SessionObj.WebRootPath = _webHostEnvironment.ContentRootPath;
            string DecryptedValue = _encryptDecrypt.DecryptValue(value);
            return Ok(DecryptedValue);
        }
    }
}
