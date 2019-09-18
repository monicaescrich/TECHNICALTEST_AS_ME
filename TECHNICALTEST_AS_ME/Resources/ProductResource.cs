using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECHNICALTEST_AS_ME.Resources
{
    public class ProductResource
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Likes { get; set; }
        public int UnitsInStock { get; set; }
        public int CategoryID { get; set; }
        public bool Discontinued { get; set; }




    }
}
