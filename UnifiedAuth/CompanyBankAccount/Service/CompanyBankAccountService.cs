using Common.DTO;
using Common.Service;
using CompanyBankAccount.Interface;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;
using CompanyBankAccount.DTO;
using Dapper;

namespace CompanyBankAccount.Service
{
    public class CompanyBankAccountService: DABase, ICompanyBankAccount
    {
        private const string SP_CompanyBankAccount_Create = "CompanyBankAccount_Create";
        private const string SP_CompanyBankAccount_Delete = "CompanyBankAccount_Delete";
        private const string SP_CompanyBankAccount_ReadAll = "CompanyBankAccount_ReadAll";
        private const string SP_CompanyBankAccount_ReadByBankId = "CompanyBankAccount_ReadByBankId";
        private const string SP_CompanyBankAccount_ReadByCompanyId = "CompanyBankAccount_ReadByCompanyId";
        private const string SP_CompanyBankAccount_ReadById = "CompanyBankAccount_ReadById";
        private const string SP_CompanyBankAccount_Update = "CompanyBankAccount_Update";
        private ILogger<CompanyBankAccountService> _logger;
        public CompanyBankAccountService(IOptions<ConnectionSettings> connectionSettings, ILogger<CompanyBankAccountService> logger) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
        }
        public async Task<CompanyBankAccountDTO> Create(CompanyBankAccountCreateRequestDTO reqDTO)
        {

            CompanyBankAccountDTO retObj = null;
            _logger.LogInformation($"Started Company Bank Account Create for Account No :{reqDTO.AccountNo} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<CompanyBankAccountDTO>(SP_CompanyBankAccount_Create, new
                {
                    CompanyId = reqDTO.CompanyId,
                    BankId = reqDTO.BankId,
                    AccountHolderName = reqDTO.AccountHolderName,
                    AccountNo = reqDTO.AccountNo,
                    AccountType = reqDTO.AccountType,
                    AccountURN = reqDTO.AccountURN,
                    RefAccountNo = reqDTO.RefAccountNo,
                    AccountDescription = reqDTO.AccountDescription,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<CompanyBankAccountDTO> Update(CompanyBankAccountUpdateRequestDTO reqDTO)
        {

            CompanyBankAccountDTO retObj = null;
            _logger.LogInformation($"Started Company Bank Account Update {reqDTO.AccountId}  for Bank: {reqDTO.BankId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<CompanyBankAccountDTO>(SP_CompanyBankAccount_Update, new
                {
                    AccountId = reqDTO.AccountId,
                    CompanyId = reqDTO.CompanyId,
                    BankId = reqDTO.BankId,
                    AccountHolderName = reqDTO.AccountHolderName,
                    AccountNo = reqDTO.AccountNo,
                    AccountType = reqDTO.AccountType,
                    AccountURN = reqDTO.AccountURN,
                    RefAccountNo = reqDTO.RefAccountNo,
                    AccountDescription = reqDTO.AccountDescription,
                    IsActive = reqDTO.IsActive,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task Delete(CompanyBankAccountDeleteRequestDTO reqDTO)
        {

            _logger.LogInformation($"Started Company Bank Account Delete {reqDTO.AccountId} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(SP_CompanyBankAccount_Delete, new
                {
                    AccountId = reqDTO.AccountId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }
        }
        public async Task<CompanyBankAccountDTO> ReadById(CompanyBankAccountReadByIdRequestDTO reqDTO)
        {

            CompanyBankAccountDTO retObj = null;
            _logger.LogInformation($"Started Company Bank Account ReadById {reqDTO.AccountId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<CompanyBankAccountDTO>(SP_CompanyBankAccount_ReadById, new
                {
                    AccountId = reqDTO.AccountId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<CompanyBankAccountList> ReadAll()
        {

            CompanyBankAccountList retObj = new CompanyBankAccountList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<CompanyBankAccountDTO>(SP_CompanyBankAccount_ReadAll, new
                {
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<CompanyBankAccountList> ReadByCompanyId(CompanyBankAccountReadByCompanyIdRequestDTO reqDTO)
        {

            CompanyBankAccountList retObj = new CompanyBankAccountList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<CompanyBankAccountDTO>(SP_CompanyBankAccount_ReadByCompanyId, new
                {
                    CompanyId = reqDTO.CompanyId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<CompanyBankAccountList> ReadByBankId(CompanyBankAccountReadByBankIdRequestDTO reqDTO)
        {

            CompanyBankAccountList retObj = new CompanyBankAccountList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<CompanyBankAccountDTO>(SP_CompanyBankAccount_ReadByBankId, new
                {
                    BankId = reqDTO.BankId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
    }
}
