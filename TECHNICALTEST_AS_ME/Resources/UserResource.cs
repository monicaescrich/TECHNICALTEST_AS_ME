using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECHNICALTEST_AS_ME.Resources
{
    public class UserResource
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
