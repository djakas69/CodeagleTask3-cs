using Csharp_Task_3.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Csharp_Task_3.Helpers
{
    public static class Criptography
    {
        #region HashCode
        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        #endregion
        public static SecurityTokenDescriptor CreateTokenDesctiptor(string secretKey, LocalUser findUser)
        {
            var key = Encoding.ASCII.GetBytes(secretKey);

            ClaimsIdentity SubjectCI = new ClaimsIdentity(new Claim[]
                               {
                                new Claim(ClaimTypes.Name, findUser.Id.ToString()),
                                new Claim(ClaimTypes.Role, findUser.Role)
                               });


            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = SubjectCI,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenDescriptor;
        }
    }
}
