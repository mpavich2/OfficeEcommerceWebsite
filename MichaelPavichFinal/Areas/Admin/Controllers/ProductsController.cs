using System.IO;
using MichaelPavichFinal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MichaelPavichFinal.Areas.Admin.Controllers
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
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
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
        ///     Indexes this instance.
        /// </summary>
        /// <returns>the index view</returns>
        public IActionResult Index()
        {
            var search = new SearchData(TempData);
            search.Clear();

            return View();
        }

        /// <summary>
        ///     Searches for the specified item.
        /// </summary>
        /// <param name="vm">The vm.</param>
        /// <returns>the search view if valid; otherwise, the index view.</returns>
        [HttpPost]
        public RedirectToActionResult Search(SearchViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var search = new SearchData(TempData) {
                    SearchTerm = vm.SearchTerm,
                    Type = vm.Type
                };
                return RedirectToAction("Search");
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        ///     Gets the search results.
        /// </summary>
        /// <returns>the search results view if valid; otherwise, the index view</returns>
        [HttpGet]
        public ViewResult Search()
        {
            var search = new SearchData(TempData);

            if (search.HasSearchTerm)
            {
                var vm = new SearchViewModel {
                    SearchTerm = search.SearchTerm
                };

                var options = new QueryOptions<OfficeProduct> {
                    Include = "Type"
                };
                if (search.IsProduct)
                {
                    options.Where = b => b.Name.Contains(vm.SearchTerm);
                    vm.Header = $"Search results for product name '{vm.SearchTerm}'";
                }

                if (search.IsType)
                {
                    options.Where = b => b.ProductTypeId.Contains(vm.SearchTerm);
                    vm.Header = $"Search results for type ID '{vm.SearchTerm}'";
                }

                vm.Products = this.Data.Products.List(options);
                return View("SearchResults", vm);
            }

            return View("Index");
        }

        /// <summary>
        ///     Gets the page to add the product
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>the add view</returns>
        [HttpGet]
        public ViewResult Add(int id)
        {
            return this.getProduct(id, "Add");
        }

        /// <summary>
        ///     Adds the product to the database.
        /// </summary>
        /// <param name="vm">The vm.</param>
        /// <returns>the index view</returns>
        [HttpPost]
        public IActionResult Add(OfficeProductViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Count == 0)
                {
                    this.load(vm, "Add");
                    ModelState.AddModelError("", "Please select an image.");
                    return View("Product", vm);
                }

                foreach (var file in Request.Form.Files)
                {
                    var img = new Image();
                    img.Title = file.FileName;

                    var ms = new MemoryStream();
                    file.CopyTo(ms);
                    img.Data = ms.ToArray();

                    ms.Close();
                    ms.Dispose();

                    this.Data.Images.Insert(img);
                    this.Data.Save();

                    vm.Product.ImageId = img.ImageId;
                }

                this.Data.Products.Insert(vm.Product);
                this.Data.Save();

                TempData["message"] = $"{vm.Product.Name} added to Products.";
                return RedirectToAction("Index");
            }

            this.load(vm, "Add");
            return View("Product", vm);
        }

        /// <summary>
        ///     Gets the page to edit the specified product
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Edit(int id)
        {
            return this.getProduct(id, "Edit");
        }

        /// <summary>
        ///     Edits the specified product.
        /// </summary>
        /// <param name="vm">The vm.</param>
        /// <returns>the search view if valid; otherwise, the product view</returns>
        [HttpPost]
        public IActionResult Edit(OfficeProductViewModel vm)
        {
            if (ModelState.IsValid)
            {
                this.Data.Products.Update(vm.Product);
                this.Data.Save();

                TempData["message"] = $"{vm.Product.Name} updated.";
                return RedirectToAction("Search");
            }

            this.load(vm, "Edit");
            return View("Product", vm);
        }

        /// <summary>
        ///     Gets the page to delete a product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Delete(int id)
        {
            return this.getProduct(id, "Delete");
        }

        /// <summary>
        ///     Deletes the specified product.
        /// </summary>
        /// <param name="vm">The vm.</param>
        /// <returns>the search view.</returns>
        [HttpPost]
        public IActionResult Delete(OfficeProductViewModel vm)
        {
            this.Data.Products.Delete(vm.Product);
            this.Data.Save();
            TempData["message"] = $"{vm.Product.Name} removed from Products.";
            return RedirectToAction("Search");
        }

        private ViewResult getProduct(int id, string operation)
        {
            var product = new OfficeProductViewModel();
            this.load(product, operation, id);
            return View("Product", product);
        }

        private void load(OfficeProductViewModel vm, string op, int? id = null)
        {
            if (Operation.IsAdd(op))
            {
                vm.Product = new OfficeProduct();
            }
            else
            {
                vm.Product = this.Data.Products.Get(new QueryOptions<OfficeProduct> {
                    Include = "Type",
                    Where = op => op.OfficeProductId == (id ?? vm.Product.OfficeProductId)
                });
            }

            vm.Types = this.Data.Types.List(new QueryOptions<ProductType> {
                OrderBy = pt => pt.Name
            });
        }

        #endregion
    }
}