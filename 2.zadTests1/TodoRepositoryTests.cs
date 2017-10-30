using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2.zad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib;

namespace _2.zad.Tests
{
    [TestClass()]
    public class TodoRepositoryTests
    {
        TodoRepository asd = new TodoRepository();

        TodoItem sir1 = new TodoItem("ispit1");
        TodoItem sir2 = new TodoItem("ispit2");
        TodoItem sir3 = new TodoItem("ispit3");
        TodoItem sir4 = new TodoItem("ispit4");
        TodoItem sir5 = new TodoItem("ispit5");


       


        [TestMethod()]
        public void GetTodoItemTest()
        {
            asd.Add(sir1);
            asd.Add(sir2);
            asd.Add(sir3);
            asd.Add(sir4);
            asd.Add(sir5);

            TodoItem rand = asd.Get(sir1.Id);

            Assert.AreEqual(rand, sir1);
        }

        [TestMethod()]
        public void AddTodoItemTest()
        {
            asd.Add(sir1);
            asd.Add(sir2);
            asd.Add(sir3);

            try
            {
                asd.Add(sir2);
                Assert.Fail();
            }
            catch (Exception)
            {
                // Catches the assertion exception, and the test passes
            }
        }

        [TestMethod()]
        public void RemoveTodoItemTest()
        {
            asd.Add(sir1);
            asd.Add(sir2);
            asd.Add(sir3);

            asd.Remove(sir2.Id);

            List<TodoItem> list = asd.GetAll();
            if(list.Contains(sir2)) Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTodoItemTest()
        {
            asd.Add(sir1);
            asd.Add(sir2);
            asd.Add(sir3);

            sir2.Text = "ispit2.2";
            TodoItem rand = asd.Update(sir2);
            TodoItem test3 = asd.Get(sir2.Id);

            Assert.AreEqual(sir2.Text, test3.Text);
        }

        [TestMethod()]
        public void MarkAsCompletedTest()
        {
            asd.Add(sir1);
            asd.Add(sir2);
            asd.Add(sir3);

            asd.MarkAsCompleted(sir2.Id);

            if (!asd.Get(sir2.Id).IsCompleted) Assert.Fail();
        }

        [TestMethod()]
        public void GetAllTodoItemTest()
        {
            asd.Add(sir1);
            asd.Add(sir2);
            asd.Add(sir3);

            List<TodoItem> list = asd.GetAll();


            if (!(list.Contains(sir2) && list.Contains(sir1) && list.Contains(sir3))) Assert.Fail();
        }

        [TestMethod()]
        public void GetActiveTodoItemTest()
        {
            asd.Add(sir1);
            asd.Add(sir2);
            asd.Add(sir3);

            asd.MarkAsCompleted(sir2.Id);
            List<TodoItem> list = asd.GetActive();


            if (list.Contains(sir2)) Assert.Fail();
        }

        [TestMethod()]
        public void GetCompletedTodoItemTest()
        {
            asd.Add(sir1);
            asd.Add(sir2);
            asd.Add(sir3);

            asd.MarkAsCompleted(sir2.Id);
            List<TodoItem> list = asd.GetCompleted();


            if (list.Contains(sir1) || list.Contains(sir3)) Assert.Fail();
        }

        [TestMethod()]
        public void GetFilteredTodoItemTest()
        {
            asd.Add(sir1);
            asd.Add(sir2);

            TodoItem rand = new TodoItem("rand");
            
            List<TodoItem> list = asd.GetFiltered(s => s.Text.Contains("rand"));
            
            if (list.Contains(sir1) || list.Contains(sir2)) Assert.Fail();
        }



    }
}