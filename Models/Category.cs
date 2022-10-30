using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi__Shop.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        
    }
}
