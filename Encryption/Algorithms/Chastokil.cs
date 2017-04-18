using System.Text;

namespace Encryption.Algorithms
{
    public class Chastokil : IEncryptable
    {
        private readonly int _key;

        public Chastokil(int key)
        {
            _key = key;
        }

        public byte[] Encrypt(byte[] data)
        {
            int ad = -1;
            string str = Encoding.Unicode.GetString(data);
            int len = str.Length;
            var work = new string[_key];
            for (int i = 0; i < _key; i++)
                work[i] = "";

            // Собственно кодирование
            int h = _key - 1;
            for (int i = 0; i < len; i++)
            {
                work[h] += str[i];
                h += ad;

                if (h == 0)
                    ad = 1;
                else if (h == _key - 1)
                    ad = -1;
            }
            // Собираем результат
            string result = "";
            for (int i = 0; i < _key; i++)
                result = result + work[i];

            return Encoding.Unicode.GetBytes(result);
        }

        public byte[] Decrypt(byte[] data)
        {
            string str = Encoding.Unicode.GetString(data);
            int len = str.Length;

            // вычисляем число символов с разной высотой
            var hh = new int[_key];
            int wh = len / (2 * _key - 2); // столько было у всех
            for (int i = 1; i < _key - 1; i++)
            {
                hh[i] = wh * 2;
            }
            hh[0] = wh;
            hh[_key - 1] = wh;
            wh = len % (2 * _key - 2); // столько было не у всех

            for (int i = _key - 1; i >= 0 && wh > 0; i--)
            {
                hh[i]++;
                wh--;
            }

            if (wh > 0)
            {  // что - то осталось
                for (int i = 1; wh > 0; i++)
                {
                    hh[i]++;
                    wh--;
                }
            }

            // Разбираем строку на подстроки
            var work = new string[_key];
            wh = 0;
            for (int i = 0; i < _key; i++)
            {
                work[i] = str.Substring(wh, hh[i]);
                wh += hh[i];
                hh[i] = 0;
            }

            // собираем результат
            int ad = -1;
            // Собственно кодирование
            string result = "";
            int h = _key - 1;
            for (int i = 0; i < len; i++)
            {
                result += work[h][hh[h]++];
                h += ad;
                if (h == 0)
                {
                    ad = 1;
                }
                else if (h == _key - 1)
                {
                    ad = -1;
                }
            }

            return Encoding.Unicode.GetBytes(result);
        }

    }
}
