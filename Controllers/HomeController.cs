using Microsoft.AspNetCore.Mvc;
using System;
using WebAppDemo4._0.Models;

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
        public string Index()
        {
            //return Json( new { id = 1 , name = "max"});
            Console.WriteLine("Index");
            return _MockEmpRepository.GetEmployee(1).Name;

        }
        public ViewResult Details()
        {
            Console.WriteLine("Details");

            Employee model = _MockEmpRepository.GetEmployee(1);

            ViewBag.Employee = model;
            ViewBag.PageTitle = "Employe  Details";
            return View();

        }
    }
}
