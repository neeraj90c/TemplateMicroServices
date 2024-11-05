using Microsoft.AspNetCore.Http.Features;

namespace QuotMaster.DTO
{
    public class QuoteMasterSuggestionsResponse
    {
        public int SugId { get; set; }
        public int TTId { get; set; }
        public int ItemId { get; set; }
        public string IName { get; set; }
        public string IDesc { get; set; }
        public decimal MOQ { get; set; }
        public decimal MRP { get; set; }
    }

    public class QuoteSuggestionList
    {
        public IEnumerable<QuoteMasterSuggestionsResponse> Items { get; set; }
    }
}
