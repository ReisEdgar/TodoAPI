using System;
using System.Collections.Generic;
using TasksAPI.Models;

namespace TasksAPI.Database
{
    public class TasksDb
    {
        public List<TodoItemDto> Tasks;
        private static TasksDb _instance;

        private TasksDb()
        {
            Tasks = new List<TodoItemDto>
            {
                new TodoItemDto
                {
                    Id = 1,
                    Title = "Go shopping",
                    Description = "Lorem ipsum",
                    Status = TodoItemStatus.OPEN,
                    EndDate = DateTime.Today
                },
                new TodoItemDto
                {
                    Id = 2,
                    Title = "Do laundry",
                    Description = "dfgdf gdfhjk jkdf gdfjh dfgkjdfg",
                    Status = TodoItemStatus.DONE,
                    EndDate = DateTime.Now
                }
            };
        }

        public static TasksDb Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TasksDb();

                return _instance;
            }
        }
    }
}