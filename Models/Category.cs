using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsAndCategories.Models
{
    public class Category
    {
        [Key]
        public int CategoryId {get; set;}

        [Required]
        [Display(Name = "Category Name", Prompt = "Category Name")]
        [MaxLength(45, ErrorMessage = "Category Name cannot be more than 45 characters...")]
        public string Name {get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;

        public List<Association> CategoryProducts {get; set;}
    }
}