﻿namespace WebApiExam.Core.BusinessModels.Contract
{
    public interface IUserLoginModel
    {
        string Username { get; set; }
        string Password { get; set; }
    }
}
