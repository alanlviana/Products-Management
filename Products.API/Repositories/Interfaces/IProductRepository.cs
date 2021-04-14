using System;
using System.Collections.Generic;
using Products.API.Models;

namespace Products.API.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Product Insert(Product product);
        IEnumerable<Product> GetAll();
        void Delete(Guid productId);
        Product GetById(Guid id);
        void Update(Guid productId, Product product);
    }
}