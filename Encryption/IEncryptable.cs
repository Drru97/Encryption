namespace Encryption
{
    /// <summary>
    /// Provides methods to encrypt and decrypt data using RC4 algorithm
    /// </summary>
    public interface IEncryptable
    {
        /// <summary>
        /// Encrypts input byte array of data using RC4 algorithm
        /// </summary>
        /// <param name="data">Data that you want to encrypt</param>
        /// <returns>Byte array of encrypted data</returns>
        byte[] Encrypt(byte[] data);

        /// <summary>
        /// Decrypts encrypted byte array
        /// </summary>
        /// <param name="data">Data that you want to decrypt</param>
        /// <returns>Byte array of decrypted data</returns>
        byte[] Decrypt(byte[] data);
    }
}
