using MediatR;
using PackagingMaster.DTO;
using PackagingMaster.Interface;

namespace PackagingMaster.Command
{
    public class PackagingMasterUpdateCommand : IRequest<PackagingMasterDTO>
    {
        public PackagingMasterUpdateRequestDTO reqDTO { get; set; }
    }
    internal class PackagingMasterUpdateHandler : IRequestHandler<PackagingMasterUpdateCommand, PackagingMasterDTO>
    {
        protected readonly IPackagingMaster _packagingMaster;

        public PackagingMasterUpdateHandler(IPackagingMaster packagingMaster)
        {
            _packagingMaster = packagingMaster;
        }
        public async Task<PackagingMasterDTO> Handle(PackagingMasterUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _packagingMaster.Update(request.reqDTO);
        }
    }
}
