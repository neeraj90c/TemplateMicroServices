using Common.DTO;
using MediatR;
using KitMaster.DTO;
using KitMaster.Interface;

namespace KitMaster.Command
{
    public class KitMasterReadAllPaginatedCommand : IRequest<KitMasterList>
    {
        public KitMasterReadAllPaginatedRequestDTO reqDTO { get; set; }
    }
    internal class KitMasterReadAllPaginatedHandler : IRequestHandler<KitMasterReadAllPaginatedCommand, KitMasterList>
    {
        protected readonly IKitMaster _kitMaster;

        public KitMasterReadAllPaginatedHandler(IKitMaster kitMaster)
        {
            _kitMaster = kitMaster;
        }
        public async Task<KitMasterList> Handle(KitMasterReadAllPaginatedCommand request, CancellationToken cancellationToken)
        {
            return await _kitMaster.ReadAllPaginated(request.reqDTO);
        }
    }
}
