using System;
using System.Collections.Generic;
using System.Text;
using Domain.DataModels;
using Core.Abstractions.Repositories;
using System.Threading.Tasks;

namespace Core.Abstractions.Repositories
{
    public interface ITaskRepository: IBaseRepository<Guid, Domain.DataModels.Task, ITaskRepository>
    {
        Task<List<Domain.DataModels.Task>> GetAllTask();
    }
}
