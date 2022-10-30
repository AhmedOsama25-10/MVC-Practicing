using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi__Shop.Models
{
    public class Cart
    {
        public int ID { get; set; }
        
        public string UserName { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }


    }
}
