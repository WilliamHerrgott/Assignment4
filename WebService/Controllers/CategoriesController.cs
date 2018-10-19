using Assignment4;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;

namespace WebService.Controllers
{
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
        public IActionResult GetCategory(int id)
        {
            var category = _dataService.GetCategory(id);
            
            if (category == null) {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryPostAndPutModel category)
        {
            _dataService.CreateCategory(category.Name, category.Description);
            return Ok();
        }
    }
}
