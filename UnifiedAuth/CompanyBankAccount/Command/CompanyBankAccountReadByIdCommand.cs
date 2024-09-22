using CompanyBankAccount.DTO;
using CompanyBankAccount.Interface;
using MediatR;

namespace CompanyBankAccount.Command
{
    public class CompanyBankAccountReadByIdCommand : IRequest<CompanyBankAccountDTO>
    {
        public CompanyBankAccountReadByIdRequestDTO reqDTO { get; set; }
    }
    internal class CompanyBankAccountReadByIdHandler : IRequestHandler<CompanyBankAccountReadByIdCommand, CompanyBankAccountDTO>
    {
        protected readonly ICompanyBankAccount _companyBankAccount;

        public CompanyBankAccountReadByIdHandler(ICompanyBankAccount companyBankAccount)
        {
            _companyBankAccount = companyBankAccount;
        }
        public async Task<CompanyBankAccountDTO> Handle(CompanyBankAccountReadByIdCommand request, CancellationToken cancellationToken)
        {
            return await _companyBankAccount.ReadById(request.reqDTO);
        }
    }
}
