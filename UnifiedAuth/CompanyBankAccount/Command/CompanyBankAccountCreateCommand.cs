using CompanyBankAccount.DTO;
using CompanyBankAccount.Interface;
using MediatR;

namespace CompanyBankAccount.Command
{
    public class CompanyBankAccountCreateCommand : IRequest<CompanyBankAccountDTO>
    {
        public CompanyBankAccountCreateRequestDTO reqDTO { get; set; }
    }
    internal class CompanyBankAccountCreateHandler : IRequestHandler<CompanyBankAccountCreateCommand, CompanyBankAccountDTO>
    {
        protected readonly ICompanyBankAccount _companyBankAccount;

        public CompanyBankAccountCreateHandler(ICompanyBankAccount companyBankAccount)
        {
            _companyBankAccount = companyBankAccount;
        }
        public async Task<CompanyBankAccountDTO> Handle(CompanyBankAccountCreateCommand request, CancellationToken cancellationToken)
        {
            return await _companyBankAccount.Create(request.reqDTO);
        }
    }
}
