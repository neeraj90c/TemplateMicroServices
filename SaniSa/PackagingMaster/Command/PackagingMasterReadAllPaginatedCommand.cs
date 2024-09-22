using Common.DTO;
using MediatR;
using PackagingMaster.DTO;
using PackagingMaster.Interface;

namespace PackagingMaster.Command
{
    public class PackagingMasterReadAllPaginatedCommand : IRequest<PackagingMasterList>
    {
        public PackagingMasterReadAllPaginatedRequestDTO reqDTO { get; set; }
    }
    internal class PackagingMasterReadAllPaginatedHandler : IRequestHandler<PackagingMasterReadAllPaginatedCommand, PackagingMasterList>
    {
        protected readonly IPackagingMaster _packagingMaster;

        public PackagingMasterReadAllPaginatedHandler(IPackagingMaster packagingMaster)
        {
            _packagingMaster = packagingMaster;
        }
        public async Task<PackagingMasterList> Handle(PackagingMasterReadAllPaginatedCommand request, CancellationToken cancellationToken)
        {
            return await _packagingMaster.ReadAllPaginated(request.reqDTO);
        }
    }
}
