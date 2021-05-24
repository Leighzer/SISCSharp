using System;
using System.Collections.Generic;

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

            string inputFile = largs[0];
            string outputFile = largs[1];
            bool overwriteExistingOutputFile = (largs[2] ?? "").ToLower() == "-o";

            // validate input file - make sure exists and we can read it

            // valid output file - if exists ask user if sure you want to overwrite (unless override arg is provided)

            // load subleq machine with input file

            // run subleq machine

            // write subleq machine tap to file

            // done
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
