using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemRestauracja.Data
{
    public class Zamowienie : DbObject
    {
        public StatusZamowienie StatusZamowienie { get; set; }
        public string NormalizedName { get; set; }
        public int ZamowienieNr { get; set; }
        public decimal CenaSuma { get; set; }
        public UserAccount Zamawiajacy { get; set; }
        public string ZamawiajacyId { get; set; }
    }
}
