using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public interface IPaginationHelper
{
    IEnumerable<T> Paginate<T>(IEnumerable<T> data, int PageNumber, int PageSize);
}