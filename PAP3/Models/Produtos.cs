﻿using Microsoft.AspNetCore.Mvc;
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
        [Display(Name = "Preço por Unidade")]
        public decimal PrecoUnidade { get; set; }

        [Required]
        [Display(Name = "Unidade em stock")]
        public int stock { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 11)]
        [Display(Name = "Descontinuado")]
        public bool Descontinuado { get; set; }

        public string Imagem { get; set; }



    }
}
