using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCentroPsicopedagogico.Models;

public class ProfesionalesController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProfesionalesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Listado
    public async Task<IActionResult> Index()
    {
        var profesionales = await _context.Profesionales.ToListAsync();
        return View(profesionales);
    }

    // GET: Crear
    public IActionResult Crear()
    {
        return View();
    }

    // POST: Crear
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Crear(Profesional profesional)
    {
        if (ModelState.IsValid)
        {

            _context.Add(profesional);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }
        return View(profesional);
    }

    // GET: Profesionales/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var profesional = await _context.Profesionales.FindAsync(id);
        if (profesional == null)
        {
            return NotFound();
        }
        return View(profesional);
    }

    // POST: Profesionales/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Matricula,Nombre,Apellido,Especialidad,Email,Telefono,Activo,Usuario,Password")] Profesional profesional)
    {
        if (id != profesional.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            
                _context.Update(profesional);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Profesional modificado correctamente";
                return RedirectToAction("Index","Home");
            
        }
        return View(profesional);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var profesional = await _context.Profesionales.FindAsync(id);
        if (profesional == null)
            return NotFound();

        _context.Profesionales.Remove(profesional);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index","Home");
    }


}