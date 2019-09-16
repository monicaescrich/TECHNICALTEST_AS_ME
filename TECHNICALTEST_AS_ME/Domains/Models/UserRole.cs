using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECHNICALTEST_AS_ME.Domains.Models
{
    public class UserRole
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int IdRole { get; set; }
        public Role Role { get; set; }
    }
}
