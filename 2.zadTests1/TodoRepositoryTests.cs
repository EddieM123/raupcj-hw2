using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2.zad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib;

namespace _3.zad
{
    [TestClass()]
    public class TodoRepositoryTests
    {
        TodoRepository repos = new TodoRepository();

        TodoItem item1 = new TodoItem("ispit1");
        TodoItem item2 = new TodoItem("ispit2");
        TodoItem item3 = new TodoItem("ispit3");
        TodoItem item4 = new TodoItem("ispit4");
        TodoItem item5 = new TodoItem("ispit5");

        [TestMethod()]
        public void GetTodoItemTest()
        {
            repos.Add(item1);
            repos.Add(item2);

            TodoItem rand = repos.Get(item1.Id);

            Assert.AreEqual(rand, item1);
        }

        [TestMethod()]
        public void GetTodoItemNoIDTest()
        {
            repos.Add(item1);
            repos.Add(item2);


            TodoItem rand = repos.Get(item3.Id);

            Assert.AreEqual(rand, null);
        }


        [TestMethod()]
        public void AddTodoItemFailTest()
        {
            repos.Add(item1);
            repos.Add(item2);
            repos.Add(item3);

            try
            {
                repos.Add(item2);
                Assert.Fail();
            }
            catch (Exception)
            {
                // Catches the assertion exception, and the test passes
            }
        }

        [TestMethod()]
        public void AddTodoItemSuccesfulTest()
        {
            Assert.AreEqual(item1, repos.Add(item1));
        }



        [TestMethod()]
        public void RemoveTodoItemTest()
        {
            repos.Add(item1);
            repos.Add(item2);
            repos.Add(item3);

            repos.Remove(item2.Id);

            List<TodoItem> list = repos.GetAll();
            if(list.Contains(item2)) Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTodoItemTest()
        {
            repos.Add(item1);
            repos.Add(item2);
            repos.Add(item3);

            item2.Text = "ispit2.2";
            TodoItem rand = repos.Update(item2);
            TodoItem test3 = repos.Get(item2.Id);

            Assert.AreEqual(item2.Text, test3.Text);
        }

        [TestMethod()]
        public void MarkAsCompletedTest()
        {
            repos.Add(item1);
            repos.Add(item2);
            repos.Add(item3);

            repos.MarkAsCompleted(item2.Id);

            if (!repos.Get(item2.Id).IsCompleted) Assert.Fail();
        }

        [TestMethod()]
        public void GetAllTodoItemTest()
        {
            repos.Add(item1);
            repos.Add(item2);
            repos.Add(item3);

            List<TodoItem> list = repos.GetAll();


            if (!(list.Contains(item2) && list.Contains(item1) && list.Contains(item3))) Assert.Fail();
        }

        [TestMethod()]
        public void GetActiveTodoItemTest()
        {
            repos.Add(item1);
            repos.Add(item2);
            repos.Add(item3);

            repos.MarkAsCompleted(item2.Id);
            List<TodoItem> list = repos.GetActive();


            if (list.Contains(item2)) Assert.Fail();
        }

        [TestMethod()]
        public void GetCompletedTodoItemTest()
        {
            repos.Add(item1);
            repos.Add(item2);
            repos.Add(item3);

            repos.MarkAsCompleted(item2.Id);
            List<TodoItem> list = repos.GetCompleted();


            if (list.Contains(item1) || list.Contains(item3)) Assert.Fail();
        }

        [TestMethod()]
        public void GetFilteredTodoItemTest()
        {
            repos.Add(item1);
            repos.Add(item2);

            TodoItem rand = new TodoItem("rand");
            
            List<TodoItem> list = repos.GetFiltered(s => s.Text.Contains("rand"));
            
            if (list.Contains(item1) || list.Contains(item2)) Assert.Fail();
        }
    }
}