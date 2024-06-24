using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Loja_carros.Data;
using Loja_carros.Models;

namespace Loja_carros.Controllers
{
    public class CarrosController : Controller
    {
        private readonly Loja_carrosContext _context;

        public CarrosController(Loja_carrosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return _context.Carro != null ? 
                          View(await _context.Carro.ToListAsync()) :
                          Problem("Entity set 'Loja_carrosContext.Carro'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carro == null)
            {
                return NotFound();
            }

            var carro = await _context.Carro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,AnoFabricacao,AnoModelo,Chassi,Preco")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carro);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Carro == null)
            {
                return NotFound();
            }

            var carro = await _context.Carro.FindAsync(id);
            if (carro == null)
            {
                return NotFound();
            }
            return View(carro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo,AnoFabricacao,AnoModelo,Chassi,Preco")] Carro carro)
        {
            if (id != carro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroExists(carro.Id))
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
            return View(carro);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carro == null)
            {
                return NotFound();
            }

            var carro = await _context.Carro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Carro == null)
            {
                return Problem("Entity set 'Loja_carrosContext.Carro'  is null.");
            }
            var carro = await _context.Carro.FindAsync(id);
            if (carro != null)
            {
                _context.Carro.Remove(carro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarroExists(int id)
        {
          return (_context.Carro?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
