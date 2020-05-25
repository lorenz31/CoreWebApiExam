using System;

namespace WebApiExam.Core.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
