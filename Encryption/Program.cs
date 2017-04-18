using System;
using System.IO;
using System.Text;
using Encryption.Algorithms;

namespace Encryption
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var options = new CommandLineArgs();
            bool isValid = CommandLine.Parser.Default.ParseArgumentsStrict(args, options);

            if (isValid)
                Operations(options);
            else
                Console.WriteLine("Incorrect arguments");
        }

        private static void Operations(CommandLineArgs options)
        {
            try
            {
                var key = Encoding.Unicode.GetBytes(options.Key);
                var data = ByteConverter.ToByteArray(new FileStream(options.InputFile, FileMode.Open));
                int size = data.Length;
                var crypt = new RC4(key);

                if (options.Encrypt)
                {
                    var encryptedData = crypt.Encrypt(data);
                    using (var writer = new BinaryWriter(File.Open(options.OutputFile, FileMode.OpenOrCreate)))
                    {
                        writer.Write(encryptedData);
                    }
                }
                else if (options.Decrypt)
                {
                    var decryptedData = crypt.Decrypt(data);
                    using (var writer = new BinaryWriter(File.Open(options.OutputFile, FileMode.OpenOrCreate)))
                    {
                        writer.Write(decryptedData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
