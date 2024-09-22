using MediatR;
using QuoteDetail.DTO;
using QuoteDetail.Interface;

namespace QuoteDetail.Command
{
    public class QuoteDetailReadAllCommand : IRequest<QuoteDetailList>
    {
    }
    internal class QuoteDetailReadAllHandler : IRequestHandler<QuoteDetailReadAllCommand, QuoteDetailList>
    {
        protected readonly IQuoteDetail _quoteDetail;

        public QuoteDetailReadAllHandler(IQuoteDetail quoteDetail)
        {
            _quoteDetail = quoteDetail;
        }
        public async Task<QuoteDetailList> Handle(QuoteDetailReadAllCommand request, CancellationToken cancellationToken)
        {
            return await _quoteDetail.ReadAll();
        }
    }
}
