using WebApiExam.Core.BusinessModels.Contract;

using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiExam.Core.BusinessModels.Implementation
{
    public class UserRegisterModel : IUserRegisterModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
