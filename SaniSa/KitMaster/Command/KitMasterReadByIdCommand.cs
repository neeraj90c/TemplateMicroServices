using MediatR;
using KitMaster.DTO;
using KitMaster.Interface;

namespace KitMaster.Command
{
    public class KitMasterReadByIdCommand : IRequest<KitMasterDTO>
    {
        public KitMasterReadByIdRequestDTO reqDTO { get; set; }
    }
    internal class KitMasterReadByIdHandler : IRequestHandler<KitMasterReadByIdCommand, KitMasterDTO>
    {
        protected readonly IKitMaster _kitMaster;

        public KitMasterReadByIdHandler(IKitMaster kitMaster)
        {
            _kitMaster = kitMaster;
        }
        public async Task<KitMasterDTO> Handle(KitMasterReadByIdCommand request, CancellationToken cancellationToken)
        {
            return await _kitMaster.ReadById(request.reqDTO);
        }
    }
}
