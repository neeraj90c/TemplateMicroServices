using MediatR;
using KitDetail.DTO;
using KitDetail.Interface;

namespace KitDetail.Command
{
    public class KitDetailReadByIdCommand : IRequest<KitDetailDTO>
    {
        public KitDetailReadByIdRequestDTO reqDTO { get; set; }
    }
    internal class KitDetailReadByIdHandler : IRequestHandler<KitDetailReadByIdCommand, KitDetailDTO>
    {
        protected readonly IKitDetail _kitDetail;

        public KitDetailReadByIdHandler(IKitDetail kitDetail)
        {
            _kitDetail = kitDetail;
        }
        public async Task<KitDetailDTO> Handle(KitDetailReadByIdCommand request, CancellationToken cancellationToken)
        {
            return await _kitDetail.ReadById(request.reqDTO);
        }
    }
}
