using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PAP3.Models;
using PAP3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace PAP3.Controllers
{
    public class LojaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LojaController(ApplicationDbContext context)
        {
            _context = context;
        }

        //[Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produtos.Include(art => art.Categoria).ToListAsync());
        }

   
        public async Task<IActionResult> SingleProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }
    }
}
