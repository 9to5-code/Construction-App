using System;
using System.Security.Cryptography;
using System.Text;
namespace SignUpApp.Utility
{
   public class PasswordHash
    {
        public const int SaltByteSize = 24;
        public const int HashByteSize = 64; // to match the size of the PBKDF2-HMAC-SHA-512 hash 
        public const int Pbkdf2Iterations = 1000;
        public const int IterationIndex = 0;
        public const int SaltIndex = 1;
        public const int Pbkdf2Index = 2;
        private static Guid salt= Guid.Parse("906236BF-0ECA-4921-8C7E-2CC5022B1E0F");
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return "";
            }
            //var cryptoProvider = new RNGCryptoServiceProvider();
            //byte[] salt = new byte[SaltByteSize];
            //cryptoProvider.GetBytes(salt);
            return CreateHash(password, salt.ToByteArray());
            //var hash = GetPbkdf2Bytes(password, salt, Pbkdf2Iterations, HashByteSize);
            //return Pbkdf2Iterations + ":" + Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
        }
        public static bool ValidatePassword(string password, string correctHash)
       {
            try
            {
                //char[] delimiter = { ':' };
                //var split = correctHash.Split(delimiter);
                ////var iterations = Int32.Parse(split[IterationIndex]);
                //var salt = Convert.FromBase64String(split[SaltIndex]);
                //var hash = Convert.FromBase64String(split[Pbkdf2Index]);
                //var cryptoProvider = new RNGCryptoServiceProvider();
                //byte[] salt = new byte[SaltByteSize];
                //cryptoProvider.GetBytes(salt);
                var testHash = CreateHash(password, salt.ToByteArray());
                return SlowEquals(Encoding.ASCII.GetBytes(correctHash), Encoding.ASCII.GetBytes(testHash));
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private static bool SlowEquals(byte[] a, byte[] b)
        {
            var diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }
        private static byte[] GetPbkdf2Bytes(string password, byte[] salt, int iterations, int outputBytes)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }
        //internal static String CreateHash(String value, Guid salt)
        //{
        //    return CreateHash(value, salt.ToByteArray());
        //}
        internal static String CreateHash(String value, byte[] salt)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return _getHash(sha256Hash, value, salt);
            }
        }
        private static string _getHash(HashAlgorithm hashAlgorithm, string input, byte[] salt)
        {
            // Convert the input string to a byte array and compute the hash.
            List<byte> inputList = new List<byte>();
            inputList.AddRange(Encoding.UTF8.GetBytes(input));
            inputList.AddRange(salt);
            byte[] data = hashAlgorithm.ComputeHash(inputList.ToArray());
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
