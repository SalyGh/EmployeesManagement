using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EmployeeProject.Data;
using EmployeeProject.Models;
using EmployeeProject.ViewModels;

namespace EmployeeProject.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<AppUser> _userManager; // what you are going to see the most when you are doing alot of coding for checking email and password before passing them to the signin manager 
		private readonly SignInManager<AppUser> _signinManager; // provides you with extentions  // for sign in and sig out 
		
		public AccountController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signinManager, ApplicationDbContext applicationDBContext)
		{
			this._userManager = _userManager;
			this._signinManager = _signinManager;
		
		}




		public IActionResult Login()
		{
			var response = new LoginViewModel();

			return View(response);
			// create a new one if the user type the password and click reload 
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginvm)
		{
			if (!ModelState.IsValid)
			{
				return View(loginvm);
			}
			else
			{

				// when someone is logging in, the first thing to do is to get that user from the databse 
				var user = await _userManager.FindByEmailAsync(loginvm.EmailAddress);

				if (user == null)
				{
					TempData["Error"] = "Please Try Again";
					return View(loginvm);

				}
				else
				{
					// user is found - check password 
					var passwordCheck = await _userManager.CheckPasswordAsync(user, loginvm.Password); // it always gonna return an asynchronise boolean value 
					if (passwordCheck)
					{
						var result = await _signinManager.PasswordSignInAsync(user, loginvm.Password, false, false); // login process with the password - result.Succeeded = a method provided by the sign in manager 
						
						if (result.Succeeded)// password correct 
						{
							return RedirectToAction("Index", "Employee");
						}
						else // password is not correct 
						{
							TempData["Error"] = "Please Try Again";
							
							return View(loginvm);
						}

					}
					else
					{
						TempData["Error"] = "Please Try Again";
						return View(loginvm);

					}
				}

			}
            




        }
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
