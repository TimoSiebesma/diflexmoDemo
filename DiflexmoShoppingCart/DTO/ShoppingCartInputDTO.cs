using DiflexmoShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiflexmoShoppingCart.DTO
{
    public class ShoppingCartInputDTO
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public virtual List<ProductShoppingCart> ProductShoppingCarts { get; set; }
    }
}
