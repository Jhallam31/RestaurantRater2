using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantRater2.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        [Display(Name ="Dine Date")]
        public DateTime DineDate { get; set; }
        public int Rating { get; set; }
        [ForeignKey(nameof(Restaurant))]
        [Display(Name ="Restaurant Name")]
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}