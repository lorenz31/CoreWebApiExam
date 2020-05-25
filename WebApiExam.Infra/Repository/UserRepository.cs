using WebApiExam.Core.BusinessModels.Contract;
using WebApiExam.Core.BusinessModels.Implementation;
using WebApiExam.Core.Repository;
using WebApiExam.Core.Security;
using WebApiExam.Core.Models;
using WebApiExam.Infra.DataContext;

using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApiExam.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private DatabaseContext _db;
        private IResponseModel _response;

        public UserRepository(
            DatabaseContext db,
            IResponseModel response)
        {
            _db = db;
            _response = response;
        }

        public async Task<IResponseModel> RegisterUserAsync(IUserRegisterModel model)
        {
            try
            {
                var salt = PasswordHash.GenerateSalt();
                var passwordHash = PasswordHash.ComputeHash(model.Password, salt);

                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Username = model.Username,
                    Password = Convert.ToBase64String(passwordHash),
                    Salt = Convert.ToBase64String(salt)
                };

                _db.Users.Add(user);
                await _db.SaveChangesAsync();

                _response.Status = true;
                _response.Message = "User registration successful.";

                return _response;
            }
            catch (Exception ex)
            {
                _response.Status = false;
                _response.Message = "User registration error.";

                return _response;
            }
        }

        public async Task<IUserModel> VerifyUserAsync(IUserLoginModel model)
        {
            try
            {
                var userInfo = await _db.Users.Where(u => u.Username == model.Username).SingleOrDefaultAsync();

                if (userInfo != null)
                {
                    var salt = Convert.FromBase64String(userInfo.Salt);
                    var hashPassword = Convert.FromBase64String(userInfo.Password);
                    var isVerified = PasswordHash.VerifyPassword(model.Password, salt, hashPassword);

                    if (!isVerified)
                        return null;
                    else
                    {
                        return new UserModel
                        {
                            UserId = userInfo.Id,
                            Name = userInfo.Name
                        };
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
