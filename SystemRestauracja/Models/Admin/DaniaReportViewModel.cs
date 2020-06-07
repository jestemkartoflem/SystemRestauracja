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
        public List<DanieReportElement> DaniaList { get; set; }
        [Required(ErrorMessage = "Wymagane pole")]
        public DateTime DataOd { get; set; }
        [Required(ErrorMessage = "Wymagane pole")]
        public DateTime DataDo { get; set; }
        //public int currentPage { get; set; }
        //public int pageSize { get; set; }
        //public int totalPages { get; set; }

    }
}
