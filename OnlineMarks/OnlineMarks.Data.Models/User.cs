using Microsoft.AspNetCore.Identity;
using OnlineMarks.Tools.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineMarks.Data.Models
{
    public class User
    {   
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
