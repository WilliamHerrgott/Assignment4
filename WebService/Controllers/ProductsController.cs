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
    [Route("api/products")]
    [ApiController]
    public class ProductsController : Controller
    {
        DataService _dataService;
    }
}
