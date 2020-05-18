using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SystemRestauracja.Data
{
    public class DbObject
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DeleteDate { get; set; }
        //public string DeletedBy { get; set; }
    }
}
