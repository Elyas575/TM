using System.ComponentModel.DataAnnotations;

namespace ThursdayMarket.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(40, ErrorMessage = "The Name field must be between 1 and 50 characters.", MinimumLength = 1)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The DisplayOrder field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The DisplayOrder field must be a positive integer.")]
        public int DisplayOrder { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
