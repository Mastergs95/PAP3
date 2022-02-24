using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PAP3.Models;
using PAP3.Data;
using Microsoft.EntityFrameworkCore;

namespace PAP3.Controllers
{
    public class LojaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LojaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Produtos.ToListAsync());
        }
    }
}
