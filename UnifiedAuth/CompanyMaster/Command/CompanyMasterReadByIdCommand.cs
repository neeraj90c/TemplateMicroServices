using CompanyMaster.DTO;
using CompanyMaster.Interface;
using MediatR;

namespace CompanyMaster.Command
{
    public class CompanyMasterReadByIdCommand : IRequest<CompanyMasterDTO>
    {
        public CompanyMasterReadByIdRequestDTO reqDTO { get; set; }
    }
    internal class CompanyMasterReadByIdHandler : IRequestHandler<CompanyMasterReadByIdCommand, CompanyMasterDTO>
    {
        protected readonly ICompanyMaster _companyMaster;

        public CompanyMasterReadByIdHandler(ICompanyMaster companyMaster)
        {
            _companyMaster = companyMaster;
        }
        public async Task<CompanyMasterDTO> Handle(CompanyMasterReadByIdCommand request, CancellationToken cancellationToken)
        {
            return await _companyMaster.ReadById(request.reqDTO);
        }
    }
}
