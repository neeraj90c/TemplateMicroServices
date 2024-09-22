using KitDetail.DTO;
using KitDetail.Interface;
using MediatR;

namespace KitDetail.Command
{
    public class KitDetailReadByKitIdCommand : IRequest<KitDetailDTO>
    {
        public KitDetailReadByKitIdRequestDTO reqDTO { get; set; }
    }
    internal class KitDetailReadByKitIdCommandHandler : IRequestHandler<KitDetailReadByKitIdCommand, KitDetailDTO> 
    {
        protected readonly IKitDetail _kitDetail;
        public KitDetailReadByKitIdCommandHandler(IKitDetail kitDetail)
        {
            _kitDetail = kitDetail;
        }

        public async Task<KitDetailDTO> Handle(KitDetailReadByKitIdCommand request, CancellationToken cancellationToken)
        {
            return await _kitDetail.ReadByKitId(request.reqDTO);
        }
    }
}
