using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PAP3.Data;
using PAP3.Models;

namespace PAP3.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ProdutosTagsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutosTagsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProdutosTags
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProdutosTags.Include(p => p.CloudTag).Include(p => p.Produto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProdutosTags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtosTag = await _context.ProdutosTags
                .Include(p => p.CloudTag)
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(m => m.TagId == id);
            if (produtosTag == null)
            {
                return NotFound();
            }

            return View(produtosTag);
        }

        // GET: ProdutosTags/Create
        public IActionResult Create()
        {
            ViewData["TagId"] = new SelectList(_context.CloudTags, "Id", "descriçao");
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "NomeProduto");
            return View();
        }

        // POST: ProdutosTags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoId,TagId")] ProdutosTag produtosTag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produtosTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TagId"] = new SelectList(_context.CloudTags, "Id", "descriçao", produtosTag.TagId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "NomeProduto", produtosTag.ProdutoId);
            return View(produtosTag);
        }

        // GET: ProdutosTags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtosTag = await _context.ProdutosTags.FindAsync(id);
            if (produtosTag == null)
            {
                return NotFound();
            }
            ViewData["TagId"] = new SelectList(_context.CloudTags, "Id", "descriçao", produtosTag.TagId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "NomeProduto", produtosTag.ProdutoId);
            return View(produtosTag);
        }

        // POST: ProdutosTags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdutoId,TagId")] ProdutosTag produtosTag)
        {
            if (id != produtosTag.TagId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtosTag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutosTagExists(produtosTag.TagId))
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
            ViewData["TagId"] = new SelectList(_context.CloudTags, "Id", "descriçao", produtosTag.TagId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "NomeProduto", produtosTag.ProdutoId);
            return View(produtosTag);
        }

        // GET: ProdutosTags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtosTag = await _context.ProdutosTags
                .Include(p => p.CloudTag)
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(m => m.TagId == id);
            if (produtosTag == null)
            {
                return NotFound();
            }

            return View(produtosTag);
        }

        // POST: ProdutosTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produtosTag = await _context.ProdutosTags.FindAsync(id);
            _context.ProdutosTags.Remove(produtosTag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutosTagExists(int id)
        {
            return _context.ProdutosTags.Any(e => e.TagId == id);
        }
    }
}
