using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MichaelPavichFinal.Models;
using MichaelPavichFinal.Models.DomainModels;
using MichaelPavichFinal.Models.Grid;

namespace MichaelPavichFinal.Controllers
{
    public class ProductsController : Controller
    {

        private OfficeProductUnitOfWork data { get; set; }
        public ProductsController(OfficeProductContext ctx) => data = new OfficeProductUnitOfWork(ctx);

        public IActionResult List(OfficeProductGridDTO values)
        {
            var builder = new OfficeProductsGridBuilder(HttpContext.Session, values,
                defaultSortField: nameof(OfficeProduct.Name));

            var options = new OfficeProductQueryOptions
            {
                Include = "Type",
                OrderByDirection = builder.CurrentRoute.SortDirection,
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize
            };
            options.SortFilter(builder);

            var vm = new OfficeProductListViewModel()
            {
                Products = data.Products.List(options),
                ProductTypes = data.Types.List(new QueryOptions<ProductType>
                {
                    OrderBy = g => g.Name
                }),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.Products.Count)
            };

            return View(vm);
        }

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

        public ViewResult Details(int id)
        {
            var book = data.Products.Get(new QueryOptions<OfficeProduct>
            {
                Include = "Type",
                Where = b => b.OfficeProductId == id
            });
            return View(book);
        }
    }
}
