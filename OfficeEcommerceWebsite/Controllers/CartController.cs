using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeEcommerceWebsite.Models;

namespace OfficeEcommerceWebsite.Controllers
{
    /// <summary>
    ///     Defines the CartController class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Authorize]
    public class CartController : Controller
    {
        #region Properties

        private Repository<OfficeProduct> Data { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="CartController" /> class.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        public CartController(OfficeProductContext ctx)
        {
            this.Data = new Repository<OfficeProduct>(ctx);
        }

        #endregion

        #region Methods

        private Cart getCart()
        {
            var cart = new Cart(HttpContext);
            cart.Load(this.Data);
            return cart;
        }

        /// <summary>
        ///     Gets the index page
        /// </summary>
        /// <returns>the index view</returns>
        public ViewResult Index()
        {
            var cart = this.getCart();
            var builder = new OfficeProductsGridBuilder(HttpContext.Session);

            var vm = new CartViewModel {
                List = cart.List,
                Subtotal = cart.Subtotal,
                BookGridRoute = builder.CurrentRoute
            };
            return View(vm);
        }

        /// <summary>
        ///     Adds the product to the cart
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>the products list view</returns>
        [HttpPost]
        public RedirectToActionResult Add(int id)
        {
            var product = this.Data.Get(new QueryOptions<OfficeProduct> {
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
                var item = new CartItem {
                    Product = dto,
                    Quantity = 1
                };

                var cart = this.getCart();
                cart.Add(item);
                cart.Save();

                TempData["message"] = $"{product.Name} added to cart";
            }

            var builder = new OfficeProductsGridBuilder(HttpContext.Session);
            return RedirectToAction("List", "Products", builder.CurrentRoute);
        }

        /// <summary>
        ///     Removes the cart item from the cart.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>the index view</returns>
        [HttpPost]
        public RedirectToActionResult Remove(int id)
        {
            var cart = this.getCart();
            var item = cart.GetById(id);
            cart.Remove(item);
            cart.Save();

            TempData["message"] = $"{item.Product.Name} removed from cart.";
            return RedirectToAction("Index");
        }

        /// <summary>
        ///     Clears all cart items
        /// </summary>
        /// <returns>the index view</returns>
        [HttpPost]
        public RedirectToActionResult Clear()
        {
            var cart = this.getCart();
            cart.Clear();
            cart.Save();

            TempData["message"] = "Cart cleared.";
            return RedirectToAction("Index");
        }

        /// <summary>
        ///     Gets the edit cart item view
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>the index view</returns>
        public IActionResult Edit(int id)
        {
            var cart = this.getCart();
            var item = cart.GetById(id);
            if (item == null)
            {
                TempData["message"] = "Unable to locate cart item";
                return RedirectToAction("Index");
            }

            return View(item);
        }

        /// <summary>
        ///     Edits the specified cart item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>the index view</returns>
        [HttpPost]
        public RedirectToActionResult Edit(CartItem item)
        {
            var cart = this.getCart();
            cart.Edit(item);
            cart.Save();

            TempData["message"] = $"{item.Product.Name} updated";
            return RedirectToAction("Index");
        }

        /// <summary>
        ///     Gets the checkout page
        /// </summary>
        /// <returns>the checkout view</returns>
        public ViewResult Checkout()
        {
            return View();
        }

        #endregion
    }
}