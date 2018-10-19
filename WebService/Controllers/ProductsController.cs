using System.Collections.Generic;
using System.Linq;
using Assignment4;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;

namespace WebService.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly DataService _dataService;

        public ProductsController(DataService dataService)
        {
            _dataService = dataService;
        }
        
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var cat = _dataService.GetProduct(id);
            if (cat == null) return NotFound();
            var _out = new ProductGetModel {Name = cat.Name, CategoryName = cat.Category.Name};
            return Ok(_out);
        }

        [HttpGet("category/{id}")]
        public IActionResult GetProductByCategoryId(int id)
        {
            var cat = _dataService.GetProductByCategory(id);
            if (cat == null) return NotFound("[]");
            var _out = cat.Select(c => new ListProductGetModel {ProductName = c.Name, CategoryName = c.Category.Name}).ToList();
            return Ok(_out);
        }
        
        [HttpGet("name/{sub}")]
        public IActionResult GetProductByCategoryId(string sub)
        {
            var cat = _dataService.GetProductByName(sub);
            if (cat == null) return NotFound("[]");
            return Ok(cat);
        }
    }
}
