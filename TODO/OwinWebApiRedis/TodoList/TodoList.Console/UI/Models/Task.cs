using System;

namespace TodoList.Console.UI.Models
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Task()
        {
            Id = Guid.Empty;
            Name = string.Empty;
        }
    }
}
