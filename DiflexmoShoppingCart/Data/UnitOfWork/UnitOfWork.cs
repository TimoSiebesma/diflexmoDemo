using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using DeflexmoCart.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeflexmoCart.Data.Repositories.Products;

namespace DeflexmoCart.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DiflexmoCartDb _context;
        public IProductsRepository Products { get; }
        public IShoppingCartsRepository ShoppingCarts { get; }
        public IProductShoppingCartsRepository ProductShoppingCarts { get; }

        public UnitOfWork(DiflexmoCartDb context)
        {
            _context = context;

            Products = new ProductRepository(_context);
            ShoppingCarts = new ShoppingCartsRepository(_context);
            ProductShoppingCarts = new ProductShoppingCartsRepository(_context); 
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        
        public void Dispose() => _context.Dispose();
    }
}