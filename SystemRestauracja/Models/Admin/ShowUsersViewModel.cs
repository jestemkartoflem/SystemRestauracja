﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemRestauracja.Data;

namespace SystemRestauracja.Models.Admin
{
    public class ShowUsersViewModel
    {
        public List<UserAccount> Users { get; set; }
    }
}
