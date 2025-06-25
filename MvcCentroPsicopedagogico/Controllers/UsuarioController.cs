using MvcCentroPsicopedagogico.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;


namespace MvcCentroPsicopedagogico.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        string connectionString = @"Server=localhost\SQLEXPRESS;Database=ProgrammingV;Trusted_Connection=True;TrustServerCertificate=True;";






    }
}
