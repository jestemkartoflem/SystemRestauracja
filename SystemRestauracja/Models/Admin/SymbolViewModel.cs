using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SystemRestauracja.Data;

namespace SystemRestauracja.Models.Admin
{
    public class SymbolViewModel
    {
        [Required]
        public string SymbolName { get; set; }
        [Required]
        public string SymbolFontId { get; set; }
        [Required]
        public string SymbolColor { get; set; }
    }
}
