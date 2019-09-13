using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECHNICALTEST_AS_ME.Domains.Models
{
    public class Category
    {
        
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
        
    }
}
