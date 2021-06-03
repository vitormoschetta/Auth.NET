using System.Security.Cryptography;

namespace Domain.Utils
{
    public class SaltGenerator
    {
        public static byte[] Generate()
        {
            byte[] salt = new byte[128 / 8];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(salt);
                return salt;
            }
        }
    }
}