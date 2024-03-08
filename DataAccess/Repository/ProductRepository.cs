using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(int ProductId) => ProductDAO.Instance.Remove(ProductId);

        public Product GetProductByID(int ProductId) => ProductDAO.Instance.GetProductByID(ProductId);

        public IEnumerable<Product> GetProducts() => ProductDAO.Instance.GetProductList();

        public List<Product> GetProductsByNameAndPrice(string searchProductName, decimal minPrice, decimal maxPrice) => ProductDAO.Instance.GetProductListByProductNameAndPrice(searchProductName, minPrice, maxPrice);

        public List<Product> GetProductsByPrice(decimal minPrice, decimal maxPrice) => ProductDAO.Instance.GetProductListByPrice(minPrice, maxPrice);

        public List<Product> GetProductsByProductName(string searchProductName) => ProductDAO.Instance.GetProductListByProductName(searchProductName);

        public void InsertProduct(Product product) => ProductDAO.Instance.AddNew(product);

        public void UpdateProduct(Product product) => ProductDAO.Instance.Update(product);
    }
}
