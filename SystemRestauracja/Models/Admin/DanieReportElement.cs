using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemRestauracja.Models.Admin
{
    public class DanieReportElement
    {
        public string Nazwa { get; set; }
        public bool CzyUpublicznione { get; set; }
        public decimal Cena { get; set; }
        public string NazwaKategorii { get; set; }
        public int IloscZamowien { get; set; }
        public DateTime DataDodania { get; set; }
    }
}
