using WebApiExam.Core.BusinessModels.Contract;

using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiExam.Core.BusinessModels.Implementation
{
    public class AddProductModel : IAddProductModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        
        public string Image { get; set; }
        
        public bool IsDeleted { get; set; }
        
        public Guid? CategoryId { get; set; }
        
        [Required]
        public Guid UserId { get; set; }
    }
}
