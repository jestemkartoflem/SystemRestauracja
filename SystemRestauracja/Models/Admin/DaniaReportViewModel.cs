using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SystemRestauracja.Data;

namespace SystemRestauracja.Models.Admin
{
    public class DaniaReportViewModel
    {
        public List<Danie> DaniaList { get; set; }
        [Required(ErrorMessage = "Wymagane pole")]
        public DateTime DataOd { get; set; }
        [Required(ErrorMessage = "Wymagane pole")]
        public DateTime DataDo { get; set; }
    }
}
