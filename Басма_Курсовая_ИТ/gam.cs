using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Басма_Курсовая_ИТ
{
    class gam
    {

        //генератор повторений пароля
        static public string GetRepeatKey(string s, int n)
        {
            var r = s;
            while (r.Length < n)
            {
                r += r;
            }

            return r.Substring(0, n);
        }

        //метод шифрования/дешифровки
        static public string Cipher(string text, string secretKey)
        {
            var currentKey = GetRepeatKey(secretKey, text.Length);
            var res = string.Empty;
            for (var i = 0; i < text.Length; i++)
            {
                res += ((char)(text[i] ^ currentKey[i])).ToString();
            }

            return res;
        }

        //шифрование текста
        static public string Encrypt(string plainText, string password)
            => Cipher(plainText, password);

        //расшифровка текста
        static public string Decrypt(string encryptedText, string password)
            => Cipher(encryptedText, password);

    }
}
