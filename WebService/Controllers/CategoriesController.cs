using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment4;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebService.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : Controller
    {
        DataService _dataService;

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, CategoryPostAndPutModel category)
        {
            var cat = _dataService.UpdateCategory(id, category.Name, category.Description);
            if (cat == null) return NotFound();
            return Ok(cat);
        }

        [HttpPut("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var cat = _dataService.DeleteCategory(id);
            if (cat == null) return NotFound();
            return Ok(cat);
        }

    }
}
