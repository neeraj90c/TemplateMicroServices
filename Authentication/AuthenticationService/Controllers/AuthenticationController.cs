using AuthenticationService.DTO;
using Common.Interface;
using Common.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using AuthenticationService.Command;
using Common.DTO;
using Microsoft.AspNetCore.Cors;
using JwtAuthenticationManager.Models;
using JwtAuthenticationManager;

namespace AuthenticationService.Controllers
{
    [EnableCors("systel")]
    public class AuthenticationController : BaseApiController
    {
        APISettings _settings;
        ConnectionSettings _connectionSettings;

        protected readonly IEncryptDecrypt _encryptDecrypt;
        private ILogger<AuthenticationController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly JwtTokenHandler _jwtTokenHandler;
        public AuthenticationController(IOptions<APISettings> settings, IEncryptDecrypt encryptDecrypt, IWebHostEnvironment webHostEnvironment, ILogger<AuthenticationController> logger, JwtTokenHandler jwtTokenHandler) 
        {
            _logger = logger;
            _settings = settings.Value;
            _encryptDecrypt = encryptDecrypt;
            _webHostEnvironment = webHostEnvironment;
            _jwtTokenHandler = jwtTokenHandler;

            SessionObj.WebRootPath = _webHostEnvironment.ContentRootPath;
        }
        [HttpGet("healthCheck")]
        public async Task<IActionResult> HealthCheck()
        {
            HealthCheckResponseDTO healthCheckResponseDTO = new HealthCheckResponseDTO();
            healthCheckResponseDTO.Key = "AuthenticationAPI";
            healthCheckResponseDTO.Value = "Running Successfully!!";
            return Ok(healthCheckResponseDTO);
        }

        [HttpPost("auth")]
        public async Task<IActionResult> Auth([FromBody] DTO.UserLoginDTO userDTO, [FromServices] IJwtToken jwtToken)
        {
            AuthenticationRequest authenticationRequest = new AuthenticationRequest();
            authenticationRequest.UserName = userDTO.UserName;
            authenticationRequest.Password = _encryptDecrypt.EncryptValue(userDTO.Password);
            authenticationRequest.CompanyCode = userDTO.CompanyCode;
            var authenticationResponse = _jwtTokenHandler.GenerateJwtToken(authenticationRequest);
            if (authenticationResponse == null) return Unauthorized();
            return Ok(APIResponse<dynamic>.OK(authenticationResponse)); 

            //_logger.LogInformation($" Application Web root Path : {_webHostEnvironment.WebRootPath}");
            //SessionObj.WebRootPath = _webHostEnvironment.ContentRootPath;
            //userDTO.Password = _encryptDecrypt.EncryptValue(userDTO.Password);

            //UserDTO response = await mediator.Send(new AuthenticateUserCommand
            //{
            //    CompanyCode = userDTO.CompanyCode,
            //    UserName = userDTO.UserName,
            //    Password = userDTO.Password
            //});

            //if (response == null)
            //    return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            //string token = string.Empty;
            //string profileImage = string.Empty;
            //if (response.UserId > 0)
            //{
            //    UserSessionDTO userSessionDTO = new UserSessionDTO
            //    {
            //        ID = response.UserId,
            //        UserName = response.FirstName + " " + response.LastName,
            //        Designation = response.Designation,
            //        EmailId = response.EmailId,
            //        MobileNo = response.MobileNo,
            //        RoleId = response.RoleId,
            //    };

            //    token = jwtToken.CreateUserToken(userSessionDTO);
            //}

            //var result = new
            //{
            //    token,
            //    profileImage,
            //    userId = response.UserId,
            //    userNameIntial = response.FirstName + " " + response.LastName,
            //    designation = (response.UserId > 0) ? response.Designation : response.ResponseDescription,
            //    emailId = response.EmailId,
            //    mobileNo = response.MobileNo,
            //    roleId = response.RoleId,
            //};

            //return Ok(APIResponse<dynamic>.OK(result));
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
        [HttpPost("UserMasterCrud")]
        public async Task<IActionResult> UserMasterCrud([FromBody] UserMasterDTO userMasterDTO)
        {
            userMasterDTO.WebRootPath = SessionObj.WebRootPath;
            UserList response = new UserList();
            response = await mediator.Send(new UserCRUDCommand
            {
                userMasterDTO = userMasterDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        [HttpPost("PaginatedUserMasterCrud")]
        public async Task<IActionResult> PaginatedUserMasterCrud([FromBody] UserMasterDTO userMasterDTO)
        {
            userMasterDTO.WebRootPath = SessionObj.WebRootPath;
            UserList response = new UserList();
            response = await mediator.Send(new PaginatedUserCRUDCommand
            {
                userMasterDTO = userMasterDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
        
        [HttpPost("GenerateUserCredentials")]
        public async Task<IActionResult> GenerateUserCredentials([FromBody] UserCredDTO userCredDTO)
        {
            UserList response = new UserList();
            userCredDTO.UserPassword = _encryptDecrypt.EncryptValue(userCredDTO.UserPassword);
            response = await mediator.Send(new UserLoginCRUDCommand
            {
                UserCredDTO = userCredDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }

        [HttpPost("UserWorkCenterCRUD")]
        public async Task<IActionResult> UserWorkCenterCRUD([FromBody] UserWorkCenterDTO userWorkCenterDTO)
        {
            UserWorkCenterList response = new UserWorkCenterList();
            response = await mediator.Send(new UserWorkCenterCRUDCommand
            {
                userWorkCenterDTO = userWorkCenterDTO
            });
            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }       

        [HttpPost("UserDashboardGet")]
        public async Task<IActionResult> UserDashboardGet([FromBody] UserDashboardDTO userDashboardDTO)
        {
            UserDashboardList response = new UserDashboardList();
            response = await mediator.Send(new UserDashboardCommand
            {
                userDashboardDTO = userDashboardDTO
            });
            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }

        [HttpPost("UserStatusUpdate")]
        public async Task<IActionResult> UserStatusUpdate([FromBody] UserMasterDTO userMasterDTO)
        {
            UserMasterDTO response = new UserMasterDTO();
            response = await mediator.Send(new UserStatusUpdateCommand
            {
                userMasterDTO = userMasterDTO
            });
            return Ok(response);
        }

    }
}

