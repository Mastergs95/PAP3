using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PAP3.Models
{
    [Table("Funcionarios")]
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "NIF")]
        public int Nif { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [StringLength(9, MinimumLength = 8)]
        [Display(Name = "Género")]
        public String Genero { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [StringLength(256, MinimumLength = 3)]
        [Display(Name = "Localidade")]
        public string Localidade { get; set; }

        [StringLength(256, MinimumLength = 3)]
        [Display(Name = "País")]
        public string Pais { get; set; }

        [Display(Name = "Código-Postal")]
        public int CodPostal { get; set; }

        [Display(Name = "Morada")]
        public string Morada { get; set; }


        public string Avatar { get; set; }



    }
}
