
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

public class TurnosController : Controller
{
    private readonly ApplicationDbContext _context;

    public TurnosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Turnos/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var turno = await _context.Turnos
            .Include(t => t.Profesional)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (turno == null)
        {
            return NotFound();
        }

        ViewData["ProfesionalId"] = new SelectList(_context.Profesionales, "Id", "NombreCompleto", turno.ProfesionalId);
        return View(turno);
    }

    // POST: Turnos/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Hora,Paciente,Observaciones,Estado,ProfesionalId")] Turno turno)
    {
        if (id != turno.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(turno);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Turno modificado correctamente";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurnoExists(turno.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        ViewData["ProfesionalId"] = new SelectList(_context.Profesionales, "Id", "NombreCompleto", turno.ProfesionalId);
        return View(turno);
    }

    private bool TurnoExists(int id)
    {
        return _context.Turnos.Any(e => e.Id == id);
    }
}