using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace SISCSharp
{
    public class Program
    {   
        public static void Main(string[] args)
        {
            List<string> largs = new List<string>(args);

            if (largs.Count < 1)
            {
                Console.WriteLine($"{largs.Count} arguments received. An input file must be provided");
                return;
            }

            string inputFilePath = largs[0];

            // arg validation
            bool inputFileExists = File.Exists(inputFilePath);
            if (!inputFileExists)
            {
                Console.WriteLine("Input file does not exist.");
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
    }
}
