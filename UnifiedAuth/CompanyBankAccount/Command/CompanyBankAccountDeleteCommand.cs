using CompanyBankAccount.DTO;
using CompanyBankAccount.Interface;
using MediatR;

namespace CompanyBankAccount.Command
{
    public class CompanyBankAccountDeleteCommand : IRequest
    {
        public CompanyBankAccountDeleteRequestDTO reqDTO { get; set; }
    }
    internal class CompanyBankAccountDeleteHandler : IRequestHandler<CompanyBankAccountDeleteCommand>
    {
        protected readonly ICompanyBankAccount _companyBankAccount;

        public CompanyBankAccountDeleteHandler(ICompanyBankAccount companyBankAccount)
        {
            _companyBankAccount = companyBankAccount;
        }
        public async Task Handle(CompanyBankAccountDeleteCommand request, CancellationToken cancellationToken)
        {
            await _companyBankAccount.Delete(request.reqDTO);
        }
    }
}
