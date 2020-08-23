using OnlineMarks.Data.Models;
using OnlineMarks.Data.Models.Context;
using OnlineMarks.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        
    }
}
