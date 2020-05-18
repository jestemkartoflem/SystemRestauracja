using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemRestauracja.Data
{
    public class Danie : DbObject
    {
        public string Nazwa { get; set; }
        public string NormalizedNazwa { get; set; }
        public string OpisDania { get; set; }
        //public string OpisDaniaDlugi { get; set; }
        //public bool CzyWeganskie { get; set; }
        //public bool CzyOstre { get; set; }
        public bool CzyUpublicznione { get; set; }
        public decimal Cena { get; set; }
        public Kategoria Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}
