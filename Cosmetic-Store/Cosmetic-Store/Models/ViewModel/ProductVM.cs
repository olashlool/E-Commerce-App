using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cosmetic_Store.Models.ViewModel
{
    public class ProductVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; }


    }
}
