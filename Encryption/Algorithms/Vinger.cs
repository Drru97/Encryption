using System;
using System.Text;

namespace Encryption.Algorithms
{
    public class Vinger : IEncryptable
    {
        private readonly string _key;
        private readonly char[] _characters = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                                'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                                'Э', 'Ю', 'Я', ' ', '1', '2', '3', '4', '5', '6', '7',
                                                '8', '9', '0', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
                                                'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S',
                                                'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
                                              };

        public Vinger(string key)
        {
            _key = key;
        }

        public byte[] Encrypt(byte[] data)
        {
            string input = Encoding.Unicode.GetString(data).ToUpper();
            string keyword = _key.ToUpper();
            string result = "";

            int keywordIndex = 0;

            foreach (char symbol in input)
            {
                int c = (Array.IndexOf(_characters, symbol) +
                    Array.IndexOf(_characters, keyword[keywordIndex])) % _characters.Length;

                result += _characters[c];

                keywordIndex++;

                if ((keywordIndex + 1) == keyword.Length)
                    keywordIndex = 0;
            }

            return Encoding.Unicode.GetBytes(result);
        }

        public byte[] Decrypt(byte[] data)
        {
            string input = Encoding.Unicode.GetString(data).ToUpper();
            string keyword = _key.ToUpper();
            string result = "";

            int keywordIndex = 0;

            foreach (char symbol in input)
            {
                int p = (Array.IndexOf(_characters, symbol) + _characters.Length -
                    Array.IndexOf(_characters, keyword[keywordIndex])) % _characters.Length;

                result += _characters[p];

                keywordIndex++;

                if ((keywordIndex + 1) == keyword.Length)
                    keywordIndex = 0;
            }

            return Encoding.Unicode.GetBytes(result);
        }
    }
}
