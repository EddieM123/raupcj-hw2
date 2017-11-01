using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _6.zad
{
    public class Factorial
    {
        public static void Main(String[] args)
        {
            int n = 5;

            var x = FactorialDigitSumAsync(n);
            Console.WriteLine(x.Result);
            Console.ReadKey();
        }

        public static async Task<int> FactorialDigitSumAsync(int x)
        {
            var result = await Count(x);
            return result;
        }
        
        public static async Task<int> Count(int x)
        {
            int suma = 1;
            for (int i = 1; i <= x; i++)
            {
                suma = suma * i;
            }
            return suma;
        }
    }
}
