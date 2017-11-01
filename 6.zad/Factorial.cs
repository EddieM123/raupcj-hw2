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

            var x = Task.Run(() => FactorialDigitSumAsync(n));
            Console.ReadKey();
        }

        private static async Task FactorialDigitSumAsync(int x)
        {
            var result = await Count(x);
            Console.WriteLine(result);
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
