using System;
using System.Collections.Generic;
using System.Text;
using Domain.DataModels;
using Core.Abstractions.Repositories;
using System.Threading.Tasks;
using Domain.Queries;
using Microsoft.EntityFrameworkCore;
using Domain.Commands;
using System.Threading;

namespace DataLayer
{
    public class TaskRepository : BaseRepository<Guid, Domain.DataModels.Task, TaskRepository>, ITaskRepository
    {
        public TaskRepository(FamilyTaskContext context) : base(context)
        { }

        public async Task<List<Domain.DataModels.Task>> GetAllTask()
        {
            return await this.Query.Include(m => m.member).ToListAsync();
        }

        public override async Task<Domain.DataModels.Task> CreateRecordAsync(Domain.DataModels.Task newTask, CancellationToken cancellationToken = default) {
            var result = await this.Context.AddAsync(newTask, cancellationToken);
            await this.Context.SaveChangesAsync(cancellationToken);
            return await this.Query.Include(m => m.member).FirstOrDefaultAsync(x => x.Id == result.Entity.Id);
        }

        ITaskRepository IBaseRepository<Guid, Domain.DataModels.Task, ITaskRepository>.NoTrack()
        {
            return base.NoTrack();
        }

        ITaskRepository IBaseRepository<Guid, Domain.DataModels.Task, ITaskRepository>.Reset()
        {
            return base.Reset();
        }
    }
}
