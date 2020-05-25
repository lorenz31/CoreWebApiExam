using System;

namespace WebApiExam.Core.BusinessModels.DTO
{
    public class ProductsDTO
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
        public string Category { get; set; }
        public Guid UserId { get; set; }
    }
}
