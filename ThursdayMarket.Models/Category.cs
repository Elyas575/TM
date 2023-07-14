using System.ComponentModel.DataAnnotations;

namespace ThursdayMarket.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
