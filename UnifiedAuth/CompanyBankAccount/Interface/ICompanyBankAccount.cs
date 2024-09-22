using CompanyBankAccount.DTO;

namespace CompanyBankAccount.Interface
{
    public interface ICompanyBankAccount
    {
        Task<CompanyBankAccountDTO> Create(CompanyBankAccountCreateRequestDTO reqDTO);
        Task<CompanyBankAccountDTO> Update(CompanyBankAccountUpdateRequestDTO reqDTO);
        Task Delete(CompanyBankAccountDeleteRequestDTO reqDTO);
        Task<CompanyBankAccountDTO> ReadById(CompanyBankAccountReadByIdRequestDTO reqDTO);
        Task<CompanyBankAccountList> ReadAll();
        Task<CompanyBankAccountList> ReadByCompanyId(CompanyBankAccountReadByCompanyIdRequestDTO reqDTO);
        Task<CompanyBankAccountList> ReadByBankId(CompanyBankAccountReadByBankIdRequestDTO reqDTO);
    }
}
