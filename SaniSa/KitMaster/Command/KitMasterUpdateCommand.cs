using MediatR;
using KitMaster.DTO;
using KitMaster.Interface;

namespace KitMaster.Command
{
    public class KitMasterUpdateCommand : IRequest<KitMasterDTO>
    {
        public KitMasterUpdateRequestDTO reqDTO { get; set; }
    }
    internal class KitMasterUpdateHandler : IRequestHandler<KitMasterUpdateCommand, KitMasterDTO>
    {
        protected readonly IKitMaster _kitMaster;

        public KitMasterUpdateHandler(IKitMaster kitMaster)
        {
            _kitMaster = kitMaster;
        }
        public async Task<KitMasterDTO> Handle(KitMasterUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _kitMaster.Update(request.reqDTO);
        }
    }
}
