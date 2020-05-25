using WebApiExam.Core.BusinessModels.Contract;

using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiExam.Core.BusinessModels.Implementation
{
    public class CategoryModel : ICategoryModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public bool IsDeleted { get; set; }
        
        [Required]
        public Guid UserId { get; set; }
    }
}
