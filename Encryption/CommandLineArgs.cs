using CommandLine;

namespace Encryption
{
    public class CommandLineArgs
    {
        [Option('e', "encrypt", HelpText = "Encrypt input file")]
        public bool Encrypt { get; set; }

        [Option('d', "decrypt", HelpText = "Decrypt input file")]
        public bool Decrypt { get; set; }
        
        [Option('t', "type",
            HelpText ="Select Encryption algorythm:\t 1 - RC4\t 2 - Vigener \t 3 - Chastokil\t 4 - Cesar",
            DefaultValue = 1)]
        public int Type { get; set; }

        [Option('i', "input", HelpText = "Input file")]
        public string InputFile { get; set; }

        [Option('o', "output", HelpText = "Output file")]
        public string OutputFile { get; set; }

        [Option('p', "password", HelpText = "Password to encrypt or decrypt")]
        public string Key { get; set; }
    }
}
