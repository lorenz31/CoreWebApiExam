using System;

namespace WebApiExam.Core.BusinessModels.Contract
{
    public interface IUserModel
    {
        Guid UserId { get; set; }
        string Name { get; set; }
    }
}
