using MediatR;
using KitMaster.DTO;
using KitMaster.Interface;

namespace KitMaster.Command
{
    public class KitMasterReadAllCommand : IRequest<KitMasterList>
    {
    }
    internal class KitMasterReadAllHandler : IRequestHandler<KitMasterReadAllCommand, KitMasterList>
    {
        protected readonly IKitMaster _kitMaster;

        public KitMasterReadAllHandler(IKitMaster kitMaster)
        {
            _kitMaster = kitMaster;
        }
        public async Task<KitMasterList> Handle(KitMasterReadAllCommand request, CancellationToken cancellationToken)
        {
            return await _kitMaster.ReadAll();
        }
    }
}
