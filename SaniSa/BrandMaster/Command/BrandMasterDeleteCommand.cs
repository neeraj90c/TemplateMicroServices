using MediatR;
using BrandMaster.DTO;
using BrandMaster.Interface;

namespace BrandMaster.Command
{
    public class BrandMasterDeleteCommand : IRequest
    {
        public BrandMasterDeleteRequestDTO reqDTO { get; set; }
    }
    internal class BrandMasterDeleteHandler : IRequestHandler<BrandMasterDeleteCommand>
    {
        protected readonly IBrandMaster _projectMaster;

        public BrandMasterDeleteHandler(IBrandMaster projectMaster)
        {
            _projectMaster = projectMaster;
        }
        public async Task Handle(BrandMasterDeleteCommand request, CancellationToken cancellationToken)
        {
            await _projectMaster.Delete(request.reqDTO);
        }
    }
}
