using Common.DTO;

namespace BankMaster.DTO
{
    public class BankMasterDTO: PaginationDTO
    {
        public int BankId { get; set; }
        public string? BankName { get; set; }
        public string? BankBranch { get; set; }
        public string? BankAddress { get; set; }
        public string? IFSCCode { get; set; }
        public string? Remarks { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ActionUser { get; set; }
    }
    public class BankMasterList
    {
        public IEnumerable<BankMasterDTO> Items { get; set; }
    }
}
