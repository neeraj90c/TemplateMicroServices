using MediatR;
using BrandMaster.DTO;
using BrandMaster.Interface;

namespace BrandMaster.Command
{
    public class BrandMasterReadAllCommand : IRequest<BrandMasterList>
    {
    }
    internal class BrandMasterReadAllHandler : IRequestHandler<BrandMasterReadAllCommand, BrandMasterList>
    {
        protected readonly IBrandMaster _projectMaster;

        public BrandMasterReadAllHandler(IBrandMaster projectMaster)
        {
            _projectMaster = projectMaster;
        }
        public async Task<BrandMasterList> Handle(BrandMasterReadAllCommand request, CancellationToken cancellationToken)
        {
            return await _projectMaster.ReadAll();
        }
    }
}
