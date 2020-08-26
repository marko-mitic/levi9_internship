using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using OnlineMarks.Interfaces.Services;
using System.Security.Claims;

namespace OnlineMarks.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {   

        private IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService ?? throw new ArgumentNullException($"{nameof(IMessageService)} cannot be null!");
        }

        [HttpGet]
        public IActionResult Get(string receiverName, int pageNumber, int pageSize)
        {   
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var senderName = identity.Name;
            
            if (senderName == null)
            {
                return NotFound("Identity not found!");
            }
            var paginatedMessages = _messageService.GetMessagesPageable(senderName, receiverName, pageNumber, pageSize);
            
            return Ok(paginatedMessages);
        }
    }
}
