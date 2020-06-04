using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemRestauracja.Data;

namespace SystemRestauracja.Models
{
    public class OrderMenuViewModel
    {
        public List<Kategoria> CategoryList { get; set; }
        public List<Kategoria> ChildrenCategories { get; set; }
        public List<Danie> Dania { get; set; }
        public List<Zestaw> Zestawy { get; set; }
        public List<Zamowienie> Zamowienia { get; set; }
        public List<DanieDoZestawu> DaniaDoZestawow { get; set; }
        public string Notatka { get; set; }
        public Guid SelectedZamowienieId { get; set; }
        public int SelectedZamowienieNr { get; set; }
        public decimal SelectedZamowieniePrice { get; set; }
        public Guid SelectedZestawId { get; set; }
        public decimal SelectedZestawPrice { get; set; }
        public List<Symbol> Symbole { get; set; }
        public List<SymbolDoDania> SymboleDoDania { get; set; }
    }
}
