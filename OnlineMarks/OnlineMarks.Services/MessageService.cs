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
        private IUserService _userService;



        public MessageService(IMessageRepository messageRepository, IPaginationHelper paginationHelper, IUserService userService){
            _messageRepository = messageRepository ?? throw new ArgumentNullException($"{nameof(IMessageRepository)} cannot be null!");
            _paginationHelper = paginationHelper ?? throw new ArgumentNullException($"{nameof(IPaginationHelper)} cannot be null!");
            _userService = userService ?? throw new ArgumentNullException($"{nameof(IUserService)} cannot be null!");
        }

        public IEnumerable<Message> GetMessagesPageable(string senderName, string receiverName, int pageNumber, int pageSize){
            var messages =  _messageRepository.GetByNames(senderName, receiverName);
            return _paginationHelper.Paginate(messages, pageNumber, pageSize);
        }

        public void Add(string senderName, string receiverName, string content){
            var sender = _userService.Get(senderName);
            var receiver = _userService.Get(receiverName);
            
            if(sender == null || receiver == null)
                throw new KeyNotFoundException();

            Message message = new Message(){Content = content, Receiver = receiver, Sender = sender, TimeSent = DateTime.Now};

            _messageRepository.Add(message);
        }
    }

}