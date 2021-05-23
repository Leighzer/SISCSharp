using System;
using System.Collections.Generic;
using System.Text;

namespace SISCSharp
{
    public class SISCMachine
    {
        public sbyte[] Memory { get; set; }

        public sbyte a, b, c;

        public byte ip = 0;

        public SISCMachine()
        {

        }

        public void Run()
        {
            while (ip >= 0)
            {
                a = Memory[ip];
                b = Memory[ip];
                c = Memory[ip];

                if (a < 0 || b < 0)
                {
                    
                }

            }
        }

        public void SUBLEQ()
        {
            Memory[b] = (sbyte)(Memory[b] - Memory[a]);

            if (Memory[b] > 0)
            {
                ip += 3;
            }
            else
            {
                ip = (byte) c;
            }
        }
    }
}
