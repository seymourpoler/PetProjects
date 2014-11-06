using System;
using System.Collections.Generic;

namespace TodoList.Console.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }

        public IList<Task> Tasks { get; set; }
        public User()
        {
            Id = Guid.Empty;
            Name = string.Empty;
            Email = string.Empty;
            PassWord = string.Empty;
            Tasks = new List<Task>();
        }
    }
}
