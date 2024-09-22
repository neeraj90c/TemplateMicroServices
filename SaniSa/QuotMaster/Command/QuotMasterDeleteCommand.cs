using MediatR;
using QuotMaster.DTO;
using QuotMaster.Interface;

namespace QuotMaster.Command
{
    public class QuotMasterDeleteCommand : IRequest
    {
        public QuotMasterDeleteRequestDTO reqDTO { get; set; }
    }
    internal class QuotMasterDeleteHandler : IRequestHandler<QuotMasterDeleteCommand>
    {
        protected readonly IQuotMaster _quotMaster;

        public QuotMasterDeleteHandler(IQuotMaster quotMaster)
        {
            _quotMaster = quotMaster;
        }
        public async Task Handle(QuotMasterDeleteCommand request, CancellationToken cancellationToken)
        {
            await _quotMaster.Delete(request.reqDTO);
        }
    }
}
