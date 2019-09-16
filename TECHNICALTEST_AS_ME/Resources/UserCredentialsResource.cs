using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TECHNICALTEST_AS_ME.Resources
{
    public class UserCredentialsResource
    {
       
        public int UserID { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(32)]
        public string Password { get; set; }

        public string Name { get; set; }

    }
}
