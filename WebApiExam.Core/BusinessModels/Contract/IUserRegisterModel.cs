using System;

namespace WebApiExam.Core.BusinessModels.Contract
{
    public interface IUserRegisterModel
    {
        string Name { get; set; }
        string Username { get; set; }
        string Password { get; set; }
    }
}
