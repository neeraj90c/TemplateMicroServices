using Common.DTO;
using Common.Interface;
using Common.Service;
using JwtAuthenticationManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UserLogin.Command;
using UserLogin.DTO;

namespace UserLogin.Controllers
{
    public class UserLoginController : BaseApiController
    {
        APISettings _settings;
        protected readonly IEncryptDecrypt _encryptDecrypt;
        private ILogger<UserLoginController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly JwtTokenHandler _jwtTokenHandler;

        public UserLoginController(IOptions<APISettings> settings, IEncryptDecrypt encryptDecrypt, IWebHostEnvironment webHostEnvironment, ILogger<UserLoginController> logger, JwtTokenHandler jwtTokenHandler)
        {
            _logger = logger;
            _settings = settings.Value;
            _encryptDecrypt = encryptDecrypt;
            _webHostEnvironment = webHostEnvironment;

            SessionObj.WebRootPath = _webHostEnvironment.ContentRootPath;
            _jwtTokenHandler = jwtTokenHandler;
        }
        [HttpGet("healthCheck")]
        public async Task<IActionResult> HealthCheck()
        {
            HealthCheckResponseDTO healthCheckResponseDTO = new HealthCheckResponseDTO();
            healthCheckResponseDTO.Key = "User Login API";
            healthCheckResponseDTO.Value = "Running Successfully!!";
            return Ok(healthCheckResponseDTO);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] UserLoginCreateRequestDTO requestDTO)
        {
            requestDTO.UserPassword = _encryptDecrypt.EncryptValue(requestDTO.UserPassword);
            UserLoginDTO response = new UserLoginDTO();
            response = await mediator.Send(new UserLoginCreateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UserLoginUpdateRequestDTO requestDTO)
        {
            requestDTO.UserPassword = _encryptDecrypt.EncryptValue(requestDTO.UserPassword);
            UserLoginDTO response = new UserLoginDTO();
            response = await mediator.Send(new UserLoginUpdateCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("ReadByUserId")]
        public async Task<IActionResult> ReadByUserId([FromBody] UserLoginReadByUserIdRequestDTO requestDTO)
        {

            UserLoginDTO response = new UserLoginDTO();
            response = await mediator.Send(new UserLoginReadByUserIdCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] UserLoginDeleteRequestDTO requestDTO)
        {

            await mediator.Send(new UserLoginDeleteCommand
            {
                reqDTO = requestDTO
            });

            return Ok();
        }
        [HttpPost("ValidateUserName")]
        public async Task<IActionResult> ValidateUserName([FromBody] UserLoginValidateUserNameRequestDTO requestDTO)
        {

            ValidationResponse response = new ValidationResponse();
            response = await mediator.Send(new UserLoginValidateUserNameCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("auth")]
        public async Task<IActionResult> Auth([FromBody] AuthenticationRequest userDTO, [FromServices] IJwtToken jwtToken)
        {
            JwtAuthenticationManager.Models.AuthenticationRequest authenticationRequest = new JwtAuthenticationManager.Models.AuthenticationRequest();
            authenticationRequest.UserName = userDTO.UserName;
            authenticationRequest.Password = _encryptDecrypt.EncryptValue(userDTO.Password);
            authenticationRequest.CompanyCode = userDTO.CompanyCode;
            var authenticationResponse = _jwtTokenHandler.GenerateJwtToken(authenticationRequest);
            if (authenticationResponse == null) return Unauthorized();
            return Ok(APIResponse<dynamic>.OK(authenticationResponse));
        }

        [HttpPost("AzureAuth")]
        public async Task<IActionResult> AzureAuth([FromBody] DTO.AzureUserLoginDTO userDTO, [FromServices] IJwtToken jwtToken)
        {
            _logger.LogInformation($" Application Web root Path : {_webHostEnvironment.WebRootPath}");
            SessionObj.WebRootPath = _webHostEnvironment.ContentRootPath;
            //userDTO.Password = _encryptDecrypt.EncryptValue(userDTO.Password);

            UserDTO response = await mediator.Send(new AuthenticateAzureUserCommand
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                AzureUserId = userDTO.AzureUserId,
                AzureEmailId = userDTO.AzureEmailId,
                ExpiresOn = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(userDTO.ExpiresOn),
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            string token = string.Empty;
            string profileImage = string.Empty;
            if (response.UserId > 0)
            {
                UserSessionDTO userSessionDTO = new UserSessionDTO
                {
                    ID = response.UserId,
                    UserName = response.FirstName + " " + response.LastName,
                    Designation = response.Designation,
                    EmailId = response.EmailId,
                    MobileNo = response.MobileNo,
                    RoleId = response.RoleId,
                };

                token = jwtToken.CreateUserToken(userSessionDTO);
            }

            var result = new
            {
                token,
                profileImage,
                userId = response.UserId,
                userNameIntial = response.FirstName + " " + response.LastName,
                designation = (response.UserId > 0) ? response.Designation : response.ResponseDescription,
                emailId = response.EmailId,
                mobileNo = response.MobileNo,
                roleId = response.RoleId,
            };

            return Ok(APIResponse<dynamic>.OK(result));
        }

        [HttpGet("ValidateToken")]
        public async Task<IActionResult> ValidateToken([FromHeader] string Authorization, [FromServices] IJwtToken jwtToken)
        {
            string token = Authorization;
            UserSessionDTO userSessionDTO = jwtToken.ValidateToken(token);
            if (userSessionDTO == null)
            {
                return BadRequest("Token Expired");
            }
            else
            {
                Common.DTO.APISettings aPISettings = new Common.DTO.APISettings();
                {
                    aPISettings.ApiRootFolder = _settings.ApiRootFolder;
                    aPISettings.UIRootFolder = _settings.UIRootFolder;
                }
                string ProfileImagePath = Utilities.GetUserProfileImage(aPISettings, _webHostEnvironment.ContentRootPath, userSessionDTO.ID.ToString());

                var result = new
                {
                    token,
                    userId = userSessionDTO.ID,
                    profileImage = ProfileImagePath,
                    userName = userSessionDTO.UserName,
                    designation = userSessionDTO.Designation,
                    emailId = userSessionDTO.EmailId,
                    mobileNo = userSessionDTO.MobileNo,
                    roleId = userSessionDTO.RoleId,
                };

                return Ok(result);
            }
        }
    }
}
