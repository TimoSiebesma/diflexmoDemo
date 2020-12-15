using AutoMapper;
using DiflexmoShoppingCart.Models;
using DiflexmoShoppingCart.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiflexmoCart.Profiles
{
    public class QuizzishProfile : Profile
    {
        public QuizzishProfile()
        {
            CreateMap<Product, ProductOutputDTO>();
            CreateMap<ProductInputDTO, Product>();
            CreateMap<Product, ProductInputDTO>();

            CreateMap<ShoppingCart, ShoppingCartOutputDTO>();
            CreateMap<ShoppingCartInputDTO, ShoppingCart>();
            CreateMap<ShoppingCart, ShoppingCartInputDTO>();
        }
    }
}
