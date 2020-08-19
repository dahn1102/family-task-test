using System;
using System.Collections.Generic;
using System.Text;
using Domain.DataModels;

namespace Domain.DataModels
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public bool IsComplete { get; set; }
        public Guid AssignedToId { get; set; }
    }
}