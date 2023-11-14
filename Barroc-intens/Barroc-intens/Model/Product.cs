﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barroc_intens.Model
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Dimensions { get; set; }
        public string Description { get; set; }
        //public string ImagePath { get; set; }
        public decimal Price { get; set; }

        //public Product_category category { get; set; }
        //public int Product_catogory { get; set; }
        public string PriceFormatted => string.Format("{0:N2}", Price);
        public int Storage { get; set; }

        public string StorageFormatted => string.Format("{0:F2}", Storage);
    }
}
