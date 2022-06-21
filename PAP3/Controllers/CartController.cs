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
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        List<Cart> li = new List<Cart>();
        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Carts.ToListAsync());
        }



        public IActionResult AddtoCart()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddtoCart(int id, int price, int qty, string name)
        {
            Cart cart = new Cart();
            cart.prodName = name;
            cart.price = price;
            cart.qty = qty;
            if (ModelState.IsValid)
            {
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cart);
        }


    }
}
