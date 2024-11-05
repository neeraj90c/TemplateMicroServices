namespace QuotMaster.DTO
{
    public class QuoteMasterSuggestionsReq
    {
        public decimal BudgetPrice {  get; set; }
        public int EventId { get; set; }
        public int NumberOfItems { get; set; }
        public int NumberOfSuggestions { get; set; }
    }
}
