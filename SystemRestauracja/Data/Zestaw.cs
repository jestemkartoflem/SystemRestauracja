using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemRestauracja.Data
{
    public class Zestaw : DbObject
    {
        public StatusZestaw StatusZestawu { get; set; }
        public string NormalizedName { get; set; }
        public decimal CenaZestawu { get; set; }
        public Zamowienie Zamowienie { get; set; }
        public Guid ZamowienieId { get; set; }
        public UserAccount Zamawiajacy { get; set; }
        public string ZamawiajacyId { get; set; }
    }
}
