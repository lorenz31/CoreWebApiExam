using WebApiExam.Core.BusinessModels.Contract;

using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace WebApiExam.Core.Services
{
    public interface ICategoryService
    {
        Task<IResponseModel> AddCategoryAsync(ICategoryModel model);
        Task<List<ICategoryModel>> GetCategoriesAsync(Guid userid);
        Task<IResponseModel> UpdateCategoryAsync(ICategoryModel model);
        Task<IResponseModel> DeleteCategoryAsync(Guid categoryid);
    }
}
