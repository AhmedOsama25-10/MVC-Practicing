using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi__Shop.Models
{
    public class ProductViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public double Price { get; set; }

        [Required]

        public IFormFile Image { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int Stock { get; set; }
        public DateTime ProductionYear { get; set; }
        public string BrandName { get; set; }
        public int CategotyID { get; set; }
        public string ImgPath { get; set; }
        public string UserName { get; set; }


    }
}
