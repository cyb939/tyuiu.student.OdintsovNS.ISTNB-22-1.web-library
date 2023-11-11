using Microsoft.AspNetCore.Mvc;

namespace tyuiu.student.OdintsovNS.ISTNB_22_1.web_library.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
