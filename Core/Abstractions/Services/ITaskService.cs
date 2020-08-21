using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Commands;
using Domain.Queries;

namespace Core.Abstractions.Services
{
    public interface ITaskService
    {
        Task<CreateTaskCommandResult> CreateTaskCommandHandler(CreateTaskCommand command);
        Task<UpdateTaskCommandResult> UpdateTaskCommandHandler(UpdateTaskCommand command);
        Task<int> DeleteTaskCommandHandler(Guid id);
        Task<GetAllTasksQueryResult> GetAllTasksQueryHandler();
    }
}
