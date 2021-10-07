using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantRater2.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }
        [Display(Name ="Restaurant Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual List<Review> Reviews { get; set; }
    }

    public class RestaurantDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}