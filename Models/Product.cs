using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsAndCategories.Models
{
    public class Product
    {
        [Key]
        public int ProductId {get; set;}

        [Required]
        [MaxLength(45, ErrorMessage = "Product Name Cannot be more than 45 characters...")]
        [Display(Name = "Product Name", Prompt = "Product Name")]
        public string Name {get; set;}

        [Required]
        [Display(Name = "Description", Prompt = "Description")]
        public string Desc {get; set;}

        [Required]
        [Display(Name = "Price", Prompt = "Price")]
        public decimal Price {get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;

        public List<Association> ProductCategories {get; set;}
    }
}