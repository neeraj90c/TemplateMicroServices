using CompanyBankAccount.DTO;
using CompanyBankAccount.Interface;
using MediatR;

namespace CompanyBankAccount.Command
{
    public class CompanyBankAccountUpdateCommand : IRequest<CompanyBankAccountDTO>
    {
        public CompanyBankAccountUpdateRequestDTO reqDTO { get; set; }
    }
    internal class CompanyBankAccountUpdateHandler : IRequestHandler<CompanyBankAccountUpdateCommand, CompanyBankAccountDTO>
    {
        protected readonly ICompanyBankAccount _companyBankAccount;

        public CompanyBankAccountUpdateHandler(ICompanyBankAccount companyBankAccount)
        {
            _companyBankAccount = companyBankAccount;
        }
        public async Task<CompanyBankAccountDTO> Handle(CompanyBankAccountUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _companyBankAccount.Update(request.reqDTO);
        }
    }
}
