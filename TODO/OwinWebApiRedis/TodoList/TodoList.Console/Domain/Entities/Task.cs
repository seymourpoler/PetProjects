using System;

namespace TodoList.Console.Domain.Entities
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public StateTask State { get; set; }
        
        public Task()
        {
            Id = Guid.Empty;
            Title  = string.Empty;
            Description = string.Empty;
            State = StateTask.Open;
        }
    }
}
