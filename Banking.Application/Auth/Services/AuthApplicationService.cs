using Banking.Application.Auth.Contracts;
using Banking.Application.Auth.Dtos;
using Banking.Application.Auth.Jwt;
using Banking.Application.Auth.ViewModels;
using Banking.Domain.Auth.Contracts;
using Banking.Domain.Auth.Entities;
using Banking.Infrastructure.Auth.Hashing;
using Microsoft.AspNetCore.Http;
using Common;
using System;

namespace Banking.Application.Auth.Services
{
    public class AuthApplicationService : IAuthApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IAuthQueries _authQueries;
        private readonly Hasher _hasher;
        private readonly JwtProvider _jwtProvider;

        public AuthApplicationService(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            IAuthQueries authQueries,
            Hasher hasher,
            JwtProvider jwtProvider)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _authQueries = authQueries;
            _hasher = hasher;
            _jwtProvider = jwtProvider;
        }

        public LoginResponseDto Login(LoginDto loginDto)
        {
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                User user = _userRepository.GetByName(loginDto.Name);
                _unitOfWork.Commit(uowStatus);
                if (user == null)
                {
                    return new LoginResponseDto
                    {
                        HttpStatusCode = StatusCodes.Status401Unauthorized,
                        Response = new ApiStringResponse(ApiConstants.InvalidLogin)
                    };
                }
                if (!_hasher.VerifyHashedPassword(user.PasswordHash, loginDto.Password))
                {
                    return new LoginResponseDto
                    {
                        HttpStatusCode = StatusCodes.Status401Unauthorized,
                        Response = new ApiStringResponse(ApiConstants.InvalidLogin)
                    };
                }
                LoginViewModel loginViewModel = _authQueries.GetLoginInfo(user.Id);
                string token = _jwtProvider.BuildJwtToken(loginViewModel);
                loginViewModel.Token = token;

                return new LoginResponseDto
                {
                    HttpStatusCode = StatusCodes.Status200OK,
                    Response = loginViewModel
                };
            }
            catch(Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                //TODO: Log exception async, for now write exception in the console
                Console.WriteLine(ex.Message);
                return new LoginResponseDto
                {
                    HttpStatusCode = StatusCodes.Status500InternalServerError,
                    Response = new ApiStringResponse(ApiConstants.InternalServerError)
                };
            }
        }
    }
}
