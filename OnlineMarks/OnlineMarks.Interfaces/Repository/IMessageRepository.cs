using OnlineMarks.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Interfaces.Repository
{
    public interface IMessageRepository
    {
        Message GetById(Guid id);
        IEnumerable<Message> GetByNames(string senderName, string receiverName);
        void Add(Message message);
    }
}
