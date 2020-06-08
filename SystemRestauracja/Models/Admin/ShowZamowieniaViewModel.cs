﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemRestauracja.Data;

namespace SystemRestauracja.Models.Admin
{
    public class ShowZamowieniaViewModel
    {
        public List<Zamowienie> Zamowienia { get; set; }

        public int currentPage { get; set; }
        public int pageSize { get; set; }
        public int totalPages { get; set; }
    }
}
