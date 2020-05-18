using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemRestauracja.Data
{
    public class SymbolDoDania : DbObject
    {
        public Danie Danie { get; set; }
        public Guid DanieId { get; set; }
        public Symbol Symbol { get; set; }
        public Guid SymbolId { get; set; }
    }
}
