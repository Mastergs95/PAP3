using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PAP3.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 11)]
        [Display(Name = "Email")]
        public int Email { get; set; }

        [StringLength(3)]
        [Display(Name = "Idioma")]
        public string Idioma { get; set; }

        [StringLength(14, MinimumLength = 12)]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        public string Imagem { get; set; }



    }
}
