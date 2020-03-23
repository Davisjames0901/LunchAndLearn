using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace LunchAndLearn.Application.Common.Services
{
    public class PasswordService : IPasswordService
    {
        public (string Hash, byte[] Salt) SaltAndHashPassword(string password)
        {
            var salt = new byte[128 / 8];
            using var rng = RandomNumberGenerator.Create();
            
            rng.GetBytes(salt);

            return (HashPassword(password, salt), salt);
        }

        public bool ComparePasswordHash(string password, string hashAndSalt)
        {
            var split = hashAndSalt.Split(' ');
            return string.Equals(HashPassword(password, Encoding.ASCII.GetBytes(split[0])), split[1]);
        }

        public bool ComparePasswordHash(string password, string hash, byte[] salt) => 
            string.Equals(HashPassword(password, salt), hash);

        private string HashPassword(string password, byte[] salt) =>
            Convert.ToBase64String(KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA1, 10000, 256 / 8));
    }
}