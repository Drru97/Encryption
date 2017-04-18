using System.Linq;

namespace Encryption.Algorithms
{
    public class RC4 : IEncryptable
    {
        private const int Bitrate = 256;
        private byte[] _key;
        private int _counterX, _counterY;

        public RC4(byte[] key)
        {
            GenerateKey(key);
        }

        private void GenerateKey(byte[] key)
        {
            var keyLength = key.Length;
            _key = new byte[Bitrate];

            for (int i = 0; i < Bitrate; i++)
                _key[i] = (byte)i;

            int j = 0;
            for (int i = 0; i < Bitrate; i++)
            {
                j = (j + _key[i] + key[i % keyLength]) % Bitrate;
                _key.Swap(i, j);
            }
        }

        public byte[] Encrypt(byte[] data)
        {
            var temp = data.Take(data.Length).ToArray();
            var cipher = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
                cipher[i] = (byte)(temp[i] ^ KeyItem());

            return cipher;
        }

        public byte[] Decrypt(byte[] data)
        {
            return Encrypt(data);
        }

        private byte KeyItem()
        {
            _counterX = (_counterX + 1) % Bitrate;
            _counterY = (_counterY + _key[_counterX]) % Bitrate;

            _key.Swap(_counterX, _counterY);

            return _key[(_key[_counterX] + _key[_counterY]) % Bitrate];
        }
    }
}
