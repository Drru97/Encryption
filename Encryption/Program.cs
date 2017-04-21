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
                //var key = Encoding.Unicode.GetBytes(options.Key); //for rc4
                //int key; // for cesar
                //if (!int.TryParse(options.Key, out key))
                //{
                //    throw new ArgumentException("Password must be an integer value for Cesar Encryption");
                //}
                int type = options.Type;
                var data = ByteConverter.ToByteArray(new FileStream(options.InputFile, FileMode.Open));
                int size = data.Length;
                IEncryptable crypt;
                switch (type)
                {
                    case 1:
                        var key = Encoding.Unicode.GetBytes(options.Key);
                        crypt = new RC4(key);
                        break;
                    case 2:
                        crypt = new Vinger(options.Key);
                        break;
                    case 3:
                        int keyCh;
                        if (!int.TryParse(options.Key, out keyCh))
                        {
                            throw new ArgumentException("Password must be an integer value for Chastokil Encryption");
                        }
                        crypt = new Chastokil(keyCh);
                        break;
                    case 4:
                        int keyCe;
                        if (!int.TryParse(options.Key, out keyCe))
                        {
                            throw new ArgumentException("Password must be an integer value for Cesar Encryption");
                        }
                        crypt = new Cesar(keyCe);
                        break;
                    default:
                        throw new ArgumentException("Type value must be in [1-4] interval");
                }

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
