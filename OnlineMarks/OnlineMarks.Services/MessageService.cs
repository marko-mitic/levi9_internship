using System;
using System.Collections.Generic;
using OnlineMarks.Interfaces.Repository;
using OnlineMarks.Interfaces.Services;
using OnlineMarks.Data.Models;
using OnlineMarks.Tools.Pagination;

namespace OnlineMarks.Services {
    public class MessageService : IMessageService
    {
        private IMessageRepository _messageRepository;
        private IPaginationHelper _paginationHelper;

        public MessageService(IMessageRepository messageRepository, IPaginationHelper paginationHelper){
            _messageRepository = messageRepository ?? throw new ArgumentNullException($"{nameof(IMessageRepository)} cannot be null!");
            _paginationHelper = paginationHelper ?? throw new ArgumentNullException($"{nameof(IPaginationHelper)} cannot be null!");
        }

        public IEnumerable<Message> GetMessagesPageable(string senderName, string receiverName, int pageNumber, int pageSize){
            var messages =  _messageRepository.GetByNames(senderName, receiverName);
            return _paginationHelper.Paginate(messages, pageNumber, pageSize);
        }
    }

}