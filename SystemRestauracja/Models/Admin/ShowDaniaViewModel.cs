using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemRestauracja.Data;

namespace SystemRestauracja.Models.Admin
{
    public class ShowDaniaViewModel
    {
        public List<Danie> Dania { get; set; }
        public List<Kategoria> Kategorie { get; set; }
        public List<SymbolDoDania> SymboleDoDania { get; set; }
        public List<Symbol> Symbole { get; set; }

        public int currentPage { get; set; }
        public int pageSize { get; set; }
        public int totalPages { get; set; }
    }
}
