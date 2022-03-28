using Banking.Application.Users.Assemblers;
using Banking.Application.Users.Constants;
using Banking.Application.Users.Contracts;
using Banking.Application.Users.Dtos;
using Banking.Domain.Auth.Contracts;
using Banking.Domain.Auth.Entities;
using Banking.Infrastructure.Auth.Hashing;
using Microsoft.AspNetCore.Http;
using Common;
using System;

namespace Banking.Application.Users.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly NewUserAssembler _newUserAssembler;
        private readonly Hasher _hasher;

        public UserApplicationService(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            NewUserAssembler newUserAssembler,
            Hasher hasher)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _newUserAssembler = newUserAssembler;
            _hasher = hasher;
        }

        public NewUserResponseDto Register(NewUserDto newUserDto)
        {
            try
            {
                string hashedPassword = _hasher.HashPassword(newUserDto.Password);
                newUserDto.Password = hashedPassword;
                User user = _newUserAssembler.ToEntity(newUserDto);
                _userRepository.SaveOrUpdate(user);
                return new NewUserResponseDto
                {
                    HttpStatusCode = StatusCodes.Status201Created,
                    Response = new ApiStringResponse(UserAppConstants.UserCreated)
                };
            }
            catch(Exception ex)
            {
                //TODO: Log exception async, for now write exception in the console
                Console.WriteLine(ex.Message);
                return new NewUserResponseDto
                {
                    HttpStatusCode = StatusCodes.Status500InternalServerError,
                    Response = new ApiStringResponse(ApiConstants.InternalServerError)
                };
            }
        }
    }
}
