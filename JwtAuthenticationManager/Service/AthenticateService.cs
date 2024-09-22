using Common.Service;
using Dapper;
using JwtAuthenticationManager.Interface;
using JwtAuthenticationManager.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthenticationManager.Service
{
    public class AthenticateService: DABase, IAuthenticate
    {
        private const string SP_AuthenticateUser = "dbo.ValidateUserLogin";
        private const string SP_AuthenticateAzureUser = "dbo.ValidateAzureUserLogin";

        ConnectionSettings _connectionSettings;
        public AthenticateService(ConnectionSettings connectionSettings) : base(connectionSettings.AppKeyPath)
        {
            _connectionSettings = connectionSettings;
        }
        public User Authenticate(AuthenticationRequest requestObj)
        {
            User userInfo = null;
            try
            {

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    userInfo = connection.QuerySingle<User>(SP_AuthenticateUser, new
                    {
                        UserName = requestObj.UserName,
                        UserPassword = requestObj.Password,
                        CompanyId = requestObj.CompanyCode

                    }, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return userInfo;
        }
    }
}
