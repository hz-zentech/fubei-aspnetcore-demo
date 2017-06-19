using System;
using System.Security.Cryptography;
using System.Text;

namespace FubeiDemoMvcApplication.Common
{
    public class RandomStringUtil
    {
        private static readonly char[] Alphanumeric = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
        
        public static string RandomAlphanumeric(int count) {
            var randomBytes = new byte[count];
            var sb = new StringBuilder(count);
            RandomNumberGenerator.Create().GetBytes(randomBytes);
            var random = new Random(BitConverter.ToInt32(randomBytes, 0));
            for (var i = 0; i != count; ++i)
            {
                sb.Append(Alphanumeric[random.Next(0, Alphanumeric.Length)]);
            }
            return sb.ToString();
        }
    }
}