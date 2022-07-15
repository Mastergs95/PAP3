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
using NToastNotify;

namespace PAP3.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IToastNotification _toastNotification;
        private readonly UserManager<IdentityUser> _userManager;

        private int ClientId = -1;

        public CartController(ApplicationDbContext context, UserManager<IdentityUser> user, IToastNotification toastNotification)
        {
            _context = context;
            _userManager = user;
            _toastNotification = toastNotification;

        }

        public int GetClientId()
        {
            if (ClientId == -1)
            {
                string userId = _userManager.GetUserId(User);
                var client = _context.Clientes.Where(c => c.UserId == userId).FirstOrDefault();

                if (client != null)
                    ClientId = client.Id;
                else
                    ClientId = 0;
            }
            return ClientId;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = _context.Carts.Include(c => c.Produto).Where(c => c.ClientId == GetClientId());
            ViewData["TC"] = Total();

            return View(await produtos.ToListAsync());

        }

        public decimal Total()
        {
            var total = _context.Carts.Where(c => c.ClientId == GetClientId()).Sum(c => c.Produto.PrecoUnidade * c.qty);

            return decimal.Round(total, 2, MidpointRounding.AwayFromZero); ;
        }

        public IActionResult Shop()
        {
            _toastNotification.AddSuccessToastMessage("Your purchase was successful");
            return View();
        }


            [Authorize]
        public async Task<IActionResult> AddtoCart(int id, int price, int qty)
        {            
            Cart cart;
            
            cart = await _context.Carts.Where(c => c.Produto.Id == id).Where(c=>c.ClientId== GetClientId()).Include(c=>c.Produto).FirstOrDefaultAsync();

            bool newRecord = false;
            
            if (cart==null)
            {
                cart = new Cart();
                
                cart.qty = 1;
                cart.ClientId = GetClientId();
                cart.ProdutoId = id;
                newRecord = true;
            }
            else
            {
                if ( cart.qty < cart.Produto.stock)
                {
                  cart.qty += 1;  
                }
                else
                {
                    
                }
            }



            if (ModelState.IsValid)
            {
                _context.Add(cart);
                if (!newRecord)
                    _context.Entry(cart).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage("Product Added to the cart successfuly");
            }
            return RedirectToAction(nameof(Index));
        }


    }
}
