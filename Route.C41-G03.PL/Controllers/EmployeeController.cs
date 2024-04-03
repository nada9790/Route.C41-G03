using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Route.C41_G03.BLL.Repositories;
using Route.C41_G03DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.Extensions.Hosting;
using Route.C41_G03.BLL.Interface;

namespace Route.C41_G03.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _env;

        public EmployeeController(IEmployeeRepository employeeRepository, IWebHostEnvironment env)
        {
            _employeeRepository = employeeRepository;
            _env = env;
        }
        public IActionResult Index()
        {
            var Employees = _employeeRepository.GetAll();
            return View(Employees);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee Employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Add(Employee);
                return RedirectToAction(nameof(Index));
            }
            return View(Employee);
        }
        [HttpGet]
        //public IActionResult Details(int? id, string ViewName = "Details")
        //{
        //    if (!id.HasValue)
        //        return BadRequest();

        //  //  var Employee = _EmployeeRepository.GetById(id.Value);
        //    if (Employee is null)
        //        return NotFound();

        //    return View(ViewName, Employee);
        //}
        [HttpGet]
        //public IActionResult Edit(int? id)

        //{
        //    return Details(id, "Edit");
        //    //if(!id.HasValue)
        //    //    return BadRequest();
        //    //var Employee=_EmployeeRepository.GetById(id.Value);
        //    //if (Employee is null)
        //    //    return NotFound();
        //    //return View(Employee);
        //}
        [HttpPost]
        public IActionResult Edit(Employee Employee)
        {
            if (ModelState.IsValid)

                return View(Employee);

            try
            {
                _employeeRepository.Update(Employee);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                if (_env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    ModelState.AddModelError(string.Empty, "An Error Occured during update the Employee");
                return View(Employee);
            }

        }

    }
}
