using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAppDemo4._0.ViewModels;

namespace WebAppDemo4._0.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplocationUser> userManager;
        private readonly SignInManager<ApplocationUser> signInManager;

        public AccountController(UserManager<ApplocationUser> userManager,
                                SignInManager<ApplocationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "home");
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var User = new ApplocationUser { 
                    UserName = model.Email, 
                    Email = model.Email ,
                    City = model.City 
                };
                var Result = await userManager.CreateAsync(User, model.Password);

                if (Result.Succeeded)
                {
                    await signInManager.SignInAsync(User, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                foreach (var error in Result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AcceptVerbs("Get","Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var result = await userManager.FindByEmailAsync(email);
            if (result == null)
                return Json(true);
            else
                return Json($"Email{email} is already in use.");
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var Result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (Result.Succeeded)
                {
                    if( !string.IsNullOrEmpty(returnUrl) )
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError(string.Empty,"Invalid Login Credintial");


            }
            return View(model);
        }
    }
}
