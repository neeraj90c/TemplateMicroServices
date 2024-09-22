using CompanyBankAccount.DTO;
using CompanyBankAccount.Interface;
using MediatR;

namespace CompanyBankAccount.Command
{
    public class CompanyBankAccountReadByCompanyIdCommand : IRequest<CompanyBankAccountList>
    {
        public CompanyBankAccountReadByCompanyIdRequestDTO reqDTO { get; set; }
    }
    internal class CompanyBankAccountReadByCompanyIdHandler : IRequestHandler<CompanyBankAccountReadByCompanyIdCommand, CompanyBankAccountList>
    {
        protected readonly ICompanyBankAccount _companyBankAccount;

        public CompanyBankAccountReadByCompanyIdHandler(ICompanyBankAccount companyBankAccount)
        {
            _companyBankAccount = companyBankAccount;
        }
        public async Task<CompanyBankAccountList> Handle(CompanyBankAccountReadByCompanyIdCommand request, CancellationToken cancellationToken)
        {
            return await _companyBankAccount.ReadByCompanyId(request.reqDTO);
        }
    }
}
