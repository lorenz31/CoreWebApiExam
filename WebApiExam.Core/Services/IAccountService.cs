using WebApiExam.Core.BusinessModels.Contract;
using WebApiExam.Core.BusinessModels.Implementation;

using System.Threading.Tasks;

namespace WebApiExam.Core.Services
{
    public interface IAccountService
    {
        Task<IResponseModel> RegisterUserAsync(IUserRegisterModel model);
        Task<IUserModel> VerifyUserAsync(IUserLoginModel model);
        TokenModel GenerateJwt(IUserModel model);
    }
}