using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PAP3.Data;
using PAP3.Models;

namespace PAP3.Controllers
{
    public class DetalhesPedidosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetalhesPedidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DetalhesPedidos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DetalhesPedidos.Include(d => d.Pedido).Include(d => d.Produto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DetalhesPedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalhesPedido = await _context.DetalhesPedidos
                .Include(d => d.Pedido)
                .Include(d => d.Produto)
                .FirstOrDefaultAsync(m => m.id == id);
            if (detalhesPedido == null)
            {
                return NotFound();
            }

            return View(detalhesPedido);
        }

        // GET: DetalhesPedidos/Create
        public IActionResult Create()
        {
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "NumPedido", "Nome");
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "NomeProduto");
            return View();
        }

        // POST: DetalhesPedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,PedidoId,ProdutoId,PreçoUnidade,Quantidade")] DetalhesPedido detalhesPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalhesPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "NumPedido", "Nome", detalhesPedido.PedidoId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "NomeProduto", detalhesPedido.ProdutoId);
            return View(detalhesPedido);
        }

        // GET: DetalhesPedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalhesPedido = await _context.DetalhesPedidos.FindAsync(id);
            if (detalhesPedido == null)
            {
                return NotFound();
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "NumPedido", "Nome", detalhesPedido.PedidoId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "NomeProduto", detalhesPedido.ProdutoId);
            return View(detalhesPedido);
        }

        // POST: DetalhesPedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,PedidoId,ProdutoId,PreçoUnidade,Quantidade")] DetalhesPedido detalhesPedido)
        {
            if (id != detalhesPedido.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalhesPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalhesPedidoExists(detalhesPedido.id))
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
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "NumPedido", "Nome", detalhesPedido.PedidoId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "NomeProduto", detalhesPedido.ProdutoId);
            return View(detalhesPedido);
        }

        // GET: DetalhesPedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalhesPedido = await _context.DetalhesPedidos
                .Include(d => d.Pedido)
                .Include(d => d.Produto)
                .FirstOrDefaultAsync(m => m.id == id);
            if (detalhesPedido == null)
            {
                return NotFound();
            }

            return View(detalhesPedido);
        }

        // POST: DetalhesPedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalhesPedido = await _context.DetalhesPedidos.FindAsync(id);
            _context.DetalhesPedidos.Remove(detalhesPedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalhesPedidoExists(int id)
        {
            return _context.DetalhesPedidos.Any(e => e.id == id);
        }
    }
}
