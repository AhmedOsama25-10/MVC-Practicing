﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi__Shop.Models
{
    public class CategoryViewModel
    {
        [Required]
        public string Name { get; set; }
       
    }
}
