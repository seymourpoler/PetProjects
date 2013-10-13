using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using Entities;

namespace Web
{
    public partial class Default : System.Web.UI.Page
    {
        private TaskService _taskService;
        public Default()
        {
            _taskService = new TaskService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string action = Request["action"];
                
                switch (action)
                {
                    case "save":
                        SaveTask();
                        break;
                    case "load":
                    case "search":
                        LoadTasks();
                        break;
                    case "remove":
                        RemoveTask();
                        break;
                }
            }
            catch (Exception ex) { }
        }

        private void SaveTask() 
        {
            var newTask = new Task() { Name = Request["taskName"] };
            _taskService.AddNewTask(newTask);
            LoadTasks();
        }

        private void LoadTasks()
        {
            var tasks = _taskService.GetAllTasks();
            SendData(tasks.ToList<Task>());
        }

        private void RemoveTask()
        {
            var newTask = new Task() { Id = Convert.ToInt32(Convert.ToString(Request["idTask"])) };
            _taskService.RemoveTask(newTask);
            LoadTasks();
        }

        private void SendData(List<Task> tasks)
        {
            Response.ContentType = "application/json";
            Response.Write(tasks.ToJSON());
            Response.End();
        }
    }
}