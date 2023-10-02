using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAppDemo4._0.ViewModels;

namespace WebAppDemo4._0.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
                                SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "home");
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var User = new IdentityUser { UserName = model.Email, Email = model.Email };
                var Result = await userManager.CreateAsync(User,model.Password);

                if(Result.Succeeded)
                {
                    await signInManager.SignInAsync(User, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                foreach(var error in Result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
            }
            return View();
        }
    }
}
