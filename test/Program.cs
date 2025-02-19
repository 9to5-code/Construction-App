

using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        using (var rng = RandomNumberGenerator.Create())
        {
            byte[] key = new byte[32]; // 256-bit key
            rng.GetBytes(key);
            string secretKey = Convert.ToBase64String(key);
            Console.WriteLine($"Generated Secret Key: {secretKey}");
        }
    }
}
