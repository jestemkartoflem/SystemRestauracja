using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SystemRestauracja.Data;

namespace SystemRestauracja.Models.Admin
{
    public class DanieViewModel
    {
        [Required]
        public string DanieName { get; set; }
        public string Description { get; set; }
        //public string DescriptionLong { get; set; }
        public bool IsVegan { get; set; }
        public bool IsSpicy { get; set; }
        public bool IsPublic { get; set; }
        public decimal Price { get; set; }
        public List<Kategoria> CategoryChoice { get; set; }
        [Required]
        public Guid SelectedCategoryId { get; set; }
        public List<Symbol> SymbolList { get; set; }
        public List<Guid> WybraneIdSymboli { get; set; }
    }
}
