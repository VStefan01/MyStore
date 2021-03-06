﻿using MyStore.Models;
using MyStore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyStore.Data;

namespace MyStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            var cart = new ShoppingCart(HttpContext);
            var products = cart.GetCartProducts();

            //a view model to pass products and the total
            return View(new ShoppingCartViewModel {
                Products = products,
                Total = CalculateCart(products)
            });
        }

        public ActionResult AddToCart (int id)       //add a product to cart
        {
            var cart = new ShoppingCart(HttpContext);
            cart.AddProduct(id);

            return RedirectToAction("index");
        }

        public ActionResult RemoveFromCart (int id)      //remove a product from cart
        {
            var cart = new ShoppingCart(HttpContext);
            cart.RemoveProduct(id);

            return RedirectToAction("index");
        }

        private decimal CalculateCart(IEnumerable<CartProduct> products)  //calculate the total price
        {
            decimal total = 0;

            foreach (var product in products)
            {
                total += (product.Product.Price * product.Quantity);
            }

            return total;

        }

        [HttpGet]
        public ActionResult Checkout()             //the form for order confirmation
        {
            return View();
        }

        [HttpPost]
        public ActionResult Checkout(CheckoutViewModel checkoutModel)
        {
            if (!ModelState.IsValid)
            {
                return View(checkoutModel);
            }

            //if we have a valid model we initialize the cart and save into database the order
            var cart = new ShoppingCart(HttpContext);
            cart.Checkout(checkoutModel);

            return RedirectToAction("Complete");
        }

        public ActionResult Complete()
        {
            return View();
        }


    }
}


