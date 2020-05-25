using WebApiExam.Core.BusinessModels.Contract;

using System.ComponentModel.DataAnnotations;

namespace WebApiExam.Core.BusinessModels.Implementation
{
    public class UserLoginModel : IUserLoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
