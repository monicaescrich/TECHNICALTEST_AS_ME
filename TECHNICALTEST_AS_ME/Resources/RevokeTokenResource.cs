using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TECHNICALTEST_AS_ME.Resources
{
    public class RevokeTokenResource
    {
        [Required]
        public string Token { get; set; }
    }
}
