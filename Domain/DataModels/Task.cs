using System;
using System.Collections.Generic;
using System.Text;
using Domain.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DataModels
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public bool IsComplete { get; set; }
        public Guid AssignedToId { get; set; }

        [ForeignKey("AssignedToId")]
        public Member member { get; set; }
    }
}