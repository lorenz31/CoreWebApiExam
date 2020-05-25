using WebApiExam.Core.BusinessModels.Contract;
using WebApiExam.Core.BusinessModels.DTO;
using WebApiExam.Core.Repository;
using WebApiExam.Core.Models;
using WebApiExam.Infra.DataContext;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApiExam.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        private DatabaseContext _db;
        private IResponseModel _response;

        public ProductRepository(
            DatabaseContext db,
            IResponseModel response)
        {
            _db = db;
            _response = response;
        }

        public async Task<IResponseModel> AddProductAsync(IAddProductModel model)
        {
            try
            {
                var product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    IsDeleted = false,
                    CategoryId = model.CategoryId,
                    UserId = model.UserId
                };

                _db.Products.Add(product);
                await _db.SaveChangesAsync();

                _response.Status = true;
                _response.Message = "Product successfully added.";

                return _response;
            }
            catch (Exception ex)
            {
                _response.Status = false;
                _response.Message = "Error adding product.";

                return _response;
            }
        }

        public async Task<List<ProductsDTO>> GetProductsAsync(Guid prodid)
        {
            List<ProductsDTO> productsDTOs = new List<ProductsDTO>();

            try
            {
                return await _db.Products
                    .AsNoTracking()
                    .Join(
                        _db.Categories,
                        prod => prod.CategoryId,
                        cat => cat.Id,
                        (prod, cat) => new { prod, cat }
                    )
                    .Where(p => p.prod.Id == prodid)
                    .Select(p => new ProductsDTO
                    {
                        ProductId = p.prod.Id,
                        Name = p.prod.Name,
                        Description = p.prod.Description,
                        Image = p.prod.Image,
                        IsDeleted = p.prod.IsDeleted,
                        Category = p.cat.Name,
                        UserId = p.prod.UserId
                    })
                    .OrderBy(p => p.Name)
                    .ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IResponseModel> DeleteProductAsync(Guid prodid)
        {
            try
            {
                var product = await _db.Products.Where(p => p.Id == prodid).SingleOrDefaultAsync();

                product.IsDeleted = true;

                _db.Update(product);
                await _db.SaveChangesAsync();

                _response.Status = true;
                _response.Message = "Product successfully deleted.";

                return _response;
            }
            catch (Exception ex)
            {
                _response.Status = false;
                _response.Message = "Error deleting product.";

                return _response;
            }
        }

        public async Task<IResponseModel> UpdateProductAsync(IAddProductModel model)
        {
            try
            {
                _db.Update(new Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    Image = model.Image,
                    CategoryId = model.CategoryId
                });

                await _db.SaveChangesAsync();

                _response.Status = true;
                _response.Message = "Product successfully updated.";

                return _response;
            }
            catch (Exception ex)
            {
                _response.Status = false;
                _response.Message = "Error updating Product.";

                return _response;
            }
        }
    }
}
