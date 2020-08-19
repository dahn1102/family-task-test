using System;
using System.Collections.Generic;
using System.Text;
using Domain.DataModels;
using Core.Abstractions.Repositories;

namespace DataLayer
{
    public class TaskRepository : BaseRepository<Guid, Task, TaskRepository>, ITaskRepository
    {
        public TaskRepository(FamilyTaskContext context) : base(context)
        { }

        ITaskRepository IBaseRepository<Guid, Task, ITaskRepository>.NoTrack()
        {
            return base.NoTrack();
        }

        ITaskRepository IBaseRepository<Guid, Task, ITaskRepository>.Reset()
        {
            return base.Reset();
        }
    }
}
