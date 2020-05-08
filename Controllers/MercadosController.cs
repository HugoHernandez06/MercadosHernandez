using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MercadosHernandez.Data;
using MercadosHernandez.Models;

namespace MercadosHernandez.Controllers
{
    public class MercadosController : Controller
    {
        private readonly MercadosHernandezContext _context;

        public MercadosController(MercadosHernandezContext context)
        {
            _context = context;
        }

        // GET: Mercados
        public async Task<IActionResult> Index()
        {
            var mercadosHernandezContext = _context.Mercados.Include(m => m.Propietario);
            return View(await mercadosHernandezContext.ToListAsync());
        }

        // GET: Mercados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mercado = await _context.Mercados
                .Include(m => m.Propietario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mercado == null)
            {
                return NotFound();
            }

            return View(mercado);
        }

        // GET: Mercados/Create
        public IActionResult Create()
        {
            ViewData["PropietarioID"] = new SelectList(_context.Propietarios, "Id", "Id");
            return View();
        }

        // POST: Mercados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha_Creacion,PropietarioID,Estado")] Mercado mercado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mercado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PropietarioID"] = new SelectList(_context.Propietarios, "Id", "Id", mercado.PropietarioID);
            return View(mercado);
        }

        // GET: Mercados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mercado = await _context.Mercados.FindAsync(id);
            if (mercado == null)
            {
                return NotFound();
            }
            ViewData["PropietarioID"] = new SelectList(_context.Propietarios, "Id", "Id", mercado.PropietarioID);
            return View(mercado);
        }

        // POST: Mercados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha_Creacion,PropietarioID,Estado")] Mercado mercado)
        {
            if (id != mercado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mercado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MercadoExists(mercado.Id))
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
            ViewData["PropietarioID"] = new SelectList(_context.Propietarios, "Id", "Id", mercado.PropietarioID);
            return View(mercado);
        }

        // GET: Mercados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mercado = await _context.Mercados
                .Include(m => m.Propietario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mercado == null)
            {
                return NotFound();
            }

            return View(mercado);
        }

        // POST: Mercados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mercado = await _context.Mercados.FindAsync(id);
            _context.Mercados.Remove(mercado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MercadoExists(int id)
        {
            return _context.Mercados.Any(e => e.Id == id);
        }
    }
}
