using System;
using System.Collections.Generic;
using TodoList.Console.UI.Models;
using TodoList.Console.UI.Mappers;
using TodoList.Console.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TodoList.Tests.UI.Mappers
{
    [TestClass]
    public class TaskMapperTests
    {
        private ITaskMapper _taskMapper;

        [TestInitialize]
        public void Initialize()
        {
            _taskMapper = new TaskMapper();
        }

        [TestMethod]
        public void TaskMapper_ToEntity()
        {
            var taskModel = new TaskModel {  id = Guid.NewGuid(), title = "title", description = "description", state = StateTaskModel.InProgress };
            var taskEntity = _taskMapper.ToEntity(taskModel);

            Assert.IsInstanceOfType(taskEntity, typeof(Task));
            Assert.AreEqual(taskModel.id, taskEntity.Id);
            Assert.AreEqual(StateTask.InProgress, taskEntity.State);
            Assert.AreEqual(taskModel.description, taskEntity.Description);
        }

        [TestMethod]
        public void TaskMapper_ToModel()
        {
            var taskEntity = new Task { Id = Guid.NewGuid(), Title = "title", Description = "description", State = StateTask.InProgress };
            var taskModel = _taskMapper.ToModel(taskEntity);

            Assert.IsInstanceOfType(taskModel, typeof(TaskModel));
            Assert.AreEqual(taskEntity.Id, taskModel.id);
            Assert.AreEqual(StateTaskModel.InProgress, taskModel.state);
            Assert.AreEqual(taskEntity.Description, taskModel.description);
        }

        [TestMethod]
        public void TaskMapper_ToModel_list_of_entities()
        {
            var tasksEntity = new List<Task>{ new Task { Id = Guid.NewGuid(), Title = "title", Description = "description", State = StateTask.InProgress }, new Task { Title="", State = StateTask.Done }};
            var tasksModel = _taskMapper.ToModel(tasksEntity);

            Assert.IsInstanceOfType(tasksModel, typeof(List<TaskModel>));
            Assert.AreEqual(tasksEntity[0].Id, tasksModel[0].id);
            Assert.AreEqual(StateTaskModel.InProgress, tasksModel[0].state);
            Assert.AreEqual(StateTaskModel.Done, tasksModel[1].state);
        }
    }
}
