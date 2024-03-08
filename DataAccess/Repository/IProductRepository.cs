using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductByID(int ProductId);
        void InsertProduct(Product product);
        void DeleteProduct(int ProductId);
        void UpdateProduct(Product product);
        List<Product> GetProductsByProductName(string searchProductName);
        List<Product> GetProductsByPrice(decimal minPrice, decimal maxPrice);
        List<Product> GetProductsByNameAndPrice(string searchProductName, decimal minPrice, decimal maxPrice);
    }
}
