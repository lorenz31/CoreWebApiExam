using System;
using System.Collections.Generic;

namespace WebApiExam.Core.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public List<Product> Products { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
