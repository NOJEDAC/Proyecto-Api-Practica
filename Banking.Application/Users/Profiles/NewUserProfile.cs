using AutoMapper;
using Banking.Application.Users.Dtos;
using Banking.Domain.Auth.Entities;

namespace Banking.Application.Users.Profiles
{
    public class NewUserProfile : Profile
    {
        public NewUserProfile()
        {
            CreateMap<NewUserDto, User>()
                .ReverseMap();
        }
    }
}
