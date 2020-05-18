using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SystemRestauracja.Data
{
    public class UserAccount : IdentityUser
    {
        public StatusStolik StatusStolika { get; set; }
        public string IsActive { get; set; }

    }
}
