using MyStore.Data;
using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MyStore.Common
{
    public class ShoppingCart
    {
        public readonly StoreDatabaseContext _db;
        private readonly string _cartId;

        public ShoppingCart(HttpContextBase context) : this(context, new StoreDatabaseContext())
        {

        }

        public ShoppingCart(HttpContextBase httpContext, StoreDatabaseContext storeContext)
        {
            _db = storeContext;
            _cartId = GetCartId(httpContext);
        }

        public void AddProduct(int id)
        {
            var product = _db.Products.SingleOrDefault(p => p.Id == id);  //get the product from database

            var cartProduct = _db.CartProducts.SingleOrDefault(c => c.ProductId == id && c.CartId == _cartId);  //check to see if we have the product in the cart

            if (cartProduct != null) //if I have already the product
            {
                cartProduct.Quantity++;
            }
            else
            {
                cartProduct = new CartProduct    //create a new CartProduct
                {
                    ProductId = id,
                    Quantity = 1,
                    DateCreated = DateTime.Now,
                    CartId = _cartId,
                };
                _db.CartProducts.Add(cartProduct);
            }
            _db.SaveChanges();
        }

        public int RemoveProduct(int id)
        {
            var cartProduct = _db.CartProducts.SingleOrDefault(c => c.ProductId == id && c.CartId == _cartId); //check to see if we have the product in the cart

            var productCount = 0;


            if (cartProduct.Quantity > 1)     //if we have more than one product in the cart
            {
                cartProduct.Quantity--;
                productCount = cartProduct.Quantity;
            }
            else            //if there is only one product we remove it completely
            {
                _db.CartProducts.Remove(cartProduct);
            }

            _db.SaveChanges();

            return productCount;

        }

        private string GetCartId(HttpContextBase httpContext)  //create a cookie to store an Id and read it when needed
        {
            var cookie = httpContext.Request.Cookies.Get("MyShoppingCart");  //get the cookie
            var cartId = string.Empty;  //initialize an empty id

            //if the cookie does not exist or does not have a value we create a new cookie
            if (cookie == null || string.IsNullOrWhiteSpace(cookie.Value))
            {
                cookie = new HttpCookie("MyShoppingCart");
                cartId = Guid.NewGuid().ToString();

                cookie.Value = cartId;
                cookie.Expires = DateTime.Now.AddDays(1);

                httpContext.Response.Cookies.Add(cookie);  //set the cookie
            }
            else    //if there is a cookie
            {
                cartId = cookie.Value;
            }

            return cartId;
        }


        public IEnumerable<CartProduct> GetCartProducts()
        {
            return _db.CartProducts.Include("Product").Where(c => c.CartId == _cartId).ToArray();
        }

        public void Checkout(CheckoutViewModel checkoutModel)
        {
            var products = GetCartProducts();    //get the products, to build the order detail
            var order = new Order()
            {
                FirstName = checkoutModel.FirstName,
                LastName = checkoutModel.LastName,
                Address = checkoutModel.Address,
                City = checkoutModel.City,
                PostalCode = checkoutModel.PostalCode,
                Country = checkoutModel.Country,
                Phone = checkoutModel.Phone,
                Email = checkoutModel.Email,
                OrderDate = DateTime.Now
            };

            //build the details of the order
            foreach (var product in products)
            {
                var detail = new OrderDetail()
                {
                    ProductId = product.ProductId,
                    UnitPrice = product.Product.Price,
                    Quantity = product.Quantity
                };

                order.Total += (product.Product.Price * product.Quantity);

                order.OrderDetails.Add(detail);
            }

            _db.Orders.Add(order);
            _db.CartProducts.RemoveRange(products); //remove items from database cart

            _db.SaveChanges();

        }

    }
}


