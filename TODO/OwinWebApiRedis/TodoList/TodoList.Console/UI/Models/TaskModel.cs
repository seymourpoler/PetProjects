using System;

namespace TodoList.Console.UI.Models
{
    public class TaskModel
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public string description { get; set; }

        public StateTaskModel state { get; set; }

        public TaskModel()
        {
            id = Guid.Empty;
            title  = string.Empty;
            description = string.Empty;
            state = StateTaskModel.Open;
        }
    }
}
