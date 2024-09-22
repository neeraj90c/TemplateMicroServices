namespace CategoryDetail.DTO
{
    public class CategoryDetailDTO
    {
        public int DetailId { get; set; }         
        public int CategoryId { get; set; }       
        public int ItemId { get; set; }           
        public int IsActive { get; set; }         
        public int IsDeleted { get; set; }        
        public string CreatedBy { get; set; }     
        public DateTime CreatedOn { get; set; }   
        public string ModifiedBy { get; set; }    
        public DateTime ModifiedOn { get; set; }  
    }

    public class CategoryDetailList
    {
        public IEnumerable<CategoryDetailDTO> Items { get; set; }
    }

}
