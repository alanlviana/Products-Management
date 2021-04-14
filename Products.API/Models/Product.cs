using System;
using System.ComponentModel.DataAnnotations;

namespace Products.API.Models
{
    public class Product
    {

        [Required]
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Product Name is Required")]
        public string ProductName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The SKU is required.")]
        public string SKU { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The UPC is required.")]
        public string UPC { get; set; }
        [Range(0, 1_000_000, ErrorMessage = "The product price must to be between 0 and 1.000.000")]
        public decimal Price { get; set; }
    }
}