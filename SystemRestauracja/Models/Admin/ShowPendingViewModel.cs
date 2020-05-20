using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemRestauracja.Data;

namespace SystemRestauracja.Models.Admin
{
    public class ShowPendingViewModel
    {
        public List<Zamowienie> Zamowienia { get; set; }
        public List<Zestaw> Zestawy { get; set; }
        public List<DanieDoZestawu> DaniaDoZestawow { get; set; }
        public List<Danie> Dania { get; set; }
        public List<UserAccount> Uzytkownicy { get; set; }

        public int currentPage;
        public int pageSize;
        public int totalPages;
    }
}
