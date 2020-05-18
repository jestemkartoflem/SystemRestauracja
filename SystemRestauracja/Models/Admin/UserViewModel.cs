using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SystemRestauracja.Data;

namespace SystemRestauracja.Models.Admin
{
    public class UserViewModel
    {
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }
        public StatusStolik Status { get; set; }
    }
}
