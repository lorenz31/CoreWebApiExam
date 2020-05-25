using WebApiExam.Core.Jwt;
using WebApiExam.Core.BusinessModels.Implementation;
using WebApiExam.Core.BusinessModels.Contract;
using WebApiExam.Core.Services;
using WebApiExam.Core.Repository;

using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebApiExam.Infra.Services
{
    public class AccountService : IAccountService
    {
        private IUserRepository _userRepo;
        private IConfiguration _config;

        private IResponseModel _response;

        public AccountService(
            IUserRepository userRepo,
            IConfiguration config,
            IResponseModel response)
        {
            _userRepo = userRepo;
            _config = config;
            _response = response;
        }

        public async Task<IResponseModel> RegisterUserAsync(IUserRegisterModel model) => await _userRepo.RegisterUserAsync(model);

        public async Task<IUserModel> VerifyUserAsync(IUserLoginModel model) => await _userRepo.VerifyUserAsync(model);

        public TokenModel GenerateJwt(IUserModel model)
        {
            var token = new JwtTokenBuilder(_config);

            return new TokenModel
            {
                AccessToken = token.GenerateToken(),
                UserId = model.UserId,
                Name = model.Name
            };
        }
    }
}