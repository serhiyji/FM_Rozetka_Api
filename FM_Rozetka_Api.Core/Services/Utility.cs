using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Services
{
    public static class Utility
    {
        public static string GenerateRandomPassword(int length = 12)
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            const string digits = "0123456789";
            const string specialChars = "!@#$%^&*()?_-";

            // Перевіряємо, чи довжина пароля достатня для включення всіх типів символів
            if (length < 6)
            {
                throw new ArgumentException("Password length must be at least 6 characters.");
            }

            // Генеруємо випадкові символи для кожного типу
            var random = new RNGCryptoServiceProvider();
            var password = new char[length];
            var randomBytes = new byte[length];
            random.GetBytes(randomBytes);

            password[0] = letters[randomBytes[0] % letters.Length]; // Літера
            password[1] = digits[randomBytes[1] % digits.Length]; // Цифра
            password[2] = specialChars[randomBytes[2] % specialChars.Length]; // Спеціальний символ
            password[3] = letters[randomBytes[3] % letters.Length]; // Літера

            // Заповнюємо решту пароля випадковими символами з усіх наборів
            for (int i = 4; i < length; i++)
            {
                var allChars = letters + digits + specialChars;
                password[i] = allChars[randomBytes[i] % allChars.Length];
            }

            // Перемішуємо символи в паролі
            return new string(password.OrderBy(x => randomBytes[Array.IndexOf(password, x)]).ToArray());
        }

    }

}
