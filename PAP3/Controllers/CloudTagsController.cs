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
    public class CloudTagsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CloudTagsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CloudTags
        public async Task<IActionResult> Index()
        {
            return View(await _context.CloudTags.ToListAsync());
        }

        // GET: CloudTags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cloudTag = await _context.CloudTags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cloudTag == null)
            {
                return NotFound();
            }

            return View(cloudTag);
        }

        // GET: CloudTags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CloudTags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,descriçao")] CloudTag cloudTag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cloudTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cloudTag);
        }

        // GET: CloudTags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cloudTag = await _context.CloudTags.FindAsync(id);
            if (cloudTag == null)
            {
                return NotFound();
            }
            return View(cloudTag);
        }

        // POST: CloudTags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,descriçao")] CloudTag cloudTag)
        {
            if (id != cloudTag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cloudTag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CloudTagExists(cloudTag.Id))
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
            return View(cloudTag);
        }

        // GET: CloudTags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cloudTag = await _context.CloudTags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cloudTag == null)
            {
                return NotFound();
            }

            return View(cloudTag);
        }

        // POST: CloudTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cloudTag = await _context.CloudTags.FindAsync(id);
            _context.CloudTags.Remove(cloudTag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CloudTagExists(int id)
        {
            return _context.CloudTags.Any(e => e.Id == id);
        }
    }
}
