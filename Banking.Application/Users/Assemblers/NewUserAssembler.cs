using AutoMapper;
using Banking.Application.Users.Dtos;
using Banking.Domain.Auth.Entities;
using System;

namespace Banking.Application.Users.Assemblers
{
    public class NewUserAssembler
    {
        private readonly IMapper _mapper;

        public NewUserAssembler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public User ToEntity(NewUserDto newUserDto)
        {
            User user = _mapper.Map<User>(newUserDto);
            user.PasswordHash = newUserDto.Password;
            DateTime utcNow = DateTime.UtcNow;
            user.CreatedAt = utcNow;
            user.UpdatedAt = utcNow;
            return user;
        }
    }
}
