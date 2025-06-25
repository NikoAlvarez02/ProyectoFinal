using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcCentroPsicopedagogico.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace MvcCentroPsicopedagogico.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;


        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var profesionales = await _context.Profesionales.ToListAsync();
            return View(profesionales);
        }

        public async Task<IActionResult> Pacientes()
        {
            var paciente = await _context.Pacientes.ToListAsync();
            return View(paciente);
        }




    }
}
