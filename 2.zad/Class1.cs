using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.zad
{
    public class Class1
    {
        static void Main(String[] args)
        {
            TodoRepository asd = new TodoRepository();

            TodoItem sir1 = new TodoItem("ispit1");
            TodoItem sir2 = new TodoItem("ispit2");
            TodoItem sir3 = new TodoItem("ispit3");
            TodoItem sir4 = new TodoItem("ispit4");
            TodoItem sir5 = new TodoItem("ispit5");

            sir2.MarkAsCompleted();
            sir3.MarkAsCompleted();

            asd.Add(sir1);
            asd.Add(sir2);
            asd.Add(sir3);
            asd.Add(sir4);
            asd.Add(sir5);

            List<TodoItem> test1 = asd.GetCompleted();


            foreach(TodoItem x in test1)
            {
                Console.WriteLine(x.Text);
            }

            Console.WriteLine("---------------");

            if (asd.Remove(sir5.Id))
            {
                List<TodoItem> test2 = asd.GetAll();


                foreach (TodoItem x in test2)
                {
                    Console.WriteLine(x.Text);
                }
            }

            Console.WriteLine("---------------");
            sir2.Text = "ispit2.2";
            TodoItem rand = asd.Update(sir2);
            List<TodoItem> test3 = asd.GetAll();
            foreach (TodoItem x in test3)
            {
                Console.WriteLine(x.Text);
            }

            Console.WriteLine("---------------");
            List<TodoItem> test4 = asd.GetActive();
            foreach (TodoItem x in test4)
            {
                Console.WriteLine(x.Text);
            }

            Console.WriteLine("---------------");
            List<TodoItem> test5 = asd.GetFiltered(s => s.Text.Contains("ispit"));
            foreach (TodoItem x in test5)
            {
                Console.WriteLine(x.Text);
            }



            Console.ReadKey();
        }
    }
}
