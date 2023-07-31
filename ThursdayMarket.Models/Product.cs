using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThursdayMarket.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }


        public string Name { get; set; }

    
        public string? Description { get; set; }

  
        public string? ISBN { get; set; }

    
        public string? Supplier { get; set; }

 
        public double Price { get; set; }

        public double Weight { get; set; }


        public double Quantity { get; set; }

        public int CategoryId { get; set; }

        public string? ImageUrl { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

    }
}
