using System.Security.Cryptography;

namespace CascadingList.UtilityClasses
{
    public static class Extension
    {
        public static string GenerateSecretKey(int length)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var byteArray = new byte[length]; rng.GetBytes(byteArray);
                return Convert.ToBase64String(byteArray);
            }
        }

    }
}
