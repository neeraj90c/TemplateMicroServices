using CompanyMaster.DTO;
using CompanyMaster.Interface;
using MediatR;

namespace CompanyMaster.Command
{
    public class CompanyMasterDeleteCommand : IRequest
    {
        public CompanyMasterDeleteRequestDTO reqDTO { get; set; }
    }
    internal class CompanyMasterDeleteHandler : IRequestHandler<CompanyMasterDeleteCommand>
    {
        protected readonly ICompanyMaster _companyMaster;

        public CompanyMasterDeleteHandler(ICompanyMaster companyMaster)
        {
            _companyMaster = companyMaster;
        }
        public async Task Handle(CompanyMasterDeleteCommand request, CancellationToken cancellationToken)
        {
            await _companyMaster.Delete(request.reqDTO);
        }
    }
}
