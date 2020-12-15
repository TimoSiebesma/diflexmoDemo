using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiflexmoShoppingCart.Models
{
    public class Product : IHaveId
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public virtual List<ProductShoppingCart> ProductShoppingCarts { get; set; }
    }
}
