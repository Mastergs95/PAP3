using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PAP3.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 5)]
        public string NomeProduto { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name="Preço Unitário")]
        public decimal PrecoUnidade { get; set; }

        [Required]
        [Display(Name = "Unidade em stock")]
        public int stock { get; set; }

        [Required]
        [Display(Name = "Descontinuado")]
        public bool Descontinuado { get; set; }

        [Required]
        [ForeignKey("Categorias")]
        public int CategoriaId { get; set; }

        public string Imagem { get; set; }

        [StringLength(256, MinimumLength = 5)]
        public string Description { get; set; }


        public List <DetalhesPedido> DetalhesPedido { get; set; }
        public List<ProdutosTag> ProdutosTags { get; set; }

        public Categoria Categoria { get; set; }




    }
}
