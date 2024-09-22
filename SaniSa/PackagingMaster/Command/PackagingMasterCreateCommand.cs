using MediatR;
using PackagingMaster.DTO;
using PackagingMaster.Interface;

namespace PackagingMaster.Command
{
    public class PackagingMasterCreateCommand : IRequest<PackagingMasterDTO>
    {
        public PackagingMasterCreateRequestDTO reqDTO { get; set; }
    }
    internal class PackagingMasterCreateHandler : IRequestHandler<PackagingMasterCreateCommand, PackagingMasterDTO>
    {
        protected readonly IPackagingMaster _packagingMaster;
        public PackagingMasterCreateHandler(IPackagingMaster packagingMaster)
        {
            _packagingMaster = packagingMaster;
        }
        public async Task<PackagingMasterDTO> Handle(PackagingMasterCreateCommand request, CancellationToken cancellationToken)
        {
            return await _packagingMaster.Create(request.reqDTO);
        }
    }
}
