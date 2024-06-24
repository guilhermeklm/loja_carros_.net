using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Loja_carros.Data;
using Loja_carros.Models;

namespace Loja_carros.Controllers
{
    public class NotasController : Controller
    {
        private readonly Loja_carrosContext _context;

        public NotasController(Loja_carrosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var loja_carrosContext = _context.Nota.Include(n => n.Carro).Include(n => n.Cliente).Include(n => n.Vendedor);
            return View(await loja_carrosContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nota == null)
            {
                return NotFound();
            }

            var nota = await _context.Nota
                .Include(n => n.Carro)
                .Include(n => n.Cliente)
                .Include(n => n.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nota == null)
            {
                return NotFound();
            }

            return View(nota);
        }

        public IActionResult Create()
        {
            var nota = new Nota();
            nota.DataEmissao = DateTime.Now;
            ViewData["Carros"] = _context.Carro.ToList();
            ViewData["Clientes"] = _context.Cliente.ToList();
            ViewData["Vendedores"] = _context.Vendedor.ToList();
            return View(nota);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,DataEmissao,Garantia,ValorRenda,ClienteId,VendedorId,CarroId")] Nota nota)
        {
            nota.Cliente = _context.Cliente.FirstOrDefault(c => c.Id == nota.ClienteId);
            nota.Carro = _context.Carro.FirstOrDefault(c => c.Id == nota.CarroId);
            nota.Vendedor = _context.Vendedor.FirstOrDefault(c => c.Id == nota.VendedorId);

            if (nota.Cliente == null || nota.Carro == null || nota.Vendedor == null)
            {
                return NotFound();
            }

            _context.Add(nota);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nota == null)
            {
                return NotFound();
            }

            var nota = await _context.Nota.FindAsync(id);
            if (nota == null)
            {
                return NotFound();
            }
            ViewData["Carros"] = _context.Carro.ToList();
            ViewData["Clientes"] = _context.Cliente.ToList();
            ViewData["Vendedores"] = _context.Vendedor.ToList();
            return View(nota);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,DataEmissao,Garantia,ValorRenda,ClienteId,VendedorId,CarroId")] Nota nota)
        {
            if (id != nota.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(nota);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotaExists(nota.Id))
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

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nota == null)
            {
                return NotFound();
            }

            var nota = await _context.Nota
                .Include(n => n.Carro)
                .Include(n => n.Cliente)
                .Include(n => n.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nota == null)
            {
                return NotFound();
            }

            return View(nota);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nota == null)
            {
                return Problem("Entity set 'Loja_carrosContext.Nota'  is null.");
            }
            var nota = await _context.Nota.FindAsync(id);
            if (nota != null)
            {
                _context.Nota.Remove(nota);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotaExists(int id)
        {
          return (_context.Nota?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
