using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiExam.Core.BusinessModels.Contract
{
    public interface IAddProductModel
    {
        string Name { get; set; }
        string Description { get; set; }
        string Image { get; set; }
        bool IsDeleted { get; set; }
        Guid? CategoryId { get; set; }
        Guid UserId { get; set; }
    }
}
