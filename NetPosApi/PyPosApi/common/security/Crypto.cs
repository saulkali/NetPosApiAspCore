using System.Security.Cryptography;

namespace PyPosApi.common.security
{
    public static class Crypto
    {


        public static string HashPassword(string password)
        {
            string hashpassword = string.Empty;
            try
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                    hashpassword = BitConverter.ToString(bytes).Replace("-", "").ToLower();
                }
            }
            catch (Exception ex)
            {

            }
            return hashpassword;
        }

        public static bool VerifyPasswordHash(string password, string hash)
        {
            bool isValid = false;
            try
            {
                string hashOfInput = HashPassword(password);
                StringComparer comparer = StringComparer.OrdinalIgnoreCase;
                isValid = comparer.Compare(hashOfInput, hash) == 0;
            }
            catch (Exception ex)
            {

            }
            return isValid;
        }
    }
}
