using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Product> GetProductList()
        {
            var products = new List<Product>();
            try
            {
                using var context = new SalesManagementContext();
                products = context.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }
        public Product GetProductByID(int ProductId)
        {
            Product product = null;
            try
            {
                using var context = new SalesManagementContext();
                product = context.Products.SingleOrDefault(p => p.ProductId == ProductId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }
        public void AddNew(Product product)
        {
            try
            {
                Product _product = GetProductByID(product.ProductId);
                if (_product == null)
                {
                    using var context = new SalesManagementContext();
                    context.Products.Add(product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The product is already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Product product)
        {
            try
            {
                Product _product = GetProductByID(product.ProductId);
                if (_product != null)
                {
                    using var context = new SalesManagementContext();
                    context.Products.Update(product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The product does not already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(int ProductId)
        {
            try
            {
                Product product = GetProductByID(ProductId);
                if (product != null)
                {
                    using var context = new SalesManagementContext();
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The product does not already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Product> GetProductListByProductName(string searchProductName)
        {
            var products = new List<Product>();
            try
            {
                using var context = new SalesManagementContext();
                products = context.Products.Where(p => p.ProductName.Contains(searchProductName)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public List<Product> GetProductListByPrice(decimal minPrice, decimal maxPrice)
        {
            var products = new List<Product>();
            try
            {
                using var context = new SalesManagementContext();
                products = context.Products.Where(p => (p.UnitPrice >= minPrice && p.UnitPrice <= maxPrice)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public List<Product> GetProductListByProductNameAndPrice(string searchProductName, decimal minPrice, decimal maxPrice)
        {
            var products = new List<Product>();
            try
            {
                using var context = new SalesManagementContext();
                products = context.Products.Where(p => (p.UnitPrice >= minPrice && p.UnitPrice <= maxPrice) && (p.ProductName.Contains(searchProductName))).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }
    }
}
