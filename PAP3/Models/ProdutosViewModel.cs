using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAP3.Models
{
    public class ProdutosViewModel
    {
        [Required]
        [StringLength(256, MinimumLength = 5)]
        public string NomeProduto { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Preço Unitário")]
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

        public IFormFile ProdImage { get; set; }

        [StringLength(256, MinimumLength = 5)]
        public string Description { get; set; }
    }
}
