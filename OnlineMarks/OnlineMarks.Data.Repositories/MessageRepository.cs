using OnlineMarks.Data.Models;
using OnlineMarks.Data.Models.Context;
using OnlineMarks.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineMarks.Data.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationContext _applicationContext;
        public MessageRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public Message GetById(Guid id){
            return _applicationContext.Messages.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Message> GetByNames(string senderName, string receiverName){
            return _applicationContext.Messages.Where(x => x.Sender.Name == senderName || x.Receiver.Name == receiverName).OrderBy(x => x.TimeSent);
        }

        public void Add(Message message)
        {
            _applicationContext.Messages.Add(message);
            _applicationContext.SaveChanges();
        }
    }
}
