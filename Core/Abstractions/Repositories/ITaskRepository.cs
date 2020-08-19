using System;
using System.Collections.Generic;
using System.Text;
using Domain.DataModels;
using Core.Abstractions.Repositories;

namespace Core.Abstractions.Repositories
{
    public interface ITaskRepository: IBaseRepository<Guid, Task, ITaskRepository>
    {
    }
}
