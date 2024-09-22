namespace CategoryMaster.DTO
{
    public class CategoryMasterDTO
    {
        public int CategoryId { get; set; }         
        public string CCode { get; set; }           
        public string CName { get; set; }           
        public string CDesc { get; set; }           
        public int CompanyId { get; set; }         
        public int IsActive { get; set; }           
        public int IsDeleted { get; set; }          
        public string CreatedBy { get; set; }       
        public DateTime CreatedOn { get; set; }     
        public string ModifiedBy { get; set; }      
        public DateTime ModifiedOn { get; set; }    
    }

    public class CategoryMasterList
    {
        public IEnumerable<CategoryMasterDTO> Items { get; set; }
    }
}
