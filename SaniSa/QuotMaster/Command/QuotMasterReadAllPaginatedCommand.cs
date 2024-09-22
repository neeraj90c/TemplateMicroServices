using Common.DTO;
using MediatR;
using QuotMaster.DTO;
using QuotMaster.Interface;

namespace QuotMaster.Command
{
    public class QuotMasterReadAllPaginatedCommand : IRequest<QuotMasterList>
    {
        public QuotMasterReadAllPaginatedRequestDTO reqDTO { get; set; }
    }
    internal class QuotMasterReadAllPaginatedHandler : IRequestHandler<QuotMasterReadAllPaginatedCommand, QuotMasterList>
    {
        protected readonly IQuotMaster _quotMaster;

        public QuotMasterReadAllPaginatedHandler(IQuotMaster quotMaster)
        {
            _quotMaster = quotMaster;
        }
        public async Task<QuotMasterList> Handle(QuotMasterReadAllPaginatedCommand request, CancellationToken cancellationToken)
        {
            return await _quotMaster.ReadAllPaginated(request.reqDTO);
        }
    }
}
