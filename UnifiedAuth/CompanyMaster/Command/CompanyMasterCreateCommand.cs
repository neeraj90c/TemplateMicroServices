using CompanyMaster.DTO;
using CompanyMaster.Interface;
using MediatR;

namespace CompanyMaster.Command
{
    public class CompanyMasterCreateCommand : IRequest<CompanyMasterDTO>
    {
        public CompanyMasterCreateRequestDTO reqDTO { get; set; }
    }
    internal class CompanyMasterCreateHandler : IRequestHandler<CompanyMasterCreateCommand, CompanyMasterDTO>
    {
        protected readonly ICompanyMaster _companyMaster;

        public CompanyMasterCreateHandler(ICompanyMaster companyMaster)
        {
            _companyMaster = companyMaster;
        }
        public async Task<CompanyMasterDTO> Handle(CompanyMasterCreateCommand request, CancellationToken cancellationToken)
        {
            return await _companyMaster.Create(request.reqDTO);
        }
    }
}
