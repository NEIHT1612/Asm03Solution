using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eStore.Controllers
{
    public class ProductsController : Controller
    {
        IProductRepository productRepository = null;
        public ProductsController() => productRepository = new ProductRepository();
        // GET: ProductsController
        public ActionResult Index()
        {
            var productList = productRepository.GetProducts();
            return View(productList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string searchProductName, string priceFilter)
        {
            var productList = new List<Product>();

            if (!string.IsNullOrEmpty(searchProductName) && string.IsNullOrEmpty(priceFilter))
            {
                productList = productRepository.GetProductsByProductName(searchProductName);
            }
            else if (string.IsNullOrEmpty(searchProductName) && !string.IsNullOrEmpty(priceFilter))
            {
                string[] priceRange = priceFilter.Split('-');
                if (priceRange.Length == 2)
                {
                    decimal minPrice = decimal.Parse(priceRange[0]);
                    decimal maxPrice = decimal.Parse(priceRange[1]);
                    productList = productRepository.GetProductsByPrice(minPrice, maxPrice);
                }
                else
                {
                    productList = (List<Product>)productRepository.GetProducts();
                }
            }
            else if (!string.IsNullOrEmpty(searchProductName) && !string.IsNullOrEmpty(priceFilter))
            {
                string[] priceRange = priceFilter.Split('-');
                if (priceRange.Length == 2)
                {
                    decimal minPrice = decimal.Parse(priceRange[0]);
                    decimal maxPrice = decimal.Parse(priceRange[1]);
                    productList = productRepository.GetProductsByNameAndPrice(searchProductName, minPrice, maxPrice);
                }
                else
                {
                    productList = (List<Product>)productRepository.GetProducts();
                }
            }
            else
            {
                productList = (List<Product>)productRepository.GetProducts();
            }
            return View(productList);
        } 

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var product = productRepository.GetProductByID(id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    productRepository.InsertProduct(product);
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(product);
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var product = productRepository.GetProductByID(id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                if(id != product.ProductId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    productRepository.UpdateProduct(product);
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {

            if(id == null)
            {
                return NotFound();
            }
            var product = productRepository.GetProductByID(id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                productRepository.DeleteProduct(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}
