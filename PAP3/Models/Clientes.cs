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
    [Table("Clientes")]
    public class Cliente
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
        public string Email { get; set; }

        [StringLength(3)]
        [Display(Name = "Idioma")]
        public string Idioma { get; set; }

        [Required]
        [Phone]
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

        public List<Pedido> Pedidos { get; set; }



    }
}
