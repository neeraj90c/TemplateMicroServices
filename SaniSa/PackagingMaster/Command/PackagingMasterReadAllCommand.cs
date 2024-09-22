using MediatR;
using PackagingMaster.DTO;
using PackagingMaster.Interface;

namespace PackagingMaster.Command
{
    public class PackagingMasterReadAllCommand : IRequest<PackagingMasterList>
    {
    }
    internal class PackagingMasterReadAllHandler : IRequestHandler<PackagingMasterReadAllCommand, PackagingMasterList>
    {
        protected readonly IPackagingMaster _packagingMaster;

        public PackagingMasterReadAllHandler(IPackagingMaster packagingMaster)
        {
            _packagingMaster = packagingMaster;
        }
        public async Task<PackagingMasterList> Handle(PackagingMasterReadAllCommand request, CancellationToken cancellationToken)
        {
            return await _packagingMaster.ReadAll();
        }
    }
}
