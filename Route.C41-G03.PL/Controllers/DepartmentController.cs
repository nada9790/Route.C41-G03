using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Route.C41_G03.BLL.Interface;
using Route.C41_G03DAL.Models;
using System;

namespace Route.C41_G03.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IWebHostEnvironment _env;

        public DepartmentController(IDepartmentRepository departRepository,IWebHostEnvironment env)
        {
            _departmentRepository = departRepository;
            _env = env;
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
        [HttpGet]
        public IActionResult Details(int? id, string ViewName = "Details")
        {
            if (!id.HasValue)
                return BadRequest();

            var department = _departmentRepository.GetById(id.Value);
            if (department is null)
                return NotFound();

            return View(ViewName, department);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
            
        {
            return Details(id, "Edit");
            //if(!id.HasValue)
            //    return BadRequest();
            //var Department=_departmentRepository.GetById(id.Value);
            //if (Department is null)
            //    return NotFound();
            //return View(Department);
        }
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if ( ModelState.IsValid)
        
                return View(department);

            try
            {
                _departmentRepository.Update(department);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

               if(_env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
               else
                    ModelState.AddModelError(string.Empty, "An Error Occured during update the department");
               return View(department);
            }
            
        }


    }
}
