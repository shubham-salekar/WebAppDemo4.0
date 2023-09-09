using Microsoft.AspNetCore.Mvc;
using WebAppDemo4._0.Models;

namespace WebAppDemo4._0.controller
{
    public class HomeController : Controller
    {
        private IEmpRepository _EmpRepository;

        public HomeController(IEmpRepository EmpRepository)
        {
            _EmpRepository = EmpRepository;
        }
        public string Index()
        {
            //return Json( new { id = 1 , name = "max"});
            return _EmpRepository.GetEmployee(1).Name;
        }
        public ViewResult Details()
        {
            return View(_EmpRepository.GetEmployee(1));
        }
    }
}
