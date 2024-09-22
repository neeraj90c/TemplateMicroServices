using System.ComponentModel.Design;
using System.Xml.Linq;

namespace CategoryMaster.DTO
{
    public class CategoryMasterCreateRequestDTO
    {
        public string CCode { get; set; }
        public string CName { get; set; }
        public string CDesc { get; set; }
        public int CompanyId { get; set; }
        public string ActionUser { get; set; }

    }
}
