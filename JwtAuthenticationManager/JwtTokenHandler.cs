using Common.DTO;
using Common.Interface;
using Common.Service;
using JwtAuthenticationManager.Interface;
using JwtAuthenticationManager.Models;
using JwtAuthenticationManager.Service;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthenticationManager
{
    public class JwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "microServicesByMindstackToSystel";
        private const int JWT_TOKEN_VALIDITY_MINS = 20;

        JWTSettings _jwtSettings;
        APISettings _apiSettings;
        ConnectionSettings _connectionSettings;
        protected readonly IEncryptDecrypt _encryptDecrypt;
        public JwtTokenHandler(IOptions<ConnectionSettings> connectionSettings, IEncryptDecrypt encryptDecrypt, IOptions<APISettings> apiSettings, IOptions<JWTSettings> jwtSettings) {
            _connectionSettings = connectionSettings.Value;
            _encryptDecrypt = encryptDecrypt;
            _apiSettings = apiSettings.Value;
            _jwtSettings = jwtSettings.Value;
        }
        public AuthenticationResponse? GenerateJwtToken(AuthenticationRequest authenticationRequest)
        {
            if(string.IsNullOrWhiteSpace(authenticationRequest.UserName) || string.IsNullOrWhiteSpace(authenticationRequest.Password))
                return null;

            /* Validation */
            IAuthenticate authenticate = new AthenticateService(_connectionSettings);
            User user = authenticate.Authenticate(authenticationRequest);

            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(Convert.ToInt32(_jwtSettings.TokenExpiryMinute));
            var tokenKey = Encoding.ASCII.GetBytes(_jwtSettings.AppSecret);

            SessionParam session = new SessionParam
            {
                Param0 = _encryptDecrypt.EncryptValue(user.UserId.ToString()),
                Param1 = _encryptDecrypt.EncryptValue(user.FirstName + " " + user.LastName),
                Param2 = _encryptDecrypt.EncryptValue(user.Designation),
                Param3 = _encryptDecrypt.EncryptValue(user.EmailId),
                Param4 = _encryptDecrypt.EncryptValue(user.MobileNo),
                Param5 = _encryptDecrypt.EncryptValue(Convert.ToString(user.RoleId))
            };

            string strClaimdata = JsonConvert.SerializeObject(session);

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim( type: ClaimTypes.Name, value: strClaimdata),
                }),
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };

            string token = string.Empty;
            string profileImage = string.Empty;
            if (user != null && user.UserId != null && user.UserId > 0)
            {

                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                var securityToken = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
                token = jwtSecurityTokenHandler.WriteToken(securityToken);
            }

            return new AuthenticationResponse
            {
                UserNameIntial = user.FirstName + " " + user.LastName,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                Token = token,
                ProfileImage = profileImage,
                Designation = (user.UserId > 0) ? user.Designation : user.ResponseDescription,
                EmailId = user.EmailId,
                MobileNo = user.MobileNo,
                RoleId = user.RoleId,
            };
        }
    }
}
