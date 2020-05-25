using System;

namespace WebApiExam.Core.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }

        public Category Category { get; set; }
        public Guid? CategoryId { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
