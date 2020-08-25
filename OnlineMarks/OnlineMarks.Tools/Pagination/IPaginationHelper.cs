using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace OnlineMarks.Tools.Pagination 
{
    public interface IPaginationHelper
    {
        IEnumerable<T> Paginate<T>(IEnumerable<T> data, int PageNumber, int PageSize);
    }
}
