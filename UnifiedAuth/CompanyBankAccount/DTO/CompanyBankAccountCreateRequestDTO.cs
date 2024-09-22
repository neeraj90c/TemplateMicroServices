﻿namespace CompanyBankAccount.DTO
{
    public class CompanyBankAccountCreateRequestDTO
    {
        public int CompanyId { get; set; }
        public int BankId { get; set; }
        public string? AccountHolderName { get; set; }
        public string? AccountNo { get; set; }
        public string? AccountType { get; set; }
        public string? AccountURN { get; set; }
        public string? RefAccountNo { get; set; }
        public string? AccountDescription { get; set; }
        public string? ActionUser { get; set; }
    }
}
