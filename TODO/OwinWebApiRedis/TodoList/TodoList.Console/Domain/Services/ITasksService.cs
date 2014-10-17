﻿using System;
using System.Collections.Generic;
using TodoList.Console.UI.Models;

namespace TodoList.Console.Domain.Services
{
    public interface ITasksService
    {
        IList<Task> GetAll();
        Task GetById(Guid id);
        Task Save(Task task);
        Task Update(Task task);
        void Delete(Guid id);
    }
}
