using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiflexmoShoppingCart.DTO
{
    public class ProductOutputDTO
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:F}", ApplyFormatInEditMode = true)]
        public double Price { get; set; }
    }
}
