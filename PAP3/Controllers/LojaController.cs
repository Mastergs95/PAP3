using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PAP3.Models;
using PAP3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using PAP3.Helpers;


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
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Produtos.Include(art => art.Categoria).ToListAsync());
        //}

        public async Task<IActionResult> Index(string sortOrder, string currentFilter,int? currentCategory, string searchString, int? pageNumber)
        {
            //https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/sort-filter-page?view=aspnetcore-3.1
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentCategory"] = currentCategory;
            ViewData["NomeSortParm"] = sortOrder == "Nome" ? "nome_desc" : "Nome";
            ViewData["PrecoSortParm"] = sortOrder == "Preco" ? "preco_desc" : "Preco";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

          
            ViewData["CurrentFilter"] = searchString;

            var produtos = from a in _context.Produtos
                          select a;

            if ((currentCategory != null) && (currentCategory!=0))
            {
                produtos = produtos.Where(s => s.CategoriaId == currentCategory);
            }


            if (!String.IsNullOrEmpty(searchString))
            {
                produtos = produtos.Where(s => s.NomeProduto.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Nome":
                    produtos = produtos.OrderBy(a => a.NomeProduto);
                    break;
                case "nome_desc":
                    produtos = produtos.OrderByDescending(a => a.NomeProduto);
                    break;
                case "Preco":
                    produtos = produtos.OrderBy(a => a.PrecoUnidade);
                    break;
                case "preco_desc":
                    produtos = produtos.OrderByDescending(a => a.PrecoUnidade);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<Produto>.CreateAsync(produtos.AsNoTracking().Include(art => art.Categoria), pageNumber ?? 1, pageSize));
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
