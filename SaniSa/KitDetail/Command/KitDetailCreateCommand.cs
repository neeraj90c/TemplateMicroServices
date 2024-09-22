using MediatR;
using KitDetail.DTO;
using KitDetail.Interface;

namespace KitDetail.Command
{
    public class KitDetailCreateCommand : IRequest<KitDetailDTO>
    {
        public KitDetailCreateRequestDTO reqDTO { get; set; }
    }
    internal class KitMasterCreateHandler : IRequestHandler<KitDetailCreateCommand, KitDetailDTO>
    {
        protected readonly IKitDetail _kitDetail;
        public KitMasterCreateHandler(IKitDetail kitDetail)
        {
            _kitDetail = kitDetail;
        }
        public async Task<KitDetailDTO> Handle(KitDetailCreateCommand request, CancellationToken cancellationToken)
        {
            return await _kitDetail.Create(request.reqDTO);
        }
    }
}
