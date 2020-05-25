using WebApiExam.Core.BusinessModels.Contract;
using WebApiExam.Core.Repository;
using WebApiExam.Core.BusinessModels.Implementation;
using WebApiExam.Core.Models;
using WebApiExam.Infra.DataContext;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApiExam.Infra.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private DatabaseContext _db;
        private IResponseModel _response;

        public CategoryRepository(
            DatabaseContext db,
            IResponseModel response)
        {
            _db = db;
            _response = response;
        }

        public async Task<IResponseModel> AddCategoryAsync(ICategoryModel model)
        {
            try
            {
                var category = new Category
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    IsDeleted = false,
                    UserId = model.UserId
                };

                _db.Categories.Add(category);
                await _db.SaveChangesAsync();

                _response.Status = true;
                _response.Message = "Category successfully added.";

                return _response;
            }
            catch (Exception ex)
            {
                _response.Status = false;
                _response.Message = "Error adding category.";

                return _response;
            }
        }

        public async Task<IResponseModel> DeleteCategoryAsync(Guid categoryid)
        {
            try
            {
                var category = await _db.Categories.Where(p => p.Id == categoryid).SingleOrDefaultAsync();

                category.IsDeleted = true;

                _db.Update(category);
                await _db.SaveChangesAsync();

                _response.Status = true;
                _response.Message = "Category successfully deleted.";

                return _response;
            }
            catch (Exception ex)
            {
                _response.Status = false;
                _response.Message = "Error deleting category.";

                return _response;
            }
        }

        public async Task<List<ICategoryModel>> GetCategoriesAsync(Guid userid)
        {
            List<ICategoryModel> categoryList = new List<ICategoryModel>();

            var categories = await _db.Categories.Where(p => p.UserId == userid).OrderBy(p => p.Name).ToListAsync();

            if (categories.Count > 0)
            {
                foreach (var category in categories)
                {
                    categoryList.Add(new CategoryModel
                    {
                        Id = category.Id,
                        Name = category.Name,
                        IsDeleted = category.IsDeleted,
                        UserId = category.UserId
                    });
                }

                return categoryList;
            }

            return null;
        }

        public async Task<IResponseModel> UpdateCategoryAsync(ICategoryModel model)
        {
            try
            {
                _db.Update(new Category { Name = model.Name });
                await _db.SaveChangesAsync();

                _response.Status = true;
                _response.Message = "Category successfully updated.";

                return _response;
            }
            catch (Exception ex)
            {
                _response.Status = false;
                _response.Message = "Error updating category.";

                return _response;
            }
        }
    }
}
