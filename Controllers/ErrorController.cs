using Microsoft.AspNetCore.Mvc;

namespace WebAppDemo4._0.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Could Not Found 404";
                    break;
                case 500:
                    ViewBag.ErrorMessage = "something went wrong 500";
                    break;
                default:
                    ViewBag.ErrorMessage = "default error";
                    break;
            }
            return View("NotFound");
        }
    }
}
