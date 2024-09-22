using MediatR;
using QuoteDetail.DTO;
using QuoteDetail.Interface;

namespace QuoteDetail.Command
{
    public class QuoteDetailUpdateCommand : IRequest<QuoteDetailDTO>
    {
        public QuoteDetailUpdateRequestDTO reqDTO { get; set; }
    }
    internal class QuoteDetailUpdateHandler : IRequestHandler<QuoteDetailUpdateCommand, QuoteDetailDTO>
    {
        protected readonly IQuoteDetail _quoteDetail;

        public QuoteDetailUpdateHandler(IQuoteDetail quoteDetail)
        {
            _quoteDetail = quoteDetail;
        }
        public async Task<QuoteDetailDTO> Handle(QuoteDetailUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _quoteDetail.Update(request.reqDTO);
        }
    }
}
