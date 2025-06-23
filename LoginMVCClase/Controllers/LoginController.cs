using LoginMVCClase.BaseDeDatosFicticia;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LoginMVCClase.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password) 
        {
            var user = FakeUserDB.Users.FirstOrDefault(u => u.User == username && u.Password == password);

            if (user != null)
            {

                var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, username)
                            };

                HttpContext.Session.SetString("User", user.User);
                var identity = new ClaimsIdentity(claims, "Cookies");
                var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync("Cookies", principal);


                return RedirectToAction("Index", "Home");
               
            }
            else
            {
                ViewBag.Error = "Credenciales Invalidas";
            }
                return View();
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Login");
        }
    }
}
