using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemRestauracja.Data;

namespace SystemRestauracja.Models.Admin
{
    public class ShowCategoriesViewModel
    {
        public List<Kategoria> Kategorie { get; set; }
        public List<Kategoria> Podkategorie { get; set; }
        public int currentPage;
        public int pageSize;
        public int totalPages;
    }
}
