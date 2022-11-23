using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebProjectLena.Models;

namespace WebProjectLena.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            // creating automatically a user that will serve as admin.
            // anyone who wants to get access to Admin actions, will have to login with these credentials. 
            IdentityUser user = new IdentityUser
            {
                UserName = "AllPowerfullAdmin",
            };

            await _userManager.CreateAsync(user, "Qwe!@#123Rt$");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Administrator");
                
                else
                    return RedirectToAction("Error", "Account");

            }
            return View();
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
