using MediatR;
using KitDetail.DTO;
using KitDetail.Interface;

namespace KitDetail.Command
{
    public class KitDetailUpdateCommand : IRequest<KitDetailDTO>
    {
        public KitDetailUpdateRequestDTO reqDTO { get; set; }
    }
    internal class KitDetailUpdateHandler : IRequestHandler<KitDetailUpdateCommand, KitDetailDTO>
    {
        protected readonly IKitDetail _kitDetail;

        public KitDetailUpdateHandler(IKitDetail kitDetail)
        {
            _kitDetail = kitDetail;
        }
        public async Task<KitDetailDTO> Handle(KitDetailUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _kitDetail.Update(request.reqDTO);
        }
    }
}
