using Microsoft.AspNetCore.Mvc;
using Route.C41_G03.BLL.Interface;
using Route.C41_G03DAL.Models;

namespace Route.C41_G03.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departRepository)
        {
            _departmentRepository = departRepository;
        }
        public IActionResult Index()
        {
            var departments = _departmentRepository.GetAll();
            return View(departments);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.Add(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

    }
}
