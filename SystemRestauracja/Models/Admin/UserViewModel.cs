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
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        [RegularExpression(@"[^\s]+", ErrorMessage ="Nazwa użytkownika jest nieprawidłowa")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        [RegularExpression(@"[^\s]+", ErrorMessage = "Hasło jest nieprawidłowe")]
        public string Password { get; set; }
        public StatusStolik Status { get; set; }
    }
}
