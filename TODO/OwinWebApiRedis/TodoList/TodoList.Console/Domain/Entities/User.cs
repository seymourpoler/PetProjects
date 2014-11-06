using System;

namespace TodoList.Console.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public User()
        {
            Id = Guid.Empty;
            Name = string.Empty;
            Email = string.Empty;
            PassWord = string.Empty;
        }
    }
}
