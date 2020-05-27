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
        [Required(ErrorMessage ="Nazwa potrawy jest wymagana")]
        public string DanieName { get; set; }
        public string Description { get; set; }
        //public string DescriptionLong { get; set; }
        public bool IsPublic { get; set; }

        [Required(ErrorMessage ="Cena jest wymagana")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Nieprawidłowa cena")]
        [Range(0.01, 999999999, ErrorMessage = "Cena musi być większa od 0")]
        public decimal Price { get; set; }
        public List<Kategoria> CategoryChoice { get; set; }

        [Required(ErrorMessage ="Należy wybrać kategorię")]
        public Guid SelectedCategoryId { get; set; }
        public List<Symbol> SymbolList { get; set; }
        public List<Guid> WybraneIdSymboli { get; set; }
    }
}
