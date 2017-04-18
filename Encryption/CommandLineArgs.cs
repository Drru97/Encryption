using CommandLine;

namespace Encryption
{
    public class CommandLineArgs
    {
        [Option('e', "encrypt", HelpText = "Encrypt input file")]
        public bool Encrypt { get; set; }

        [Option('d', "decrypt", HelpText = "Decrypt input file")]
        public bool Decrypt { get; set; }

        [Option('i', "input", HelpText = "Input file")]
        public string InputFile { get; set; }

        [Option('o', "output", HelpText = "Output file")]
        public string OutputFile { get; set; }

        [Option('p', "password", HelpText = "Password to encrypt or decrypt")]
        public string Key { get; set; }
    }
}
