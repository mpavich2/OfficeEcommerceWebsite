﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MichaelPavichFinal.Models;
using MichaelPavichFinal.Models.Grid;
using Microsoft.AspNetCore.Authorization;

namespace MichaelPavichFinal.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private Repository<OfficeProduct> data { get; set; }
        public CartController(OfficeProductContext ctx) => data = new Repository<OfficeProduct>(ctx);


        private Cart GetCart()
        {
            var cart = new Cart(HttpContext);
            cart.Load(data);
            return cart;
        }

        public ViewResult Index()
        {
            var cart = GetCart();
            var builder = new OfficeProductsGridBuilder(HttpContext.Session);

            var vm = new CartViewModel
            {
                List = cart.List,
                Subtotal = cart.Subtotal,
                BookGridRoute = builder.CurrentRoute
            };
            return View(vm);
        }

        [HttpPost]
        public RedirectToActionResult Add(int id)
        {
            var product = data.Get(new QueryOptions<OfficeProduct>
            {
                Include = "Type",
                Where = b => b.OfficeProductId == id
            });
            if (product == null)
            {
                TempData["message"] = "Unable to add book to cart.";
            }
            else
            {
                var dto = new OfficeProductDTO();
                dto.Load(product);
                CartItem item = new CartItem
                {
                    Product = dto,
                    Quantity = 1
                };

                Cart cart = GetCart();
                cart.Add(item);
                cart.Save();

                TempData["message"] = $"{product.Name} added to cart";
            }

            var builder = new OfficeProductsGridBuilder(HttpContext.Session);
            return RedirectToAction("List", "Products", builder.CurrentRoute);
        }

        [HttpPost]
        public RedirectToActionResult Remove(int id)
        {
            Cart cart = GetCart();
            CartItem item = cart.GetById(id);
            cart.Remove(item);
            cart.Save();

            TempData["message"] = $"{item.Product.Name} removed from cart.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public RedirectToActionResult Clear()
        {
            Cart cart = GetCart();
            cart.Clear();
            cart.Save();

            TempData["message"] = "Cart cleared.";
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            Cart cart = GetCart();
            CartItem item = cart.GetById(id);
            if (item == null)
            {
                TempData["message"] = "Unable to locate cart item";
                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }
        }

        [HttpPost]
        public RedirectToActionResult Edit(CartItem item)
        {
            Cart cart = GetCart();
            cart.Edit(item);
            cart.Save();

            TempData["message"] = $"{item.Product.Name} updated";
            return RedirectToAction("Index");
        }

        public ViewResult Checkout() => View();
    }
}
