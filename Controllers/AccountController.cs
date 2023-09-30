using Microsoft.AspNetCore.Mvc;

namespace WebAppDemo4._0.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
