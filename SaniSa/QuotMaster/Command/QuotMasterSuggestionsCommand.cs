using MediatR;
using QuotMaster.DTO;
using QuotMaster.Interface;

namespace QuotMaster.Command
{
    public class QuotMasterSuggestionsCommand : IRequest<QuoteSuggestionList>
    {
        public QuoteMasterSuggestionsReq reqDTO { get; set; }
    }
    internal class QuotMasterSuggestionsCommandHandler : IRequestHandler<QuotMasterSuggestionsCommand, QuoteSuggestionList>
    {
        protected readonly IQuotMaster _quotMaster;
        public QuotMasterSuggestionsCommandHandler(IQuotMaster quotMaster)
        {
            _quotMaster = quotMaster;
        }
        public async Task<QuoteSuggestionList> Handle(QuotMasterSuggestionsCommand request, CancellationToken cancellationToken)
        {
            return await _quotMaster.Suggestions(request.reqDTO);
        }
    }
}
