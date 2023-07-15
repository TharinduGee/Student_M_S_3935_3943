using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Models
{
    public class LoginDetails
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; } = string.Empty;
        public string UserType { get; set; } = string.Empty;
    }
}
