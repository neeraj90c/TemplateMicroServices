using MediatR;
using KitMaster.DTO;
using KitMaster.Interface;

namespace KitMaster.Command
{
    public class KitMasterCreateCommand : IRequest<KitMasterDTO>
    {
        public KitMasterCreateRequestDTO reqDTO { get; set; }
    }
    internal class KitMasterCreateHandler : IRequestHandler<KitMasterCreateCommand, KitMasterDTO>
    {
        protected readonly IKitMaster _kitMaster;
        public KitMasterCreateHandler(IKitMaster kitMaster)
        {
            _kitMaster = kitMaster;
        }
        public async Task<KitMasterDTO> Handle(KitMasterCreateCommand request, CancellationToken cancellationToken)
        {
            return await _kitMaster.Create(request.reqDTO);
        }
    }
}
