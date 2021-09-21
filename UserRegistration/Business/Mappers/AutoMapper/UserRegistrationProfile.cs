using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mappers.AutoMapper
{
    public class UserRegistrationProfile:Profile
    {
        public UserRegistrationProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
