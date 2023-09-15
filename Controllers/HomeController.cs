using Microsoft.AspNetCore.Mvc;
using System;
using WebAppDemo4._0.Models;
using WebAppDemo4._0.ViewModel;

namespace WebAppDemo4._0.controller
{
    public class HomeController : Controller
    {
        private IEmpRepository _EmpRepository;

        public HomeController(IEmpRepository EmpRepository)  // EmpRepository is instance of mockEmpRepo because we set in singleton that whenever someone request for IEmpRepository obj we return mockEmpRepo obj .
        {
            Console.WriteLine("Homecontroller ctor start");
            _EmpRepository = EmpRepository;
            Console.WriteLine("Homecontroller ctor end");
        }

        public ViewResult Index()
        {
            var model = _EmpRepository.GetAllEmployees();
            return View(model);
        }

        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _EmpRepository.GetEmployee(id??1),
                PageTitle = "Employee Info"

            };
            return View(homeDetailsViewModel);  

        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = _EmpRepository.Add(employee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            return View();
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
    }
}
