using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemRestauracja.Data;

namespace SystemRestauracja.Models
{
    public class OrderMenuViewModel
    {
        public List<Kategoria> CategoryList;
        public List<Kategoria> ChildrenCategories;
        public List<Danie> Dania;
        public List<Zestaw> Zestawy;
        public List<Zamowienie> Zamowienia;
        public List<DanieDoZestawu> DaniaDoZestawow;
        public string Notatka;
        public Guid SelectedZamowienieId;
        public int SelectedZamowienieNr;
        public decimal SelectedZamowieniePrice;
        public Guid SelectedZestawId;
        public decimal SelectedZestawPrice;
        public List<Symbol> Symbole;
        public List<SymbolDoDania> SymboleDoDania;
    }
}
