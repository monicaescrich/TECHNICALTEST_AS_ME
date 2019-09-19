using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECHNICALTEST_AS_ME.Resources
{
    public class OrderResource
    {
        public int OrdersID { get; set; }
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }
    }
    public class OrderDetailResource
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
    }
}