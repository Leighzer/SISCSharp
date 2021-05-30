using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace SISCSharp
{
    public class Program
    {
        // needed args
        // input file/program to run
        // output file (write tape to)
        public static void Main(string[] args)
        {
            List<string> largs = new List<string>(args);

            if (largs.Count < 2)
            {
                Console.WriteLine($"{largs.Count} arguments received. An input file and output file must be provided");
            }

            string inputFilePath = largs[0];
            string outputFilePath = largs[1];

            bool overwriteExistingOutputFile = largs.Any(x => x == "-o");
            bool outputToConsole = largs.Any(x => x == "-c");

            // arg validation
            bool inputFileExists = File.Exists(inputFilePath);
            if (!inputFileExists)
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            bool outputFileExists = File.Exists(outputFilePath);
            if (outputFileExists && !overwriteExistingOutputFile)
            {
                Console.WriteLine("Output file already exists. Use arg flag -o to have this file overwritten.");
                return;
            }

            byte[] unsignedMemoryToLoad = new byte[256];
            using (FileStream ifs = new FileStream(inputFilePath, FileMode.Open))
            {
                ifs.Read(unsignedMemoryToLoad, 0, 256);
            }
            sbyte[] signedMemoryToLoad = unsignedMemoryToLoad.Select(x => (sbyte)x).ToArray();

            EightBitSubleqMachine subleqMachine = new EightBitSubleqMachine(signedMemoryToLoad);

            subleqMachine.Run();
        }

        public static string Pad(byte b)
        {
            return Convert.ToString(b, 2).PadLeft(8, '0');
        }

        // not super helpful since isn't toString for sbyte??
        public static string Pad(sbyte b)
        {
            return Convert.ToString(b, 2).PadLeft(8, '0');
        }
    }
}
