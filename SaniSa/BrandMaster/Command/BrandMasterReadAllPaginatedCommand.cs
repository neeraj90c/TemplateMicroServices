using Common.DTO;
using MediatR;
using BrandMaster.DTO;
using BrandMaster.Interface;

namespace BrandMaster.Command
{
    public class BrandMasterReadAllPaginatedCommand : IRequest<BrandMasterList>
    {
        public BrandMasterReadAllPaginatedRequestDTO reqDTO { get; set; }
    }
    internal class BrandMasterReadAllPaginatedHandler : IRequestHandler<BrandMasterReadAllPaginatedCommand, BrandMasterList>
    {
        protected readonly IBrandMaster _projectMaster;

        public BrandMasterReadAllPaginatedHandler(IBrandMaster projectMaster)
        {
            _projectMaster = projectMaster;
        }
        public async Task<BrandMasterList> Handle(BrandMasterReadAllPaginatedCommand request, CancellationToken cancellationToken)
        {
            return await _projectMaster.ReadAllPaginated(request.reqDTO);
        }
    }
}
