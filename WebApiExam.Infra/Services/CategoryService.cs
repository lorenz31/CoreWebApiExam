using WebApiExam.Core.BusinessModels.Contract;
using WebApiExam.Core.Services;
using WebApiExam.Core.Repository;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiExam.Infra.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepo;

        public CategoryService(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<IResponseModel> AddCategoryAsync(ICategoryModel model) => await _categoryRepo.AddCategoryAsync(model);

        public async Task<List<ICategoryModel>> GetCategoriesAsync(Guid userid) => await _categoryRepo.GetCategoriesAsync(userid);

        public async Task<IResponseModel> UpdateCategoryAsync(ICategoryModel model) => await _categoryRepo.UpdateCategoryAsync(model);

        public async Task<IResponseModel> DeleteCategoryAsync(Guid categoryid) => await _categoryRepo.DeleteCategoryAsync(categoryid);
    }
}
