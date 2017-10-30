using _1.zad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.zad
{
    public class University
    {
        public string Name { get; set; }
        public Student[] Students { get; set; }

        public University(String _Name, Student[] studarr)
        {
            Name = _Name;
            Students = studarr;
        }
    }

    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            int num = intArray.Distinct().Count();
            int[] diff = intArray.Distinct().ToArray();
            string[] text = new string[num];

            for (int i = 0; i < num; i++)
            {
                text[i] = $"Broj {diff[i]} ponavlja se {intArray.Where(x => x == diff[i]).Count().ToString()} puta";
            }

            return text;
            
        }
        public static University[] Linq2_1(University[] universityArray)
        {
            //Napišite jedan LINQ izraz koji će vam vratiti sveučilišta na kojima studiraju samo muškarci

            return universityArray.Where(s => s.Students.Distinct().Count() == s.Students.Distinct().Where(x => x.Gender == Gender.Male).Count()).ToArray();
        }
        public static University[] Linq2_2(University[] universityArray)
        {
            //Napišite jedan ili kombinaciju više LINQ izraza koji će vam vratiti sveučilišta na kojima je ispod prosječan
            // broj studenata
            
            return universityArray.Where(x => x.Students.Count() < (((double)(universityArray.Sum(a => a.Students.Count()))/(double)(universityArray.Count())))).ToArray();
        }
        public static Student[] Linq2_3(University[] universityArray)
        {
            //Napišite jedan LINQ izraz koji će vam vratiti listu svih studenata u Hrvatskoj (bez duplikata, neki studenti mogu biti na više fakulteta odjednom).
            throw new NotImplementedException();

        }
        public static Student[] Linq2_4(University[] universityArray)
        {
            throw new NotImplementedException();
        }
        public static Student[] Linq2_5(University[] universityArray)
        {
            throw new NotImplementedException();
        }
    }
}
