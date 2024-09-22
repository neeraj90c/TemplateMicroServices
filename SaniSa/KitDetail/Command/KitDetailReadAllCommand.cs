using MediatR;
using KitDetail.DTO;
using KitDetail.Interface;

namespace KitDetail.Command
{
    public class KitDetailReadAllCommand : IRequest<KitDetailList>
    {
    }
    internal class KitDetailReadAllHandler : IRequestHandler<KitDetailReadAllCommand, KitDetailList>
    {
        protected readonly IKitDetail _kitDetail;

        public KitDetailReadAllHandler(IKitDetail kitDetail)
        {
            _kitDetail = kitDetail;
        }
        public async Task<KitDetailList> Handle(KitDetailReadAllCommand request, CancellationToken cancellationToken)
        {
            return await _kitDetail.ReadAll();
        }
    }
}
