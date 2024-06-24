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
    public class VendedorsController : Controller
    {
        private readonly Loja_carrosContext _context;

        public VendedorsController(Loja_carrosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return _context.Vendedor != null ? 
                          View(await _context.Vendedor.ToListAsync()) :
                          Problem("Entity set 'Loja_carrosContext.Vendedor'  is null.");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vendedor == null)
            {
                return NotFound();
            }

            var vendedor = await _context.Vendedor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendedor == null)
            {
                return NotFound();
            }

            return View(vendedor);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataAdmissao,Matricula,Salario")] Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendedor);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vendedor == null)
            {
                return NotFound();
            }

            var vendedor = await _context.Vendedor.FindAsync(id);
            if (vendedor == null)
            {
                return NotFound();
            }
            return View(vendedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataAdmissao,Matricula,Salario")] Vendedor vendedor)
        {
            if (id != vendedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendedorExists(vendedor.Id))
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
            return View(vendedor);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vendedor == null)
            {
                return NotFound();
            }

            var vendedor = await _context.Vendedor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendedor == null)
            {
                return NotFound();
            }

            return View(vendedor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vendedor == null)
            {
                return Problem("Entity set 'Loja_carrosContext.Vendedor'  is null.");
            }
            var vendedor = await _context.Vendedor.FindAsync(id);
            if (vendedor != null)
            {
                _context.Vendedor.Remove(vendedor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendedorExists(int id)
        {
          return (_context.Vendedor?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
