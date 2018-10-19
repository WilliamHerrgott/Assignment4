using Microsoft.AspNetCore.Mvc;
using Assignment4;

namespace WebService.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : Controller
    {
        DataService _dataService;
    }
}
