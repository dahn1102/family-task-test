﻿using Domain.Commands;
using Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebClient.Abstractions;
using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;

namespace WebClient.Services
{
    public class TaskDataService : ITaskDataService
    {
        private HttpClient _httpClient;
        public TaskDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CreateTaskCommandResult> Create(CreateTaskCommand command)
        {            
            return await _httpClient.PostJsonAsync<CreateTaskCommandResult>("tasks", command);
        }

        public async Task<GetAllTasksQueryResult> GetAllTasks()
        {
            return await _httpClient.GetJsonAsync<GetAllTasksQueryResult>("tasks");
        }

        public async Task<UpdateTaskCommandResult> Update(UpdateTaskCommand command)
        {
            return await _httpClient.PutJsonAsync<UpdateTaskCommandResult>($"tasks/{command.Id}", command);
        }

        public async Task<HttpResponseMessage> Delete(Guid Id)
        {
            return await _httpClient.DeleteAsync($"tasks/{Id}");
        }
    }
}
