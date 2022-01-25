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
    [Table("Pedidos")]
    public class Pedido
    {
        [Key]
        public int NumPedido { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Data de Pedido")]
        public DateTime DataPedido { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Total { get; set; }

        [Required]
        [ForeignKey("Clientes")]
        public int ClienteId { get; set; }

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

        public DetalhesPedido DetalhesPedido { get; set; }
        public Cliente Cliente { get; set; }
    }
}
