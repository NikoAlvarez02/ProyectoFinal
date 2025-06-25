using MvcCentroPsicopedagogico.BaseDeDatosFicticia;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using MvcCentroPsicopedagogico.Models;

namespace MvcCentroPsicopedagogico.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password, string tipo)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(tipo))
            {
                ViewBag.Error = "Complete todos los campos.";
                return View();
            }

            if (tipo == "admin")
            {
                var user = FakeUserDB.Users.FirstOrDefault(u => u.User == username && u.Password == password);

                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, username),
                        new Claim("TipoUsuario", "Admin")
                    };

                    var identity = new ClaimsIdentity(claims, "Cookies");
                    var principal = new ClaimsPrincipal(identity);

                    HttpContext.Session.SetString("User", username);
                    await HttpContext.SignInAsync("Cookies", principal);

                    return RedirectToAction("Index", "Home");
                }
            }
            else if (tipo == "profesional")
            {
                var profesional = _context.Profesionales.FirstOrDefault(p => p.Usuario == username && p.Password == password);

                if (profesional != null)
                {
                    var claims = new List<Claim>
                    {
                         new Claim(ClaimTypes.Name, profesional.Usuario),
                         new Claim("TipoUsuario", "Profesional")
                    };

                    var identity = new ClaimsIdentity(claims, "Cookies");
                    var principal = new ClaimsPrincipal(identity);

                    HttpContext.Session.SetString("User", profesional.Usuario);
                    await HttpContext.SignInAsync("Cookies", principal);

                    return RedirectToAction("Pacientes", "Home");
                }
            }

            ViewBag.Error = "Credenciales inválidas.";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }

    }
}
