using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4
{
    internal class Bai1
    {
        public delegate void Delegate(int a, int b);
        class MathOperations
        {
            public void Add(int a, int b)
            {
                Console.WriteLine("Add result: {0}", a + b);
            }

            public void Sub(int a, int b)
            {
                Console.WriteLine("Sub result: {0}", a - b);
            }

            public void Mul(int a, int b)
            {
                Console.WriteLine("Mul result: {0}", a * b);
            }

            static void Main(String[] args)
            {
                Console.WriteLine("---Delegete Example---");
                MathOperations m = new MathOperations();
                Delegate dlgt = m.Add;

                dlgt += m.Sub;
                dlgt += m.Mul;

                dlgt(10, 90);

                Console.ReadLine();

            }

        }
    }
}
