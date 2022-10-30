using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi__Shop.Models
{
    public class CartViewModel
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string Username { get; set; }
    }
}
