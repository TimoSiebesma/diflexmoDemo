using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DeflexmoCart.Data.UnitOfWork;
using DiflexmoShoppingCart.DTO;
using DiflexmoShoppingCart.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiflexmoShoppingCart.Controllers
{
    public class ShoppingCartsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShoppingCartsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index(string filter = "")
        {
            DealWithShoppingCartExceptions();

            if (filter == null) filter = "";

            var carts = _unitOfWork.ShoppingCarts.GetAll().Where(x => x.Alias.Contains(filter));

            var output = _mapper.Map<List<ShoppingCartOutputDTO>>(carts);

            return View(output);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(ShoppingCartInputDTO input)
        {
            if (ModelState.IsValid)
            {
                var shoppingCart = _mapper.Map<ShoppingCart>(input);
                _unitOfWork.ShoppingCarts.Add(shoppingCart);
                _unitOfWork.Complete();

                return RedirectToAction("Index");
            }

            return View(input);
        }

        public IActionResult Details(int id) 
        {
            var shoppingCart = _unitOfWork.ShoppingCarts.GetById(id);

            var output = _mapper.Map<ShoppingCartOutputDTO>(shoppingCart);

            return View(output);
        }

        public IActionResult Edit(int id)
        {
            var shoppingCart = _unitOfWork.ShoppingCarts.GetById(id);

            var output = _mapper.Map<ShoppingCartInputDTO>(shoppingCart);

            return View(output);
        }

        [HttpPost]
        public IActionResult Edit(int id, ShoppingCartInputDTO input)
        {
            if (ModelState.IsValid)
            {
                if (input.ProductShoppingCarts != null)
                {
                    foreach (var productShoppingCart in input.ProductShoppingCarts)
                    {
                        var pscart = _unitOfWork.ProductShoppingCarts.GetById(productShoppingCart.Id);
                        pscart.Amount = productShoppingCart.Amount;

                        if (pscart.Amount == 0)
                        {
                            _unitOfWork.ProductShoppingCarts.Remove(pscart);
                        }
                    }
                }

                var cart = _unitOfWork.ShoppingCarts.GetById(input.Id);
                cart.Alias = input.Alias;
                _unitOfWork.Complete();

                return RedirectToAction("Index");
            }

            return View(input);
        }

        
        public IActionResult Delete(ShoppingCartInputDTO input)
        {
            if (ModelState.IsValid)
            {
                var shoppingCart = _mapper.Map<ShoppingCart>(input);
                _unitOfWork.ShoppingCarts.Remove(shoppingCart);
                _unitOfWork.Complete();
                DealWithShoppingCartExceptions();

                return RedirectToAction("Index");
            }

            return View(input);
        }

        public IActionResult SetCurrent(int id)
        {
            var shoppingCart = _unitOfWork.ShoppingCarts.GetById(id);

            if (shoppingCart != null)
            {
                HttpContext.Session.SetString("CurrentShoppingCart", $"{id}");
            }

            return RedirectToAction("Index");
        }

        public IActionResult Add(int id)
        {
            var sessionCart = HttpContext.Session.GetString("CurrentShoppingCart");

            if (sessionCart != null)
            {
                ShoppingCart shoppingCart = _unitOfWork.ShoppingCarts.GetById(int.Parse(sessionCart));
                Product product = _unitOfWork.Products.GetById(id);
                ProductShoppingCart productShoppingCart = _unitOfWork.ProductShoppingCarts.GetAll().FirstOrDefault(p => p.Product.Id == product.Id);

                if (productShoppingCart != null)
                {
                    productShoppingCart.Amount++;
                }
                else
                {
                    shoppingCart.ProductShoppingCarts.Add(
                        new ProductShoppingCart { Product = product, ShoppingCart = shoppingCart, Amount = 1 });
                }
                _unitOfWork.Complete();
            }

            return RedirectToAction("Index");
        }
        private void DealWithShoppingCartExceptions()
        {
            if (HttpContext.Session.GetString("CurrentShoppingCart") == null)
            {
                HttpContext.Session.SetString("CurrentShoppingCart", $"{_unitOfWork.ShoppingCarts.GetAll().LastOrDefault().Id}");
            }

            if (_unitOfWork.ShoppingCarts.GetById(int.Parse(HttpContext.Session.GetString("CurrentShoppingCart"))) == null)
            {
                _unitOfWork.ShoppingCarts.Add(new ShoppingCart { Alias = "Default Shopping Cart" });
                _unitOfWork.Complete();
                HttpContext.Session.SetString("CurrentShoppingCart", $"{_unitOfWork.ShoppingCarts.GetAll().LastOrDefault().Id}");
            }
        }

    }
}
