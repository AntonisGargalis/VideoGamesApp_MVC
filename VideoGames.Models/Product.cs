using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGames.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]              
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        [Range(1, 1000)]
        public double Price { get; set; }

    }
}
