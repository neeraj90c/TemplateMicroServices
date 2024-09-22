using QuoteDetail.DTO;
using QuoteDetail.Interface;
using MediatR;

namespace QuoteDetail.Command
{
    public class QuoteDetailReadByQuotIdCommand : IRequest<QuoteDetailDTO>
    {
        public QuoteDetailReadByQuotIdRequestDTO reqDTO { get; set; }
    }
    internal class QuoteDetailReadByQuotIdCommandHandler : IRequestHandler<QuoteDetailReadByQuotIdCommand, QuoteDetailDTO> 
    {
        protected readonly IQuoteDetail _quoteDetail;
        public QuoteDetailReadByQuotIdCommandHandler(IQuoteDetail quoteDetail)
        {
            _quoteDetail = quoteDetail;
        }

        public async Task<QuoteDetailDTO> Handle(QuoteDetailReadByQuotIdCommand request, CancellationToken cancellationToken)
        {
            return await _quoteDetail.ReadByQuotId(request.reqDTO);
        }
    }
}
