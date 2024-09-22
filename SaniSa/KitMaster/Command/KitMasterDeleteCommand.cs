using MediatR;
using KitMaster.DTO;
using KitMaster.Interface;

namespace KitMaster.Command
{
    public class KitMasterDeleteCommand : IRequest
    {
        public KitMasterDeleteRequestDTO reqDTO { get; set; }
    }
    internal class KitMasterDeleteHandler : IRequestHandler<KitMasterDeleteCommand>
    {
        protected readonly IKitMaster _kitMaster;

        public KitMasterDeleteHandler(IKitMaster kitMaster)
        {
            _kitMaster = kitMaster;
        }
        public async Task Handle(KitMasterDeleteCommand request, CancellationToken cancellationToken)
        {
            await _kitMaster.Delete(request.reqDTO);
        }
    }
}
