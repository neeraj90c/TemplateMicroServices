using MediatR;
using QuotMaster.DTO;
using QuotMaster.Interface;

namespace QuotMaster.Command
{
    public class QuotMasterReadAllCommand : IRequest<QuotMasterList>
    {
    }
    internal class QuotMasterReadAllHandler : IRequestHandler<QuotMasterReadAllCommand, QuotMasterList>
    {
        protected readonly IQuotMaster _quotMaster;

        public QuotMasterReadAllHandler(IQuotMaster quotMaster)
        {
            _quotMaster = quotMaster;
        }
        public async Task<QuotMasterList> Handle(QuotMasterReadAllCommand request, CancellationToken cancellationToken)
        {
            return await _quotMaster.ReadAll();
        }
    }
}
