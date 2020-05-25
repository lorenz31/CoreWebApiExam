using WebApiExam.Core.Services;
using WebApiExam.Core.BusinessModels.Implementation;
using WebApiExam.Core.BusinessModels.Contract;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace WebApiExam.Controllers
{
    [Authorize]
    [EnableCors("AllowSpecificOrigin")]
    [Produces("application/json")]
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        private IResponseModel _response;

        public CategoryController(
            ICategoryService categoryService,
            IResponseModel response)
        {
            _categoryService = categoryService;
            _response = response;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> PostAddCategoryAsync([FromBody] CategoryModel obj)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var isAdded = await _categoryService.AddCategoryAsync(obj);

            _response.Status = isAdded.Status;
            _response.Message = isAdded.Message;

            if (_response.Status)
                return Ok(_response);
            else
                return BadRequest(_response);
        }

        [HttpGet]
        [Route("{userid:guid}")]
        public async Task<IActionResult> GetCategoriesAsync(Guid userid)
        {
            var categories = await _categoryService.GetCategoriesAsync(userid);

            if (categories == null) return NoContent();

            return Ok(categories);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> PutCategoryAsync([FromBody] CategoryModel obj)
        {
            var isCatUpdated = await _categoryService.UpdateCategoryAsync(obj);

            _response.Status = isCatUpdated.Status ? true : false;
            _response.Message = isCatUpdated.Status ? "Category updated" : "Error updating category";

            if (_response.Status)
                return Ok(_response);
            else
                return BadRequest(_response);
        }

        [HttpDelete]
        [Route("{categoryid:guid}/delete")]
        public async Task<IActionResult> DeleteCategoryAsync(Guid categoryid)
        {
            var isDeleted = await _categoryService.DeleteCategoryAsync(categoryid);

            _response.Status = isDeleted.Status;
            _response.Message = isDeleted.Message;

            if (_response.Status)
                return Ok(_response);
            else
                return BadRequest(_response);
        }
    }
}
