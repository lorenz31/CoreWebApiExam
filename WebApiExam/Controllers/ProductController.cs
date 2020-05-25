using WebApiExam.Core.BusinessModels.Contract;
using WebApiExam.Core.Services;

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApiExam.Controllers
{
    [Authorize]
    [EnableCors("AllowSpecificOrigin")]
    [Produces("application/json")]
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        private IResponseModel _response;

        public ProductController(
            IProductService productService,
            IResponseModel response)
        {
            _productService = productService;
            _response = response;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> PostAddProductAsync([FromBody] IAddProductModel obj)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var isAdded = await _productService.AddProductAsync(obj);

            _response.Status = isAdded.Status;
            _response.Message = isAdded.Message;

            if (_response.Status)
                return Ok(_response);
            else
                return BadRequest(_response);
        }

        [HttpGet]
        [Route("{userid:guid}")]
        public async Task<IActionResult> GetProductsAsync(Guid userid)
        {
            var products = await _productService.GetProductsAsync(userid);

            if (products == null) return NoContent();

            return Ok(products);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> PutProductAsync([FromBody] IAddProductModel obj)
        {
            var isProdUpdated = await _productService.UpdateProductAsync(obj);

            _response.Status = isProdUpdated.Status ? true : false;
            _response.Message = isProdUpdated.Status ? "Product info updated" : "Error updating product";

            if (_response.Status)
                return Ok(_response);
            else
                return BadRequest(_response);
        }

        [HttpDelete]
        [Route("{prodid:guid}/delete")]
        public async Task<IActionResult> DeleteProductAsync(Guid prodid)
        {
            var isDeleted = await _productService.DeleteProductAsync(prodid);

            _response.Status = isDeleted.Status;
            _response.Message = isDeleted.Message;

            if (_response.Status)
                return Ok(_response);
            else
                return BadRequest(_response);
        }
    }
}
