using System.Text;
using Encryption.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class CesarTests
    {
        [TestMethod]
        public void CanEncryptData()
        {
            const string data = "Oleg Dutsyak";
            var bytes = Encoding.UTF8.GetBytes(data);
            int size = bytes.Length;
            const int key = 4;
            var cesar = new Cesar(key);

            var encryptedBytes = cesar.Encrypt(bytes);

            for (int i = 0; i < size; i++)
                Assert.AreEqual(encryptedBytes[i], bytes[i] + key);
        }

        [TestMethod]
        public void CanDecryptData()
        {
            const string data = "Hello world";
            const int key = 7;
            var cesar = new Cesar(key);
            var bytes = Encoding.UTF8.GetBytes(data);

            var encryptedBytes = cesar.Encrypt(bytes);
            var decryptedBytes = cesar.Decrypt(encryptedBytes);

            for (int i = 0; i < bytes.Length; i++)
                Assert.AreEqual(bytes[i], decryptedBytes[i]);

        }
    }
}
