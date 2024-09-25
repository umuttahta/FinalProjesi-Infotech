using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChocolateAppClient.Models;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;


namespace ChocolateAppClient.Controllers
{
    [Route("[controller]")]
    public class ServicesController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }

       
    }
}