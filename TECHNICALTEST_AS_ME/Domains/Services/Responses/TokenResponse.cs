using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHNICALTEST_AS_ME.Security.Tokens;

namespace TECHNICALTEST_AS_ME.Domains.Services.Responses
{
    
        public class TokenResponse : BaseResponse
        {
            public AccessToken Token { get; set; }

            public TokenResponse(bool success, string message, AccessToken token) : base(success, message)
            {
                Token = token;
            }
        }
    
}
