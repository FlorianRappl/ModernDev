using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 
 * (c) Florian Rappl, 2012.
 * 
 * This work is a demonstration for training purposes and may be used freely for private purposes.
 * Usage for business training / workshops is prohibited without explicit permission from the author.
 * 
 */

namespace ModernDev
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;

            for (var i = 0; i < 10; i++)
                Console.WriteLine("{0} x {1} = {2}", a, i, a * i);
        }
    }
}
