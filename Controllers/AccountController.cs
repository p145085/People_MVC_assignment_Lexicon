using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using People_MVC_assignment_Lexicon.Models.Basemodels;
using People_MVC_assignment_Lexicon.Models.ViewModels;
using System.Text.RegularExpressions;

namespace People_MVC_assignment_Lexicon.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> usermanager, SignInManager<AppUser> signInManager)
        {
            _userManager = usermanager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser(CreateAccountViewModel cavm)
        {
            if (ModelState.IsValid)
            {
                

                AppUser createdUser = new AppUser()
                {
                    FirstName = cavm.FirstName,
                    LastName = cavm.LastName,
                    BirthDate = cavm.BirthDate,
                    NickName = cavm.NickName,
                    UserName = cavm.NickName,
                    Email = cavm.Email

                };

                
                if (!string.IsNullOrEmpty(cavm.NickName))
                {
                    createdUser.NickName = cavm.NickName;
                }

                Regex regex = new Regex(@"^[a-zA-Z0-9]+$");
                if (!regex.IsMatch(createdUser.NickName))
                {
                    // The NickName property contains invalid characters.
                    // Add a model error to the ModelState object.
                    ModelState.AddModelError("NickName", "Only letters and digits are allowed in the NickName field.");
                }

                IdentityResult result = await _userManager.CreateAsync(createdUser, cavm.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }

                foreach (var identityError in result.Errors)
                {
                    ModelState.AddModelError(identityError.Code, identityError.Description);
                }

                //
                foreach (var key in ModelState.Keys)
                {
                    var propertyErrors = ModelState[key];
                    if (propertyErrors.Errors.Count > 0)
                    {
                        // Loop through the error messages and print them to the console.
                        foreach (var error in propertyErrors.Errors)
                        {
                            Console.WriteLine(error.ErrorMessage);
                        }
                    }
                }
                //

            }
            return View(cavm);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(CreateAccountViewModel userLogin)
        {
            // Ambiguous => SignInResult
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(userLogin.NickName, userLogin.Password, false, false);
            if (result.IsNotAllowed)
            {
                ViewBag.Msg = "Nope.";
            }
            if (result.IsLockedOut)
            {
                ViewBag.Msg = "Banned or something.";
            }
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //[AutoValidateAntiforgeryToken]
        //public async IActionResult NewAccount(CreateAccountViewModel cavm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        AppUser createdUser = new AppUser();
        //        createdUser.NickName = cavm.Username;
        //        createdUser.PasswordHash = cavm.Password;
        //        IdentityResult result = await _userManager.CreateAsync(createdUser, CreateAccountViewModel.Password);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //    }
        //    return View(createdUser);
        //}
    }
}
