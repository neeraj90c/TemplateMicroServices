namespace BankMaster.DTO
{
    public class BankMasterCreateRequestDTO
    {
        public string? BankName { get; set; }
        public string? BankBranch { get; set; }
        public string? BankAddress { get; set; }
        public string? IFSCCode { get; set; }
        public string? Remarks { get; set; }
        public string? ActionUser { get; set; }
    }
}
