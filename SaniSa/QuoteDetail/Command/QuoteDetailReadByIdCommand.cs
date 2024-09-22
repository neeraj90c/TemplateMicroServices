using MediatR;
using QuoteDetail.DTO;
using QuoteDetail.Interface;

namespace QuoteDetail.Command
{
    public class QuoteDetailReadByIdCommand : IRequest<QuoteDetailDTO>
    {
        public QuoteDetailReadByIdRequestDTO reqDTO { get; set; }
    }
    internal class QuoteDetailReadByIdHandler : IRequestHandler<QuoteDetailReadByIdCommand, QuoteDetailDTO>
    {
        protected readonly IQuoteDetail _quoteDetail;

        public QuoteDetailReadByIdHandler(IQuoteDetail quoteDetail)
        {
            _quoteDetail = quoteDetail;
        }
        public async Task<QuoteDetailDTO> Handle(QuoteDetailReadByIdCommand request, CancellationToken cancellationToken)
        {
            return await _quoteDetail.ReadById(request.reqDTO);
        }
    }
}
