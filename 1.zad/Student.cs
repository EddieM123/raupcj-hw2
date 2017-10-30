using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.zad
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }


        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }


        public static void Main()
        {
            Student.Case3();  
        }

        private static void case1()
        {
            {
                var topStudents = new List<Student>()
            {
             new Student (" Ivan ", jmbag :" 001234567 ") ,
             new Student (" Luka ", jmbag :" 3274272 ") ,
             new Student ("Ana", jmbag :" 9382832 ")
            };
                var ivan = new Student(" Ivan ", jmbag: " 001234567 ");


                Student s = topStudents.Where(a => a.Jmbag == ivan.Jmbag)
                     .FirstOrDefault();


                if (s != null) Console.WriteLine(true);
                else Console.WriteLine(false);

                Console.ReadKey();
            }
        }

        private static void Case2()
        {
            var list = new List<Student>()
            {
            new Student (" Ivan ", jmbag :" 001234567 ") ,
            new Student (" Ivan ", jmbag :" 001234567 ")
            };

            // 2 :(
            var distinctStudentsCount = list.Select(s => s.Jmbag).Distinct().Count();
            Console.WriteLine(distinctStudentsCount);
            Console.ReadKey();
        }

        private static void Case3()
        {
            var topStudents = new List<Student>()
            {
            new Student (" Ivan ", jmbag :" 001234567 ") ,
            new Student (" Luka ", jmbag :" 3274272 ") ,
            new Student ("Ana", jmbag :" 9382832 ")
            };
            var ivan = new Student(" Ivan ", jmbag: " 001234567 ");
            // false :(
            // == operator is a different operation from . Equals ()
            // Maybe it isn ’t such a bad idea to override it as well
            bool isIvanTopStudent = topStudents.Any(s => s.Equals(ivan));

            Console.WriteLine(isIvanTopStudent);
            Console.ReadKey();
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            Student x = (Student)obj;
            return (this.Jmbag == x.Jmbag) && (this.Name == x.Name);
        }
    }
    public enum Gender
    {
        Male, Female
    }



}
