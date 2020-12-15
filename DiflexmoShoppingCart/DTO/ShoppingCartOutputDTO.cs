using DiflexmoShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiflexmoShoppingCart.DTO
{
    public class ShoppingCartOutputDTO
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public virtual List<ProductShoppingCart> ProductShoppingCarts { get; set; }
        [Display(Name = "Amount Of Products")]
        public int AmountOfItems => ProductShoppingCarts == null ? 0 : ProductShoppingCarts.Select(p => p.Amount).Sum();

        [DisplayFormat(DataFormatString = "{0:F}", ApplyFormatInEditMode = true)]
        [Display(Name = "Total Price")]
        public double TotalPrice => ProductShoppingCarts == null ? 0 : ProductShoppingCarts.Select(p => p.Product.Price * p.Amount).Sum();
    }
}
