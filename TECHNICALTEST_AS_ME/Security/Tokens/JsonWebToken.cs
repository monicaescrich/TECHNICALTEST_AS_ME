﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECHNICALTEST_AS_ME.Security.Tokens
{
    public abstract class JsonWebToken
    {
        public string Token { get; protected set; }
        public long Expiration { get; protected set; }

        public JsonWebToken(string token, long expiration)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentException("Invalid token.");

            if (expiration <= 0)
                throw new ArgumentException("Invalid expiration.");

            Token = token;
            Expiration = expiration;
        }

        public bool IsExpired() => DateTime.UtcNow.Ticks > Expiration;
    }
}
