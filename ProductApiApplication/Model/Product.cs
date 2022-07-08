using System;
using System.ComponentModel.DataAnnotations;

namespace ProductApiApplication.Model
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Product Name can be 50 characters long")]
        public string Name { get; set; }
    }
}
