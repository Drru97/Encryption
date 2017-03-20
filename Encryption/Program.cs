using System;
using System.Text;

namespace Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new CommandLineArgs();
            var isValid = CommandLine.Parser.Default.ParseArgumentsStrict(args, options);

            //Console.WriteLine(options.Key);
            //Console.WriteLine(options.Decrypt);


            var crypt = new Encryption(Encoding.Default.GetBytes("qwerty"));

            var data = "Олег Чорний";
            var dataArray = Encoding.Default.GetBytes(data);

            Console.WriteLine($"Input string: {data}");

            Console.WriteLine("Input byte array:");
            foreach (var s in dataArray)
                Console.Write(s);

            var encryptedData = crypt.Encrypt(dataArray, dataArray.Length);

            Console.WriteLine("\nCrypted byte array:");
            foreach (var s in encryptedData)
                Console.Write(s);



            var encrypt = new Encryption(Encoding.Default.GetBytes("qwerty"));

            var decryptedData = encrypt.Decrypt(encryptedData, encryptedData.Length);

            Console.WriteLine("\nDecrypted byte array:");   
            foreach (var s in decryptedData)
                Console.Write(s);

            Console.WriteLine($"\nDecrypted string: {Encoding.Default.GetString(decryptedData)}");

            Console.ReadKey();
        }
    }
}
