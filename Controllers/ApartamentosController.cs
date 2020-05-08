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
    public class ApartamentosController : Controller
    {
        private readonly MercadosHernandezContext _context;

        public ApartamentosController(MercadosHernandezContext context)
        {
            _context = context;
        }

        // GET: Apartamentos
        public async Task<IActionResult> Index()
        {
            var mercadosHernandezContext = _context.Apartamentos.Include(a => a.Propietario).Include(a => a.Unidad);
            return View(await mercadosHernandezContext.ToListAsync());
        }

        // GET: Apartamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartamento = await _context.Apartamentos
                .Include(a => a.Propietario)
                .Include(a => a.Unidad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apartamento == null)
            {
                return NotFound();
            }

            return View(apartamento);
        }

        // GET: Apartamentos/Create
        public IActionResult Create()
        {
            ViewData["PropietarioID"] = new SelectList(_context.Propietarios, "Id", "Nombre");
            ViewData["UnidadResidencialID"] = new SelectList(_context.UnidadResisdenciales, "Id", "Nombre");
            return View();
        }

        // POST: Apartamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,Piso,Bloque,UnidadResidencialID,PropietarioID,Estado")] Apartamento apartamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apartamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PropietarioID"] = new SelectList(_context.Propietarios, "Id", "Id", apartamento.PropietarioID);
            ViewData["UnidadResidencialID"] = new SelectList(_context.UnidadResisdenciales, "Id", "Id", apartamento.UnidadResidencialID);
            return View(apartamento);
        }

        // GET: Apartamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartamento = await _context.Apartamentos.FindAsync(id);
            if (apartamento == null)
            {
                return NotFound();
            }
            ViewData["PropietarioID"] = new SelectList(_context.Propietarios, "Id", "Id", apartamento.PropietarioID);
            ViewData["UnidadResidencialID"] = new SelectList(_context.UnidadResisdenciales, "Id", "Id", apartamento.UnidadResidencialID);
            return View(apartamento);
        }

        // POST: Apartamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,Piso,Bloque,UnidadResidencialID,PropietarioID,Estado")] Apartamento apartamento)
        {
            if (id != apartamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApartamentoExists(apartamento.Id))
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
            ViewData["PropietarioID"] = new SelectList(_context.Propietarios, "Id", "Id", apartamento.PropietarioID);
            ViewData["UnidadResidencialID"] = new SelectList(_context.UnidadResisdenciales, "Id", "Id", apartamento.UnidadResidencialID);
            return View(apartamento);
        }

        // GET: Apartamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartamento = await _context.Apartamentos
                .Include(a => a.Propietario)
                .Include(a => a.Unidad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apartamento == null)
            {
                return NotFound();
            }

            return View(apartamento);
        }

        // POST: Apartamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apartamento = await _context.Apartamentos.FindAsync(id);
            _context.Apartamentos.Remove(apartamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApartamentoExists(int id)
        {
            return _context.Apartamentos.Any(e => e.Id == id);
        }
    }
}
