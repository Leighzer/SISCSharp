using System;
using System.Collections.Generic;
using System.Text;

namespace SISCSharp
{
    public class Experiments
    {
        // just making sure casts are clean from sbyte to byte
        public static void TryMapSbyteToByte()
        {
            sbyte test = sbyte.MinValue;
            HashSet<string> binaryStrings = new HashSet<string>();
            int count = 0;
            for (int i = sbyte.MinValue; i <= sbyte.MaxValue; i++)
            {
                byte test2 = (byte)test;

                binaryStrings.Add(Program.Pad(test2));

                if (test == 0)
                {
                    Console.WriteLine("ZERO -------------------");
                }

                Console.WriteLine(Program.Pad(test2));

                count++;
                test++;
            }

            Console.WriteLine(count == binaryStrings.Count);

            //Console.WriteLine(Pad(test));            

            //Console.WriteLine(Pad(test2));

            //Console.ReadLine();
        }

        // just making sure casts are clean from byte to sbyte
        public static void TryMapByteToSbyte()
        {
            byte test = byte.MinValue;
            HashSet<string> binaryStrings = new HashSet<string>();
            int count = 0;
            for (int i = byte.MinValue; i <= byte.MaxValue; i++)
            {
                sbyte test2 = (sbyte)test;

                binaryStrings.Add(Program.Pad(test2));

                if (test == 0)
                {
                    Console.WriteLine("ZERO -------------------");
                }

                Console.WriteLine(Program.Pad(test2));

                count++;
                test++;
            }

            Console.WriteLine(count == binaryStrings.Count);

            //Console.WriteLine(Pad(test));            

            //Console.WriteLine(Pad(test2));

            //Console.ReadLine();
        }
    }
}
