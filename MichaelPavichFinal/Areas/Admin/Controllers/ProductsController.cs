using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MichaelPavichFinal.Models;

namespace MichaelPavichFinal.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private OfficeProductUnitOfWork data { get; set; }
        public ProductsController(OfficeProductContext ctx) => data = new OfficeProductUnitOfWork(ctx);

        public IActionResult Index()
        {
            SearchData search = new SearchData(TempData);
            search.Clear();

            return View();
        }

        [HttpPost]
        public RedirectToActionResult Search(SearchViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var search = new SearchData(TempData)
                {
                    SearchTerm = vm.SearchTerm,
                    Type = vm.Type
                };
                return RedirectToAction("Search");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ViewResult Search()
        {
            var search = new SearchData(TempData);

            if (search.HasSearchTerm)
            {
                var vm = new SearchViewModel
                {
                    SearchTerm = search.SearchTerm
                };

                var options = new QueryOptions<OfficeProduct>
                {
                    Include = "Type"
                };
                if (search.IsProduct)
                {
                    options.Where = b => b.Name.Contains(vm.SearchTerm);
                    vm.Header = $"Search results for product name '{vm.SearchTerm}'";
                }
                if (search.IsType)
                {
                    int index = vm.SearchTerm.LastIndexOf(' ');
                    vm.Header = $"Search results for product type '{vm.SearchTerm}'";
                }
                vm.Products = data.Products.List(options);
                return View("SearchResults", vm);
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet]
        public ViewResult Add(int id) => GetBook(id, "Add");

        [HttpPost]
        public IActionResult Add(OfficeProductViewModel vm)
        {
            if (ModelState.IsValid)
            {
                data.Products.Insert(vm.Product);
                data.Save();

                TempData["message"] = $"{vm.Product.Name} added to Products.";
                return RedirectToAction("Index");
            }
            else
            {
                Load(vm, "Add");
                return View("Book", vm);
            }
        }

        [HttpGet]
        public ViewResult Edit(int id) => GetBook(id, "Edit");

        [HttpPost]
        public IActionResult Edit(OfficeProductViewModel vm)
        {
            if (ModelState.IsValid)
            {
                data.Products.Update(vm.Product);
                data.Save();

                TempData["message"] = $"{vm.Product.Name} updated.";
                return RedirectToAction("Search");
            }
            else
            {
                Load(vm, "Edit");
                return View("Book", vm);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id) => GetBook(id, "Delete");

        [HttpPost]
        public IActionResult Delete(OfficeProductViewModel vm)
        {
            data.Products.Delete(vm.Product);
            data.Save();
            TempData["message"] = $"{vm.Product.Name} removed from Products.";
            return RedirectToAction("Search");
        }

        private ViewResult GetBook(int id, string operation)
        {
            var book = new OfficeProductViewModel();
            Load(book, operation, id);
            return View("Book", book);
        }
        private void Load(OfficeProductViewModel vm, string op, int? id = null)
        {
            if (Operation.IsAdd(op))
            {
                vm.Product = new OfficeProduct();
            }
            else
            {
                vm.Product = data.Products.Get(new QueryOptions<OfficeProduct>
                {
                    Include = "Type",
                    Where = op => op.OfficeProductId == (id ?? vm.Product.OfficeProductId)
                });
            }
            vm.Types = data.Types.List(new QueryOptions<ProductType>
            {
                OrderBy = pt => pt.Name
            });
        }
    }
}
