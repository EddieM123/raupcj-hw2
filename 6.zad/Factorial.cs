using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.zad
{
    public class Factorial
    {
        public static void Main(String[] args)
        {
            int n = 5;
            
            var task = FactorialDigitSumAsync(n);
            int result = task.Result;

            Console.WriteLine(result);
            Console.ReadKey();
        }


        public static async Task<int> FactorialDigitSumAsync(int n)
        {
           int x = await count(n);
           return x;
        }

        public static async Task<int> count(int x)
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
