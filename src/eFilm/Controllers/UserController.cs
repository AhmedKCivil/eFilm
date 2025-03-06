using eFilm.Data;
using eFilm.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;

namespace eFilm.Controllers
{
    public class UserController : Controller
    {
        //private readonly ApplicationDbContext _db;
        //private readonly SignInManager<AccountUser> _signInManager;
        //private readonly UserManager<AccountUser> _userManager;

        //public UserController(ApplicationDbContext db, UserManager<AccountUser> userManager, SignInManager<AccountUser> signInManager)
        //{
        //    _db = db;
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //}

        //public async Task<IActionResult> Users()
        //{
        //    var users = await _db.UsersTable.ToListAsync();
        //    return View(users);
        //}

        ////Get

        //public IActionResult Login() => View(new LoginVM());

        ////Post

        
        ////LOGIN
        //public async Task<IActionResult> Login(LoginVM loginVM)
        //{
        //    var user = await _userManager.FindByNameAsync(loginVM.Name);
        //    if (user != null)
        //    {
        //        var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
        //        if (passwordCheck)
        //        {
        //            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
        //            if (result.Succeeded)
        //            {
        //                return RedirectToAction("Index", "Movies");

        //            }
        //        }
        //        TempData["Error"] = "Wrong credentials. Please try again.";
        //        return View(loginVM);
        //    }
        //    TempData["Error"] = "Wrong credentials. Please, try again!";
        //    return View(loginVM);
        //}

        ////REGISTER

        //[HttpGet]
        //public IActionResult Register() => View(new RegisterVM());

        //[HttpPost]
        //public async Task<IActionResult> ProcessRegister(RegisterVM registerVM)
        //{
        //    //if (!ModelState.IsValid) return View(registerVM);

        //    var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
        //    if (user != null)
        //    {
        //        TempData["Error"] = "This Email is already in use";
        //        return View(registerVM);
        //    }

        //    var newUser = new AccountUser()
        //    {
        //        FullName = registerVM.Name,
        //        Password = registerVM.Password,
        //        EmailAddress = registerVM.EmailAddress
        //    };

        //    var newUserResponse = await _userManager.CreateAsync(newUser);

        //    if (newUserResponse.Succeeded)

                
        //    TempData["SuccessMessage"] = $"User {newUser.FullName} has been registered successfully!";

        //    _db.UsersTable.Add(newUser);
        //    _db.SaveChanges();
        //    return View("RegisterCompleted");

            
            
           

            
        //}



    }
}
