using Assesment.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Models.Mappings
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, ApiCreateUser>()
            .ForMember(x => x.Email, opt => opt.MapFrom(f => f.Email))
            .ForMember(x => x.FirstName, opt => opt.MapFrom(f => f.FirstName))
            .ForMember(x => x.LastName, opt => opt.MapFrom(f => f.LastName))
            .ForMember(x => x.PasswordHash, opt => opt.MapFrom(f => f.PasswordHash))
            .ForMember(x => x.Id, opt => opt.MapFrom(f => f.Id));
        }

    }
}
