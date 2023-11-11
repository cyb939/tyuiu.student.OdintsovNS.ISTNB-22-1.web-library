using Microsoft.AspNetCore.Mvc;
using tyuiu.student.OdintsovNS.ISTNB_22_1.web_library.DataModels;
using tyuiu.student.OdintsovNS.ISTNB_22_1.web_library.Models;

namespace tyuiu.student.OdintsovNS.ISTNB_22_1.web_library.Controllers
{
    public class RegBookController : Controller
    {
        private MyDBContext context;

        public IActionResult Index()
        {
            ViewBag["Person"] = context.Persons.AsEnumerable();
            return View(new RegBook { Books = context.Books,Rooms = context.Room });
        }
        public RegBookController(MyDBContext context)
        {
            this.context = context;
        }
    }
}
