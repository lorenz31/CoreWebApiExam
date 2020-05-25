using WebApiExam.Core.BusinessModels.Contract;
using WebApiExam.Core.BusinessModels.DTO;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiExam.Core.Repository
{
    public interface IProductRepository
    {
        Task<IResponseModel> AddProductAsync(IAddProductModel model);
        Task<List<ProductsDTO>> GetProductsAsync(Guid prodid);
        Task<IResponseModel> UpdateProductAsync(IAddProductModel model);
        Task<IResponseModel> DeleteProductAsync(Guid prodid);
    }
}
