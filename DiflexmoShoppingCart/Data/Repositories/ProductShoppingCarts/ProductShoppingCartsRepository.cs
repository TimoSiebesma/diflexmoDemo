using AutoMapper;
using DeflexmoCart.Data.DbContexts;
using DiflexmoShoppingCart.Models;
using Microsoft.Extensions.Caching.Memory;
namespace DeflexmoCart.Data.Repositories.Products
{
    public class ProductShoppingCartsRepository : Repository<ProductShoppingCart>, IProductShoppingCartsRepository
    {
        public ProductShoppingCartsRepository(DiflexmoCartDb context) : base(context)
        {

        }
    }
}
