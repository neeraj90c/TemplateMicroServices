using MediatR;
using QuoteDetail.DTO;
using QuoteDetail.Interface;

namespace QuoteDetail.Command
{
    public class QuoteDetailCreateCommand : IRequest<QuoteDetailDTO>
    {
        public QuoteDetailCreateRequestDTO reqDTO { get; set; }
    }
    internal class QuotMasterCreateHandler : IRequestHandler<QuoteDetailCreateCommand, QuoteDetailDTO>
    {
        protected readonly IQuoteDetail _quoteDetail;
        public QuotMasterCreateHandler(IQuoteDetail quoteDetail)
        {
            _quoteDetail = quoteDetail;
        }
        public async Task<QuoteDetailDTO> Handle(QuoteDetailCreateCommand request, CancellationToken cancellationToken)
        {
            return await _quoteDetail.Create(request.reqDTO);
        }
    }
}
