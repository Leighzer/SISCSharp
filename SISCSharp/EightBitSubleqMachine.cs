using System;
using System.Collections.Generic;
using System.Text;

namespace SISCSharp
{
    public class EightBitSubleqMachine
    {
        public sbyte[] Memory { get; set; }

        public byte a = 0; // address of val to subtract from Memory[b]
        public byte b = 0; // address to store result of subtraction
        public byte c = 0; // address to branch to if result <= 0

        public byte ip = 0; // instruction pointer, points to the next subleq instruction run

        public EightBitSubleqMachine(sbyte[] memory)
        {
            this.Memory = memory;
        }

        public void Run()
        {   
            while (ip >= 0)
            {
                // load new instruction
                a = (byte) Memory[ip];
                b = (byte) Memory[ip + 1];
                c = (byte) Memory[ip + 2];

                // if invalid memory values
                // add checks for address values, if special value - take input from console or output to console???
                if (((sbyte) a) < 0 || ((sbyte) b) < 0)
                {
                    // set ip to a halting value
                    ip = unchecked((byte) -1);
                }
                else
                {
                    SUBLEQ();
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
                ip = c;
            }
        }
    }
}
