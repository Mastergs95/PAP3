using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PAP3.Models
{
    [Table("ProdutosTags")]
    public class ProdutosTag
    {
        [Required]
        [ForeignKey("Produtos")]
        public int ProdutoId { get; set; }

        [Required]
        [ForeignKey("CloudTags")]
        public int TagId { get; set; }



    }
}
