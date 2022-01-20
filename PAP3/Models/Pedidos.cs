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
        [Display(Name = "Total da Fatura")]
        public decimal Total { get; set; }

        [Required]
        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }

    }
}
