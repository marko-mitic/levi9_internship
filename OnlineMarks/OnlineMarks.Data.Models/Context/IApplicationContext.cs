using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Data.Models.Context
{
    public interface IApplicationContext
    {
        void SaveChanges();
        void CommitTransaction();
        void DisposeTransaction();
    }
}
