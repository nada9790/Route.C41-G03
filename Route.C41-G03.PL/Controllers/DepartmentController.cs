using Microsoft.AspNetCore.Mvc;

namespace Route.C41_G03.PL.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
