using CompanyMaster.DTO;
using CompanyMaster.Interface;
using MediatR;

namespace CompanyMaster.Command
{
    public class CompanyMasterReadAllCommand : IRequest<CompanyMasterList>
    {
    }
    internal class CompanyMasterReadAllHandler : IRequestHandler<CompanyMasterReadAllCommand, CompanyMasterList>
    {
        protected readonly ICompanyMaster _companyMaster;

        public CompanyMasterReadAllHandler(ICompanyMaster companyMaster)
        {
            _companyMaster = companyMaster;
        }
        public async Task<CompanyMasterList> Handle(CompanyMasterReadAllCommand request, CancellationToken cancellationToken)
        {
            return await _companyMaster.ReadAll();
        }
    }
}
