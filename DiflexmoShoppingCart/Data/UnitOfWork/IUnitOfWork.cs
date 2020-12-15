using DeflexmoCart.Data.Repositories.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeflexmoCart.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();

        IProductsRepository Products { get; }
        IShoppingCartsRepository ShoppingCarts { get; }
        IProductShoppingCartsRepository ProductShoppingCarts { get; }
    }
}
