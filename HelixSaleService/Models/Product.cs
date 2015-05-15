using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTest.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int quantity { get; set; }
        public double sale_amount { get; set; }

    }
}