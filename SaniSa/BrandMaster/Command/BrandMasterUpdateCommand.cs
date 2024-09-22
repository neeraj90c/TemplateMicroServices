using MediatR;
using BrandMaster.DTO;
using BrandMaster.Interface;

namespace BrandMaster.Command
{
    public class BrandMasterUpdateCommand : IRequest<BrandMasterDTO>
    {
        public BrandMasterUpdateRequestDTO reqDTO { get; set; }
    }
    internal class BrandMasterUpdateHandler : IRequestHandler<BrandMasterUpdateCommand, BrandMasterDTO>
    {
        protected readonly IBrandMaster _projectMaster;

        public BrandMasterUpdateHandler(IBrandMaster projectMaster)
        {
            _projectMaster = projectMaster;
        }
        public async Task<BrandMasterDTO> Handle(BrandMasterUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _projectMaster.Update(request.reqDTO);
        }
    }
}
