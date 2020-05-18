using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SystemRestauracja.Data;

namespace SystemRestauracja.Models.Admin
{
    public class CategoryViewModel
    {
        [Required]
        public string CatName { get; set; }
        public bool HasParentCategory { get; set; }
        public List<Kategoria> ParentCategoryChoice { get; set; }
        public Guid SelectedCategoryId { get; set; }
    }
}
