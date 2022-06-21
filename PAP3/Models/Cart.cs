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
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public int prodId { get; set; }

        public string prodName { get;set; }

        public int qty { get; set; }

        public int price { get; set; }

    }
}
