using WebApiExam.Core.BusinessModels.Contract;

using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace WebApiExam.Core.Repository
{
    public interface ICategoryRepository
    {
        Task<IResponseModel> AddCategoryAsync(ICategoryModel model);
        Task<List<ICategoryModel>> GetCategoriesAsync(Guid userid);
        Task<IResponseModel> UpdateCategoryAsync(ICategoryModel model);
        Task<IResponseModel> DeleteCategoryAsync(Guid categoryid);
    }
}
