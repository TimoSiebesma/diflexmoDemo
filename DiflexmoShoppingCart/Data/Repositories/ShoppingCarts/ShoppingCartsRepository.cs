using AutoMapper;
using DeflexmoCart.Data.DbContexts;
using DiflexmoShoppingCart.Models;
using Microsoft.Extensions.Caching.Memory;
namespace DeflexmoCart.Data.Repositories.Products
{
    public class ShoppingCartsRepository : Repository<ShoppingCart>, IShoppingCartsRepository
    {
        public ShoppingCartsRepository(DiflexmoCartDb context) : base(context)
        {

        }
    }
}
