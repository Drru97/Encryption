using CommandLine;

namespace Encryption
{
    public class CommandLineArgs
    {
        [Option('e', "encrypt", HelpText = "Encrypt input file")]
        public bool Encrypt { get; set; }

        [Option('d', "decrypt", HelpText = "Decrypt input file")]
        public bool Decrypt { get; set; }

        [Option(HelpText = "File to encrypt")]
        public string FileToEncrypt { get; set; }

        [Option(HelpText = "Encrypted file")]
        public string EncryptedFile { get; set; }

        [Option(HelpText = "File to decrypt")]
        public string FileToDecrypt { get; set; }

        [Option(HelpText = "Decrypted file")]
        public string DecryptedFile { get; set; }

        [Option('p', "password", HelpText = "Key")]
        public string Key { get; set; }
    }
}
