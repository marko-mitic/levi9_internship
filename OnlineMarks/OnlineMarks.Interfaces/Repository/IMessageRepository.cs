using OnlineMarks.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Interfaces.Repository
{
    public interface IMessageRepository
    {
        Message GetById(Guid id);
    }
}
