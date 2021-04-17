using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.API.Models;
using Products.API.Repositories.Interfaces;

namespace Products.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        public IProductRepository ProductRepository { get; }
        public ProductsController(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }


        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>product list</returns>
        [ProducesResponseType(typeof(IEnumerable<Product>), 200)]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(ProductRepository.GetAll());
        }

        /// <summary>
        /// Get product by ID
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Product found.</response>
        /// <response code="404">Product not found.</response>
        [ProducesResponseType(typeof(Product), 200)]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var product = ProductRepository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        /// <summary>
        /// Remove product by ID
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Product removed.</response>
        [ProducesResponseType(typeof(Product), 200)]
        [HttpDelete("{id}")]
        public IActionResult RemoveById(Guid id)
        {
            ProductRepository.Delete(id);
            return Ok();
        }

        /// <summary>
        /// Create a new product
        /// </summary>
        /// <param name="newProduct">new product details</param>
        /// <response code="201">product created.</response>
        /// <response code="400">bad request</response>
        [ProducesResponseType(typeof(Product), 201)]
        [ProducesResponseType(400)]
        [HttpPost]
        public IActionResult Insert(Product newProduct)
        {
            newProduct.Id = Guid.NewGuid();
            ProductRepository.Insert(newProduct);
            return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="id">product id</param>
        /// <param name="newProduct">new product details</param>
        /// <response code="201">product updated.</response>
        /// <response code="400">bad request</response>
        [ProducesResponseType(typeof(Product), 201)]
        [ProducesResponseType(400)]
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Product newProduct)
        {
            ProductRepository.Update(id, newProduct);
            return Ok();
        }

    }
}