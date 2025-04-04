using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class DepartmentsController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
