﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Commands;
using Domain.Queries;
using System.Net.Http;

namespace WebClient.Abstractions
{
    public interface ITaskDataService
    {
        public Task<CreateTaskCommandResult> Create(CreateTaskCommand command);
        public Task<UpdateTaskCommandResult> Update(UpdateTaskCommand command);
        public Task<HttpResponseMessage> Delete(Guid id);
        public Task<GetAllTasksQueryResult> GetAllTasks();
    }
}
