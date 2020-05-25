using WebApiExam.Core.BusinessModels.Contract;

using System;

namespace WebApiExam.Core.BusinessModels.Implementation
{
    public class UserModel : IUserModel
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}
