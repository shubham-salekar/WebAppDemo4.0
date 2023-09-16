﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.IO;
using WebAppDemo4._0.Models;
using WebAppDemo4._0.ViewModel;
using WebAppDemo4._0.ViewModels;

namespace WebAppDemo4._0.controller
{
    public class HomeController : Controller
    {
        private IEmpRepository _EmpRepository;
        private IWebHostEnvironment _hostingEnvironment;

        public HomeController(IEmpRepository EmpRepository , IWebHostEnvironment hostingEnvironment)  
        {
            _EmpRepository = EmpRepository;
            _hostingEnvironment = hostingEnvironment;

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
        public IActionResult Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(model.Photos != null && model.Photos.Count > 0)
                {
                    foreach (IFormFile photo in model.Photos) { 
                    
                        string UploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString()+ "_" + photo.FileName;
                        string FilePath = Path.Combine(UploadFolder, uniqueFileName);
                        photo.CopyTo(new FileStream(FilePath, FileMode.Create));
                    }
                }
                Employee newEmployee = new Employee()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileName
                };
                _EmpRepository.Add(newEmployee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            return View();
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }  
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _EmpRepository.GetEmployee(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel()
            {
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,

            };
            return View(employeeEditViewModel);
        }
    }
}
