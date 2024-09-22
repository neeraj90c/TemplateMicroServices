using MediatR;
using KitDetail.DTO;
using KitDetail.Interface;

namespace KitDetail.Command
{
    public class KitDetailDeleteCommand : IRequest
    {
        public KitDetailDeleteRequestDTO reqDTO { get; set; }
    }
    internal class KitDetailDeleteHandler : IRequestHandler<KitDetailDeleteCommand>
    {
        protected readonly IKitDetail _kitDetail;

        public KitDetailDeleteHandler(IKitDetail kitDetail)
        {
            _kitDetail = kitDetail;
        }
        public async Task Handle(KitDetailDeleteCommand request, CancellationToken cancellationToken)
        {
            await _kitDetail.Delete(request.reqDTO);
        }
    }
}
