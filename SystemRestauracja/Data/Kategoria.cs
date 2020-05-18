using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemRestauracja.Data
{
    public class Kategoria : DbObject
    {
        public string Nazwa { get; set; }
        public string NormalizedName { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public Kategoria ParentCategory { get; set; }
        public bool HasChildren { get; set; }
    }
}
