using MediatR;
using BrandMaster.DTO;
using BrandMaster.Interface;

namespace BrandMaster.Command
{
    public class BrandMasterCreateCommand : IRequest<BrandMasterDTO>
    {
        public BrandMasterCreateRequestDTO reqDTO { get; set; }
    }
    internal class BrandMasterCreateHandler : IRequestHandler<BrandMasterCreateCommand, BrandMasterDTO>
    {
        protected readonly IBrandMaster _projectMaster;

        public BrandMasterCreateHandler(IBrandMaster projectMaster)
        {
            _projectMaster = projectMaster;
        }
        public async Task<BrandMasterDTO> Handle(BrandMasterCreateCommand request, CancellationToken cancellationToken)
        {
            return await _projectMaster.Create(request.reqDTO);
        }
    }
}
