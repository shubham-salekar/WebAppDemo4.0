using Microsoft.AspNetCore.Mvc;
using System;
using WebAppDemo4._0.Models;
using WebAppDemo4._0.ViewModel;

namespace WebAppDemo4._0.controller
{
    public class HomeController : Controller
    {
        private IEmpRepository _MockEmpRepository;

        public HomeController(IEmpRepository MockEmpRepository)  // EmpRepository is instance of mockEmpRepo because we set in singleton that whenever someone request for IEmpRepository obj we return mockEmpRepo obj .
        {
            Console.WriteLine("Homecontroller ctor start");
            _MockEmpRepository = MockEmpRepository;
            Console.WriteLine("Homecontroller ctor end");
        }

        public ViewResult Index()
        {
            var model = _MockEmpRepository.GetAllEmployees();
            return View(model);
        }

        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _MockEmpRepository.GetEmployee(id??1),
                PageTitle = "Employee Info"

            };
            return View(homeDetailsViewModel);

        }
        public ViewResult Create()
        {
            return View();
        }
    }
}
