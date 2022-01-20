using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PAP3.Models
{
    [Table("Endereços")]
    public class Endereço
    {
        [Required]
        [ForeignKey("AspNetUsers")]
        public int IdUser { get; set; }

        [StringLength(256, MinimumLength = 3)]
        [Display(Name = "Localidade")]
        public string Localidade { get; set; }

        [StringLength(256, MinimumLength = 3)]
        [Display(Name = "País")]
        public string Pais { get; set; }

        [Display(Name = "Código-Postal")]
        public int CodPostal { get; set; }



    }
}
