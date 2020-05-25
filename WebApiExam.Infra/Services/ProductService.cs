using WebApiExam.Core.BusinessModels.Contract;
using WebApiExam.Core.BusinessModels.DTO;
using WebApiExam.Core.Services;
using WebApiExam.Core.Repository;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiExam.Infra.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepo;

        public ProductService(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<IResponseModel> AddProductAsync(IAddProductModel model) => await _productRepo.AddProductAsync(model);

        public async Task<IResponseModel> DeleteProductAsync(Guid prodid) => await _productRepo.DeleteProductAsync(prodid);

        public async Task<List<ProductsDTO>> GetProductsAsync(Guid prodid)
        {
            var products = await _productRepo.GetProductsAsync(prodid);

            if (products.Count > 0) return products;
            else return null;
        }

        public async Task<IResponseModel> UpdateProductAsync(IAddProductModel model) => await _productRepo.UpdateProductAsync(model);
    }
}
