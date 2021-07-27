using System;
using System.ComponentModel.DataAnnotations;

namespace Shopbridge.Model
{
    public class Product
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        [MaxLength(100,ErrorMessage ="Product Name cannot be more than 100 charecters")]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public double price { get; set; }
    }
}