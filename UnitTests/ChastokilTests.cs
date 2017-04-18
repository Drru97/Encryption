using System.Text;
using Encryption.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class ChastokilTests
    {
        [TestMethod]
        public void CanEncryptData()
        {
            const string data = "Oleg Dutsyak";
            var bytes = Encoding.Unicode.GetBytes(data);
            int size = bytes.Length;
            const int key = 2;
            var chastokil = new Chastokil(key);

            var encryptedBytes = chastokil.Encrypt(bytes);
            string encryptedString = Encoding.Unicode.GetString(encryptedBytes);

            Assert.AreEqual("lgDtykOe usa", encryptedString);
        }

        [TestMethod]
        public void CanDecryptData()
        {
            const string data = "Hello world";
            const int key = 2;
            var chastokil = new Chastokil(key);
            var bytes = Encoding.Unicode.GetBytes(data);

            var encryptedBytes = chastokil.Encrypt(bytes);
            var decryptedBytes = chastokil.Decrypt(encryptedBytes);

            for (int i = 0; i < bytes.Length; i++)
                Assert.AreEqual(bytes[i], decryptedBytes[i]);
        }
    }
}
