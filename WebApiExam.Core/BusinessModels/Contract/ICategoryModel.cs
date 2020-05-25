using System;

namespace WebApiExam.Core.BusinessModels.Contract
{
    public interface ICategoryModel
    {
        Guid Id { get; set; }
        string Name { get; set; }
        bool IsDeleted { get; set; }
        Guid UserId { get; set; }
    }
}
