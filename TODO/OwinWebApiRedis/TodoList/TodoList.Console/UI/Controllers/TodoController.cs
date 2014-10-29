﻿using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using TodoList.Console.UI.Models;
using TodoList.Console.UI.Mappers;
using TodoList.Console.Domain.Entities;
using TodoList.Console.Domain.Services;

namespace TodoList.Console.UI.Controllers
{
    public class TodoController : ApiController
    {
        private readonly ITaskMapper _taskMapper;
        private readonly ITasksService _tasksService;

        public TodoController(ITasksService tasksService, ITaskMapper taskMapper)
        {
            _tasksService = tasksService;
            _taskMapper = taskMapper;
        }

        public HttpResponseMessage Get()
        {
            try
            {
                var tasks = _tasksService.GetAll();
                IList<TaskModel> tasksModels = _taskMapper.ToModel(tasks);
                return Request.CreateResponse(HttpStatusCode.OK, tasksModels);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        public HttpResponseMessage Get(Guid id)
        {
            try
            {
                var task = _tasksService.GetById(id);
                var taskModel = _taskMapper.ToModel(task);
                return Request.CreateResponse(HttpStatusCode.OK, taskModel);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        public HttpResponseMessage Post(TaskModel task)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Los datos no son correctos.");
                }
                var taskEntity = _taskMapper.ToEntity(task);
                var taskSaved = _tasksService.Save(taskEntity);
                var taskModel = _taskMapper.ToModel(taskSaved);
                return Request.CreateResponse(HttpStatusCode.OK, taskModel);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        public HttpResponseMessage Put(TaskModel task)
        {
            try
            {
                var taskEntity = _taskMapper.ToEntity(task);
                var taskModelUpdated = _tasksService.Update(taskEntity);
                var taskModel = _taskMapper.ToModel(taskModelUpdated);
                return Request.CreateResponse(HttpStatusCode.OK, taskModel);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                _tasksService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
