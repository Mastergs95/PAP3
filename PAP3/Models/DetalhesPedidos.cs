using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PAP3.Models
{
    [Table("DetalhesPedidos")]
    public class DetalhesPedido
    {
        [Key]
        public int id { get; set; }

        [Required]
        [ForeignKey("Pedidos")]
        public int PedidoId { get; set; }

        [Required]
        [ForeignKey("Produtos")]
        public int ProdutoId { get; set; }

        [Required]
        public int PreçoUnidade { get; set; }

        [Required]
        [Display(Name = "Quantidade")]
        public Int16 Quantidade { get; set; }

        public Pedido Pedido { get; set; }
        public  Produto Produto { get; set; }

    }
}
