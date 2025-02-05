﻿using Microsoft.AspNetCore.Http;
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
        [Required(ErrorMessage = "Nazwa symbolu jest wymagana")]
        public string SymbolName { get; set; }
        [Required(ErrorMessage = "Proszę wybrać obraz reprezentujący symbol")]
        //public string SymbolFontId { get; set; }
        public IFormFile SymbolImage { get; set; }
        //[Required]
        //public string SymbolColor { get; set; }
    }
}
