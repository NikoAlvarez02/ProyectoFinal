using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCentroPsicopedagogico.Models;

namespace MvcCentroPsicopedagogico.Controllers
{
    public class PacientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PacientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Listado
        public async Task<IActionResult> Pacientes()
        {
            var pacientes = await _context.Pacientes.ToListAsync();
            return View(pacientes);
        }

        // GET: Crear
        public IActionResult Crear()
        {
            return View();
        }

        // POST: Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Paciente paciente)
        {
            if (ModelState.IsValid)
            {

                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction("Pacientes", "Home");
            }
            return View(paciente);
        }

        // GET: Profesionales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        // POST: Profesionales/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               _context.Update(paciente);
               await _context.SaveChangesAsync();
               TempData["SuccessMessage"] = "Paciente modificado correctamente";
               return RedirectToAction("Pacientes", "Home");
                
            }
            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
                return NotFound();

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();

            return RedirectToAction("Pacientes", "Home");
        }


    }
}

