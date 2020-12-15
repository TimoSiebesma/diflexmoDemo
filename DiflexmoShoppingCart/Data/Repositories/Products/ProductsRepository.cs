using AutoMapper;
using DeflexmoCart.Data.DbContexts;
using DiflexmoShoppingCart.Models;
using Microsoft.Extensions.Caching.Memory;
namespace DeflexmoCart.Data.Repositories.Products
{
    public class ProductRepository : Repository<Product>, IProductsRepository
    {
        public ProductRepository(DiflexmoCartDb context) : base(context)
        {

        }
    }
}
