using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernDev
{
    static class Helpers
    {
        public static int[] CalculatePrimes(int number)
        {
            var factor = 2;
            var numbers = new List<int>();

            while (number != 1)
            {
                var rest = number / factor;

                if (rest * factor == number)
                {
                    numbers.Add(factor);
                    number = rest;
                }
                else
                    factor++;
            }

            return numbers.ToArray();
        }
    }
}
