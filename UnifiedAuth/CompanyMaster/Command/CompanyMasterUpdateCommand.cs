using CompanyMaster.DTO;
using CompanyMaster.Interface;
using MediatR;

namespace CompanyMaster.Command
{
    public class CompanyMasterUpdateCommand : IRequest<CompanyMasterDTO>
    {
        public CompanyMasterUpdateRequestDTO reqDTO { get; set; }
    }
    internal class CompanyMasterUpdateHandler : IRequestHandler<CompanyMasterUpdateCommand, CompanyMasterDTO>
    {
        protected readonly ICompanyMaster _companyMaster;

        public CompanyMasterUpdateHandler(ICompanyMaster companyMaster)
        {
            _companyMaster = companyMaster;
        }
        public async Task<CompanyMasterDTO> Handle(CompanyMasterUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _companyMaster.Update(request.reqDTO);
        }
    }
}
