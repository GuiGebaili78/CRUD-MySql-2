using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDMysql.Repository.Context.DataBaseContext;
using crudmysql.Models;

namespace crudmysql.Controllers
{
    public class PacienteController : Controller
    {
        private readonly DataBaseContext _context;

        public PacienteController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: Paciente
        public async Task<IActionResult> Index()
        {
              return _context.PacienteModel != null ? 
                          View(await _context.PacienteModel.ToListAsync()) :
                          Problem("Entity set 'DataBaseContext.PacienteModel'  is null.");
        }

        // GET: Paciente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PacienteModel == null)
            {
                return NotFound();
            }

            var pacienteModel = await _context.PacienteModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacienteModel == null)
            {
                return NotFound();
            }

            return View(pacienteModel);
        }

        // GET: Paciente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paciente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] PacienteModel pacienteModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacienteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pacienteModel);
        }

        // GET: Paciente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PacienteModel == null)
            {
                return NotFound();
            }

            var pacienteModel = await _context.PacienteModel.FindAsync(id);
            if (pacienteModel == null)
            {
                return NotFound();
            }
            return View(pacienteModel);
        }

        // POST: Paciente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] PacienteModel pacienteModel)
        {
            if (id != pacienteModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacienteModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteModelExists(pacienteModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pacienteModel);
        }

        // GET: Paciente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PacienteModel == null)
            {
                return NotFound();
            }

            var pacienteModel = await _context.PacienteModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacienteModel == null)
            {
                return NotFound();
            }

            return View(pacienteModel);
        }

        // POST: Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PacienteModel == null)
            {
                return Problem("Entity set 'DataBaseContext.PacienteModel'  is null.");
            }
            var pacienteModel = await _context.PacienteModel.FindAsync(id);
            if (pacienteModel != null)
            {
                _context.PacienteModel.Remove(pacienteModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteModelExists(int id)
        {
          return (_context.PacienteModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
