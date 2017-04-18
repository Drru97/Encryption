using System.Linq;

namespace Encryption.Algorithms
{
    public class Cesar : IEncryptable
    {
        private readonly int _key;

        public Cesar(int key)
        {
            //     if (key < 0 || key > 10)
            _key = key;
        }

        public byte[] Encrypt(byte[] data)
        {
            var temp = data.Take(data.Length).ToArray();

            for (int i = 0; i < data.Length; i++)
            {
                if (temp[i] < byte.MaxValue - _key)
                    temp[i] += (byte)_key;
                else
                    temp[i] = (byte)(0 + _key);
            }

            return temp;

        }

        public byte[] Decrypt(byte[] data)
        {
            var temp = data.Take(data.Length).ToArray();

            for (int i = 0; i < data.Length; i++)
                temp[i] -= (byte)_key;

            return temp;
        }
    }
}
