using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHNICALTEST_AS_ME.Domains.Models;
using TECHNICALTEST_AS_ME.Resources;
using AutoMapper;

namespace TECHNICALTEST_AS_ME.Mapping
{
    public class ResourceToModelProfile:Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<UserCredentialsResource, User>();
        }
    }
}
