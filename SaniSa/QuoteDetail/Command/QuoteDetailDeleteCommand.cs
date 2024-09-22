using MediatR;
using QuoteDetail.DTO;
using QuoteDetail.Interface;

namespace QuoteDetail.Command
{
    public class QuoteDetailDeleteCommand : IRequest
    {
        public QuoteDetailDeleteRequestDTO reqDTO { get; set; }
    }
    internal class QuoteDetailDeleteHandler : IRequestHandler<QuoteDetailDeleteCommand>
    {
        protected readonly IQuoteDetail _quoteDetail;

        public QuoteDetailDeleteHandler(IQuoteDetail quoteDetail)
        {
            _quoteDetail = quoteDetail;
        }
        public async Task Handle(QuoteDetailDeleteCommand request, CancellationToken cancellationToken)
        {
            await _quoteDetail.Delete(request.reqDTO);
        }
    }
}
