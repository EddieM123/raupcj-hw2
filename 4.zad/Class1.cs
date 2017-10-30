using _1.zad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.zad
{
    class Class1
    {
        static void Main(String[] args)
        {
            //int[] integers = new[] { 1, 3, 3, 4, 2, 2, 2, 3, 3, 4, 5 };
            //string[] asd = HomeworkLinqQueries.Linq1(integers);
            //Console.WriteLine(asd[1]);
            //Console.ReadKey();


            Student[] stud = new[]
            {
                new Student("Ivan", "001"),
                new Student("Marko", "002"),
                new Student("Ivana", "003"),
                new Student("Iva", "005")
            };

            Student[] stud1 = new[]
            {
                new Student("Ivan", "001"),
                new Student("Marko", "002"),
            };

            Student[] stud2 = new[]
            {
                new Student("Ivan", "001"),
            };

            Student[] stud3 = new[]
            {
                new Student("Ivan", "001"),
                new Student("Marko", "002"),
                new Student("Iva", "005")
            };

            University[] uni = new[]
            {
                new University("uni1", stud),
                new University("uni2", stud1),
                new University("uni3", stud2),
                new University("uni4", stud3)
            };


            

            Console.ReadKey();


        }
    }
}
