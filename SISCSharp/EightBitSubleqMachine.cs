using System;
using System.Collections.Generic;
using System.Text;

namespace SISCSharp
{
    // requirements based in part by https://rosettacode.org/wiki/Subleq
    public class EightBitSubleqMachine
    {
        private sbyte[] memory { get; set; } = new sbyte[256];

        private byte a = 0; // address of val to subtract from memory[b]
        private byte b = 0; // address to store result of subtraction
        private byte c = 0; // address to branch to if result <= 0

        private byte ip = 0; // instruction pointer, points to the next subleq instruction run

        public EightBitSubleqMachine(sbyte[] memory)
        {
            for(int i = 0; i < memory.Length && i < 256; i++)
            {
                this.memory[i] = memory[i];
            }
        }

        public void Run()
        {   
            while (((sbyte)ip) != -1)
            {
                // load new instruction
                a = (byte) memory[ip];
                b = (byte) memory[ip + 1];
                c = (byte) memory[ip + 2];

                if ((sbyte)a == -1)
                {
                    // read byte
                    memory[b] = ((sbyte) Console.ReadKey().KeyChar);
                    ip += 3;
                }
                else if ((sbyte)b == -1)
                {
                    // write byte to output
                    Console.Write((char)memory[a]);
                    ip += 3;
                }
                else
                {
                    SUBLEQ();
                }
            }
        }

        private void SUBLEQ()
        {
            memory[b] = (sbyte)(memory[b] - memory[a]);
            
            if (memory[b] > 0)
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
