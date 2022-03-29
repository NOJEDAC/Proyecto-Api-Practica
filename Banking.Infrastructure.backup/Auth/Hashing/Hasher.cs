using Banking.Domain.Auth.Entities;
using Microsoft.AspNetCore.Identity;

namespace Banking.Infrastructure.Auth.Hashing
{
    public class Hasher
    {
        public string HashPassword(string password)
        {
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            return passwordHasher.HashPassword(null, password);
        }

        public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            PasswordVerificationResult result = passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
