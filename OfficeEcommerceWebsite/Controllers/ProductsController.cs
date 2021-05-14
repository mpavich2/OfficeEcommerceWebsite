using Microsoft.AspNetCore.Mvc;
using OfficeEcommerceWebsite.Models;

namespace OfficeEcommerceWebsite.Controllers
{
    /// <summary>
    ///     Defines the ProductsController class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class ProductsController : Controller
    {
        #region Properties

        private OfficeProductUnitOfWork Data { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProductsController" /> class.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        public ProductsController(OfficeProductContext ctx)
        {
            this.Data = new OfficeProductUnitOfWork(ctx);
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Gets the list of products.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>the list view</returns>
        public IActionResult List(OfficeProductGridDTO values)
        {
            var builder = new OfficeProductsGridBuilder(HttpContext.Session, values,
                nameof(OfficeProduct.Name));

            var options = new OfficeProductQueryOptions {
                Include = "Type",
                OrderByDirection = builder.CurrentRoute.SortDirection,
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize
            };
            options.SortFilter(builder);

            var vm = new OfficeProductListViewModel {
                Products = this.Data.Products.List(options),
                ProductTypes = this.Data.Types.List(new QueryOptions<ProductType> {
                    OrderBy = g => g.Name
                }),
                Images = this.Data.Images.List(new QueryOptions<Image>()),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(this.Data.Products.Count)
            };

            return View(vm);
        }

        /// <summary>
        ///     Filters the products.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="clear">if set to <c>true</c> [clear].</param>
        /// <returns>the list view</returns>
        [HttpPost]
        public RedirectToActionResult Filter(string[] filter, bool clear = false)
        {
            var builder = new OfficeProductsGridBuilder(HttpContext.Session);

            if (clear)
            {
                builder.ClearFilterSegments();
            }
            else
            {
                builder.LoadFilterSegments(filter);
            }

            builder.SaveRouteSegments();
            return RedirectToAction("List", builder.CurrentRoute);
        }

        /// <summary>
        ///     Gets the details about the specified product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>the details view</returns>
        public ViewResult Details(int id)
        {
            var product = this.Data.Products.Get(new QueryOptions<OfficeProduct> {
                Include = "Type",
                Where = b => b.OfficeProductId == id
            });
            var image = this.Data.Images.Get(product.ImageId);
            ViewBag.Url = image.Url();
            return View(product);
        }

        #endregion
    }
}