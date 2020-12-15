using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiflexmoShoppingCart.Models
{
    public class ShoppingCart : IHaveId
    {
        [Key]
        public int Id { get; set; }
        public string Alias { get; set; }
        public virtual List<ProductShoppingCart> ProductShoppingCarts { get; set; }
    }
}
