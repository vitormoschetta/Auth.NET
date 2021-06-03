using System;

namespace Domain.Utils
{
    public class PasswordGenerator
    {
        public static string Generate()
        {
            string chars = "abcdefghjkmnpqrstuvwxyz023456789";
            string pass = "";
            Random random = new Random();
            for (int f = 0; f < 6; f++)
            {
                pass = pass + chars.Substring(random.Next(0, chars.Length - 1), 1);
            }
            return pass;
        }
    }
}