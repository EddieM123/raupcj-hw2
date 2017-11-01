using lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace _2.zad
{
    /// <summary >
    /// Class that encapsulates all the logic for accessing TodoTtems .
    /// </ summary >
    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </ summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;

        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<TodoItem>();
            }
            // Shorter way to write this in C# using ?? operator :
            // x ?? y = > if x is not null , expression returns x. Else it will  return y.
            // _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >();
        }

        public TodoItem Get(Guid todoId)
        {
            if (_inMemoryTodoDatabase.Select(s => s.Id).Contains(todoId)) return _inMemoryTodoDatabase.Where(s => s.Id == todoId).First();
            else return null;
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Contains(todoItem)) throw new DuplicateTodoItemException($" duplicate id: {todoItem.Id}");
            else
            {
                _inMemoryTodoDatabase.Add(todoItem);
                return todoItem;
            }
        }
        public bool Remove(Guid todoId)
        {
            if (_inMemoryTodoDatabase.Remove(_inMemoryTodoDatabase.Where(s => s.Id == todoId).First())) return true;
            else return false;
        }

        /// Updates given TodoItem in the database .
        /// If TodoItem does not exist , method will add one .
        /// </ summary >
        /// <returns > TodoItem that was updated </ returns >
        public TodoItem Update(TodoItem todoItem)
        {
            if (!(_inMemoryTodoDatabase.Contains(todoItem)))
            {
                _inMemoryTodoDatabase.Add(todoItem);
                return todoItem;
            }
            else
            {
                TodoItem old = _inMemoryTodoDatabase.Where(s => s.Id == todoItem.Id).First();
                _inMemoryTodoDatabase.Remove(old);
                _inMemoryTodoDatabase.Add(todoItem);
                return todoItem;
            }
        }

        /// <summary >
        /// Tries to mark a TodoItem as completed in the database .
        /// </ summary >
        /// <returns > True if success , false otherwise </ returns >
        public bool MarkAsCompleted(Guid todoId)
        {
            TodoItem x = _inMemoryTodoDatabase.Where(s => s.Id == todoId).First();
            if (x == null || x.IsCompleted) return false;
            else
            {
             x.MarkAsCompleted();
             return true;
            }
        }

        /// Gets all TodoItem objects in the database , sorted by date created (descending )
        /// </ summary >
        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(s => s.DateCreated).ToList();
        }

        /// Gets all incomplete TodoItem objects in the database
        /// </ summary >
        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(s => s.IsCompleted is false).OrderByDescending(s => s.DateCreated).ToList();
        }

        /// Gets all completed TodoItem objects in the database
        /// </ summary >
        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(s => s.IsCompleted is true).OrderByDescending(s => s.DateCreated).ToList();
        }

        /// Gets all TodoItem objects in database that apply to the filter
        /// </ summary >
        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(filterFunction).OrderByDescending(s => s.DateCreated).ToList();
        }






        /// <summary>
        /// ///////////////////////////
        /// </summary>
        [Serializable]
        internal class DuplicateTodoItemException : Exception
        {
            public DuplicateTodoItemException()
            {
            }

            public DuplicateTodoItemException(string message) : base(message)
            {
            }

            public DuplicateTodoItemException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected DuplicateTodoItemException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}
