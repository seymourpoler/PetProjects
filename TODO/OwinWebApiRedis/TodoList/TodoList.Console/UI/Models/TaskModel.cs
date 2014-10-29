using System;
using ServiceStack.DataAnnotations;

namespace TodoList.Console.UI.Models
{
    public class TaskModel
    {
        public Guid id { get; set; }
        [Required]
        public string title { get; set; }
        public string description { get; set; }

        [Range(1,3)]
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
