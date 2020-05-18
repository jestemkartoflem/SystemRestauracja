using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemRestauracja.Data
{
    public class DanieDoZestawu : DbObject
    {
        public Zestaw Zestaw { get; set; }
        public Guid ZestawId { get; set; }
        public Danie Danie { get; set; }
        public Guid DanieId { get; set; }

        public UserAccount User { get; set; }
        public string UserId { get; set; }
        public string Notatka { get; set; }
    }
}
