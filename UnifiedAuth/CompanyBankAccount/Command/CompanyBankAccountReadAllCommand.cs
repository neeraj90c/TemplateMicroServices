using CompanyBankAccount.DTO;
using CompanyBankAccount.Interface;
using MediatR;

namespace CompanyBankAccount.Command
{
    public class CompanyBankAccountReadAllCommand : IRequest<CompanyBankAccountList>
    {
    }
    internal class CompanyBankAccountReadAllHandler : IRequestHandler<CompanyBankAccountReadAllCommand, CompanyBankAccountList>
    {
        protected readonly ICompanyBankAccount _companyBankAccount;

        public CompanyBankAccountReadAllHandler(ICompanyBankAccount companyBankAccount)
        {
            _companyBankAccount = companyBankAccount;
        }
        public async Task<CompanyBankAccountList> Handle(CompanyBankAccountReadAllCommand request, CancellationToken cancellationToken)
        {
            return await _companyBankAccount.ReadAll();
        }
    }
}
