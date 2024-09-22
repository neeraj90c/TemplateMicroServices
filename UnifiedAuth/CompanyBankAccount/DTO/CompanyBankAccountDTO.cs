namespace CompanyBankAccount.DTO
{
    public class CompanyBankAccountDTO
    {
        public int AccountId { get; set; }
        public int CompanyId { get; set; }
        public int BankId { get; set; }
        public string? AccountHolderName { get; set; }
        public string? AccountNo { get; set; }
        public string? AccountType { get; set; }
        public string? AccountURN { get; set; }
        public string? RefAccountNo { get; set; }
        public string? AccountDescription { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ActionUser { get; set; }
    }
    public class CompanyBankAccountList
    {
        public IEnumerable<CompanyBankAccountDTO> Items { get; set; }
    }
}
