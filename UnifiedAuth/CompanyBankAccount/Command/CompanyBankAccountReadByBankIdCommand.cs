using CompanyBankAccount.DTO;
using CompanyBankAccount.Interface;
using MediatR;

namespace CompanyBankAccount.Command
{
    public class CompanyBankAccountReadByBankIdCommand : IRequest<CompanyBankAccountList>
    {
        public CompanyBankAccountReadByBankIdRequestDTO reqDTO { get; set; }
    }
    internal class CompanyBankAccountReadByBankIdHandler : IRequestHandler<CompanyBankAccountReadByBankIdCommand, CompanyBankAccountList>
    {
        protected readonly ICompanyBankAccount _companyBankAccount;

        public CompanyBankAccountReadByBankIdHandler(ICompanyBankAccount companyBankAccount)
        {
            _companyBankAccount = companyBankAccount;
        }
        public async Task<CompanyBankAccountList> Handle(CompanyBankAccountReadByBankIdCommand request, CancellationToken cancellationToken)
        {
            return await _companyBankAccount.ReadByBankId(request.reqDTO);
        }
    }
}
