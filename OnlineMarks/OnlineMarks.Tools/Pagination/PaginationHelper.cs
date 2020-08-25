using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace OnlineMarks.Tools.Pagination 
{
    public class PaginationHelper : IPaginationHelper {
        public IEnumerable<T> Paginate<T>(IEnumerable<T> data, int PageNumber, int PageSize)
        {
            return data.Skip((PageNumber - 1) * PageSize).Take(PageSize);
        }
    }
}
