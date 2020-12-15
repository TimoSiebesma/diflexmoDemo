using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DiflexmoShoppingCart.Models;
using DeflexmoCart.Data.UnitOfWork;
using AutoMapper;
using DiflexmoShoppingCart.DTO;
using Microsoft.AspNetCore.Http;

namespace DiflexmoShoppingCart.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            DealWithShoppingCartExceptions();

            var products = _unitOfWork.Products.GetAll();

            var output = _mapper.Map<List<ProductOutputDTO>>(products);

            return View(output);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(ProductInputDTO input)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(input);
                _unitOfWork.Products.Add(product);
                _unitOfWork.Complete();

                return RedirectToAction("Index");
            }

            return View(input);
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
