using System.Security.Cryptography;
using System.Text;

namespace FM_Rozetka_Api.Core.Services
{
    public static class Utility
    {
        public static string GenerateRandomPassword(int length = 12)
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            const string digits = "0123456789";
            const string specialChars = "!@#$%^&*()?_-";

            if (length < 6)
            {
                throw new ArgumentException("Password length must be at least 6 characters.");
            }

            var random = new RNGCryptoServiceProvider();
            var password = new char[length];
            var randomBytes = new byte[length];
            random.GetBytes(randomBytes);

            password[0] = letters[randomBytes[0] % letters.Length]; // Літера
            password[1] = digits[randomBytes[1] % digits.Length]; // Цифра
            password[2] = specialChars[randomBytes[2] % specialChars.Length]; // Спеціальний символ
            password[3] = letters[randomBytes[3] % letters.Length]; // Літера

            for (int i = 4; i < length; i++)
            {
                var allChars = letters + digits + specialChars;
                password[i] = allChars[randomBytes[i] % allChars.Length];
            }

            return new string(password.OrderBy(x => randomBytes[Array.IndexOf(password, x)]).ToArray());
        }

        public static string Encrypt(string plainText, string encryptionKey)
        {
            var key = Convert.FromBase64String(encryptionKey);
            using (var aes = Aes.Create())
            {
                aes.Key = key;
                aes.GenerateIV(); 

                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (var ms = new MemoryStream())
                {
                    ms.Write(aes.IV, 0, aes.IV.Length);

                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (var sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                    }

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string Decrypt(string cipherText, string encryptionKey)
        {
            var key = Convert.FromBase64String(encryptionKey);
            var fullCipher = Convert.FromBase64String(cipherText);

            using (var aes = Aes.Create())
            {
                aes.Key = key;

                var iv = new byte[16];
                Array.Copy(fullCipher, 0, iv, 0, iv.Length);
                aes.IV = iv;

                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (var ms = new MemoryStream(fullCipher, iv.Length, fullCipher.Length - iv.Length))
                {
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (var sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }

    }
}
