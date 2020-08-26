using System;
using System.Collections.Generic;
using System.Text;
using OnlineMarks.Data.Models;

namespace OnlineMarks.Interfaces.Services
{
    public interface IMessageService
    {
        IEnumerable<Message> GetMessagesPageable(string senderName, string receiverName, int pageNumber, int pageSize);
    }

}