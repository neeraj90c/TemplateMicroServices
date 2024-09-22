using MediatR;
using PackagingMaster.DTO;
using PackagingMaster.Interface;

namespace PackagingMaster.Command
{
    public class PackagingMasterReadByIdCommand : IRequest<PackagingMasterDTO>
    {
        public PackagingMasterReadByIdRequestDTO reqDTO { get; set; }
    }
    internal class PackagingMasterReadByIdHandler : IRequestHandler<PackagingMasterReadByIdCommand, PackagingMasterDTO>
    {
        protected readonly IPackagingMaster _packagingMaster;

        public PackagingMasterReadByIdHandler(IPackagingMaster packagingMaster)
        {
            _packagingMaster = packagingMaster;
        }
        public async Task<PackagingMasterDTO> Handle(PackagingMasterReadByIdCommand request, CancellationToken cancellationToken)
        {
            return await _packagingMaster.ReadById(request.reqDTO);
        }
    }
}
