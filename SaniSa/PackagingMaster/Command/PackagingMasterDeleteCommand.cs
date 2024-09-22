using MediatR;
using PackagingMaster.DTO;
using PackagingMaster.Interface;

namespace PackagingMaster.Command
{
    public class PackagingMasterDeleteCommand : IRequest
    {
        public PackagingMasterDeleteRequestDTO reqDTO { get; set; }
    }
    internal class PackagingMasterDeleteHandler : IRequestHandler<PackagingMasterDeleteCommand>
    {
        protected readonly IPackagingMaster _packagingMaster;

        public PackagingMasterDeleteHandler(IPackagingMaster packagingMaster)
        {
            _packagingMaster = packagingMaster;
        }
        public async Task Handle(PackagingMasterDeleteCommand request, CancellationToken cancellationToken)
        {
            await _packagingMaster.Delete(request.reqDTO);
        }
    }
}
