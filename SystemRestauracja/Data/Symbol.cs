using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemRestauracja.Data
{
    public class Symbol : DbObject
    {
        public string Nazwa { get; set; }
        public string FontId { get; set; }
        public string Color { get; set; }
    }
}
