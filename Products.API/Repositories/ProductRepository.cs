using System;
using System.Collections.Generic;
using System.Linq;
using Products.API.Models;
using Products.API.Repositories.Interfaces;

namespace Products.API.Repositories
{
    public class ProductRepository: IProductRepository
    {
        public DatabaseContext Context { get; }

        public ProductRepository(DatabaseContext context)
        {
            this.Context = context;
        }

        public Product Insert(Product product)
        {
            Context.Products.Add(product);
            Context.SaveChanges();

            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            var list = Context.Products;
            return list;
        }

        public void Delete(Guid productId)
        {
            var product = Context.Products.Where(ta => ta.Id == productId).FirstOrDefault();
            Context.Products.Remove(product);
            Context.SaveChanges();
        }

        public Product GetById(Guid productId)
        {
            return Context.Products.Where(a => a.Id == productId).FirstOrDefault();
        }

        public void Update(Guid productId, Product product)
        {
            var oldProduct = Context.Products.Where(ta => ta.Id == productId).FirstOrDefault();
            if (oldProduct == null) return;

            oldProduct.ProductName = product.ProductName;
            oldProduct.SKU = product.SKU;
            oldProduct.UPC = product.UPC;
            oldProduct.Price = product.Price;

            Context.SaveChanges();
        }
    }
}