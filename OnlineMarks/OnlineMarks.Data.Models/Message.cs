using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineMarks.Data.Models
{
    public class Message
    {   
        public Guid Id {get; set;}
        public string Content {get; set;}
        public DateTime TimeSent {get; set;}
        public User Sender {get; set;}
        public User Receiver {get; set;}
    }
}
