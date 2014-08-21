using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using OSS.Interfaces.IServices;
using OSS.Models.RequestModels;
using OSS.Web.ModelMappers;
using OSS.Web.ViewModels.Common;
using OSS.Web.ViewModels.Products;
using Product = OSS.Web.Models.Product;
using ProductResponse = OSS.Models.ResponseModels.ProductResponse;

namespace OSS.Web.Controllers
{
    //[SiteAuthorize(PermissionKey = ApplicationRights.ViewProduct )]
    public class ProductController : Controller
    {
        // ReSharper disable InconsistentNaming
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        // ReSharper restore InconsistentNaming

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public ProductController()
        {

        }

        //
        // GET: /Product/
        public ActionResult Index(ProductSearchRequest requestModel)
        {
            
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            ProductViewModel productViewModel = GetData(requestModel);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Product", productViewModel);
            }

            return View(productViewModel);


        }

         
        private ProductViewModel GetData(ProductSearchRequest request)
        {
            ProductResponse products = productService.LoadAllProducts(request);
            IEnumerable<Product> enumerableProduct = products.Products.Select(product => product.CreateFrom()).ToList();
            var productViewModel = new ProductViewModel
            {
                ProductList = new StaticPagedList<Product>(enumerableProduct, request.PageNo, request.PageSize, products.TotalCount),
                Categories = categoryService.LoadAllCategories().AsEnumerable(),
                TotalPrice = enumerableProduct.Select(x => x.Price).Sum(),
                TotalNoOfRec = products.TotalCount,
             ProductSearchRequest = request,
             Products = new SelectList(Enumerable.Empty<OSS.Models.DomainModels.Product>(), "Id", "Name")//you can assume its a list of sub-categories
            };
            return productViewModel;
        }
        //
        // GET: /Product/Create
        public ActionResult Create(int? id)
        {
            // ReSharper disable once SuggestUseVarKeywordEvident
            ProductViewModel productViewModel = new ProductViewModel();
            if (id != null)
            {
                productViewModel.Product = productService.FindProduct((int)id).CreateFrom();
            }
            productViewModel.Categories = categoryService.LoadAllCategories().AsEnumerable();
            return View(productViewModel);
        }

        //
        // POST: /Product/Create
        [HttpPost]        
        public ActionResult Create(ProductViewModel productViewModel)
        {
            // ReSharper disable once SuggestUseVarKeywordEvident
            MessageViewModel messageViewModel = new MessageViewModel();
            //update product
            if (productViewModel.Product.Id > 0)
            {
                if (productService.Update(productViewModel.Product.CreateFrom()))
                {
                    messageViewModel.IsUpdated = true;
                    SetEditMessage(messageViewModel);
                    return RedirectToAction("Index");
                }
            }
            // add new product
            else
            {
                if (productService.AddProduct(productViewModel.Product.CreateFrom()))
                {
                    messageViewModel.IsSaved = true;
                    SetSaveMessage(messageViewModel);
                    return RedirectToAction("Index");
                }
            }

            productViewModel = SetErrorMessage(productViewModel);
            return View(productViewModel);

        }

        private ProductViewModel SetErrorMessage(ProductViewModel productViewModel)
        {
            // ReSharper disable once SuggestUseVarKeywordEvident
            MessageViewModel messageViewModel = new MessageViewModel
          {
              IsError = true,
              Message = Resources.Products.Product.DuplicateName
          };
            ViewBag.MessageVM = messageViewModel;
            productViewModel.Categories = categoryService.LoadAllCategories().AsEnumerable();
            return productViewModel;
        }

        private void SetEditMessage(MessageViewModel messageViewModel)
        {
            messageViewModel.Message = Resources.Products.Product.Edit;
            TempData["message"] = messageViewModel;
        }

        private void SetSaveMessage(MessageViewModel messageViewModel)
        {
            messageViewModel.Message = Resources.Products.Product.Save;
            TempData["message"] = messageViewModel;
        }
        //
        // GET: /Product/Delete/5
        public ActionResult Delete(ProductSearchRequest request)
        {

            var product = productService.FindProduct(request.Id);
            try
            {
                productService.DeleteProduct(product);
                ProductViewModel productViewModel = GetData(request);

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_Product", productViewModel);
                }

            }
            catch
            {
                return View();
            }
            return null;
        }

        [HttpPost]
        public ActionResult Products(string request)
        {
            var products = GetProducts(request);

            return Json(new SelectList(products, "Id", "Name"));
        }
        private IEnumerable<OSS.Models.DomainModels.Product> GetProducts(string request)
        {
            IEnumerable<OSS.Models.DomainModels.Product> products = productService.FindProductsByCategory(Convert.ToInt32(request));

            return products.AsQueryable();
        }
    }
}
