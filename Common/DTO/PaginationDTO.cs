using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    /// <summary>
    /// This Model is used For Pagination
    /// </summary>
    public class PaginationDTO
    {
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int RowNum { get; set; }
        public int TotalCount { get; set; }
        public string? WhereClause { get; set; }
        public string? OrderByClause { get; set; }
    }
}
