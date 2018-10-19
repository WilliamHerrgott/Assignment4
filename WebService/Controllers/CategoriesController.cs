using Assignment4;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;

namespace WebService.Controllers {
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : Controller {
        private readonly DataService _dataService;

        public CategoriesController(DataService dataService) {
            _dataService = dataService;
        }

        [HttpGet]
        public IActionResult GetCategories() {
            var data = _dataService.GetCategories();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id) {
            var category = _dataService.GetCategory(id);

            if (category == null) {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryPostAndPutModel category) {
            var cat = _dataService.CreateCategory(category.Name, category.Description);

            return Created("", cat);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, CategoryPostAndPutModel category) {
            var cat = _dataService.UpdateCategory(id, category.Name, category.Description);
            if (cat == false) return NotFound();
            return Ok(cat);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id) {
            var cat = _dataService.DeleteCategory(id);

            if (cat == false) {
                return NotFound();
            }

            return Ok();
        }
    }
}