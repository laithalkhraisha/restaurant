using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Helpers;
using Restaurant.ViewModels;
using System.Threading.Tasks;
 

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountsController : Controller
    {
        public UserManager<IdentityUser> UserManager { get; }
        public SignInManager<IdentityUser> SignInManager { get; }
        public AccountsController(UserManager<IdentityUser> _UserManager, SignInManager<IdentityUser> _SignInManager)
        {
            UserManager = _UserManager;
            SignInManager = _SignInManager;
        }

        [Authorize]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(Register collection)
        {
            


            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Error Data");
                    return View();
                }
                var User = new IdentityUser
                {
                    Email = collection.Email,
                    UserName = collection.Email


                };
                var result = await UserManager.CreateAsync(User, collection.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(User, isPersistent: false);
                    return RedirectToAction("Login", "Accounts");
                }
                else
                {
                    ModelState.AddModelError("", "Error Data");
                    return View();
                }


            }
            catch
            {
                return View();
            }
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Login collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "password or username wrong");
                    return View();
                }

                var result = await SignInManager.PasswordSignInAsync(collection.Email, collection.Password, isPersistent: collection.RememberMe, false);
                if (result.Succeeded)
                {

                    CommonHelpers.UserID =  UserManager.FindByEmailAsync(collection.Email).Result.Id;

                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("", "password or username wrong");
                    return View();
                }


            }
            catch
            {
                return View();
            }

        }
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
