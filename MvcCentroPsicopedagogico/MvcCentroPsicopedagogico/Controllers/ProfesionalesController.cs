using Microsoft.AspNetCore.Mvc;

public class ProfesionalesController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProfesionalesController(ApplicationDbContext context)
    {
        _context = context;
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
    public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Especialidad,Email,Activo")] Profesional profesional)
    {
        if (id != profesional.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(profesional);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Profesional modificado correctamente";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesionalExists(profesional.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        return View(profesional);
    }

    private bool ProfesionalExists(int id)
    {
        return _context.Profesionales.Any(e => e.Id == id);
    }
}