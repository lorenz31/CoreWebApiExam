using WebApiExam.Core.BusinessModels.Contract;
using WebApiExam.Core.BusinessModels.Implementation;

using System.Threading.Tasks;

namespace WebApiExam.Core.Repository
{
    public interface IUserRepository
    {
        Task<IResponseModel> RegisterUserAsync(IUserRegisterModel model);
        Task<IUserModel> VerifyUserAsync(IUserLoginModel model);
    }
}
