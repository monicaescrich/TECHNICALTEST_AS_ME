using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECHNICALTEST_AS_ME.Domains.Models
{
    public class Order
    {
        public int OrdersID { get; set; }
        public int UserID { get; set;}
        public DateTime OrderDate { get; set; }
        public IList<OrderDetail> OrderDetails { get; set; }
    }
}
