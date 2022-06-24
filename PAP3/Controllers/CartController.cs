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
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace PAP3.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        List<Cart> li = new List<Cart>();
        public CartController(ApplicationDbContext context, UserManager<IdentityUser> user)
        {
            _context = context;
            _userManager = user;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Carts.Include(c => c.Produto);
            return View(await applicationDbContext.ToListAsync());

        }

        public async Task<IActionResult> AddtoCart(int id, int price, int qty)
        {
            IdentityUser user = await _userManager.GetUserAsync(User);
            int clientid = _context.Clientes.Where(C => C.UserId == user.Id).FirstOrDefault().Id;

            var produto = await _context.Carts.Where(c => c.Produto.Id == id).Where(c=>c.ClientId==clientid).FirstOrDefaultAsync();

            Cart cart = new Cart();

            if (produto==null)
            {
                cart.qty = 1;
                cart.ClientId = clientid;
                cart.ProdutoId = id;
            }
            else
            {
                cart.qty += 1;
            }

            

            if (ModelState.IsValid)
            {
                _context.Add(cart);
                await _context.SaveChangesAsync();
               
            }
            return RedirectToAction(nameof(Index));
        }


    }
}
