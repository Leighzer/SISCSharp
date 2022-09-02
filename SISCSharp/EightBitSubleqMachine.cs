using System;
using System.Collections.Generic;
using System.Text;

namespace SISCSharp
{
    // requirements based in part by https://rosettacode.org/wiki/Subleq
    public class EightBitSubleqMachine
    {
        private sbyte[] _memory { get; set; } = new sbyte[256];

        private byte _a = 0; // address of val to subtract from memory[b]
        private byte _b = 0; // address to store result of subtraction
        private byte _c = 0; // address to branch to if result <= 0

        private byte _ip = 0; // instruction pointer, points to the next subleq instruction run

        public EightBitSubleqMachine(sbyte[] memory)
        {
            for(int i = 0; i < memory.Length && i < 256; i++)
            {
                this._memory[i] = memory[i];
            }
        }

        public void Run()
        {   
            while (((sbyte)_ip) != -1)
            {
                // load new instruction
                _a = (byte) _memory[_ip];
                _b = (byte) _memory[_ip + 1];
                _c = (byte) _memory[_ip + 2];

                if ((sbyte)_a == -1)
                {
                    // read byte
                    _memory[_b] = ((sbyte) Console.ReadKey().KeyChar);
                    _ip += 3;
                }
                else if ((sbyte)_b == -1)
                {
                    // write byte to output
                    Console.Write((char)_memory[_a]);
                    _ip += 3;
                }
                else
                {
                    SUBLEQ();
                }
            }
        }

        private void SUBLEQ()
        {
            _memory[_b] = (sbyte)(_memory[_b] - _memory[_a]);
            
            if (_memory[_b] > 0)
            {
                _ip += 3;
            }
            else
            {
                _ip = _c;
            }
        }
    }
}
