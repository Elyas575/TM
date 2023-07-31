

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ThursdayMarket.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get;set; }
        

    }
}
