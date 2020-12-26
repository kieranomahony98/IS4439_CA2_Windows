using IS4439_CA2.Data;
using IS4439_CA2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IS4439_CA2.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _User;


        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
            _User = user;

        }

        public async Task<IActionResult> Index()
        {
           IEnumerable<ApplicationUser> users = await _context.Users.ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> Edit(string id)
        {
            Debug.WriteLine("In controller");
            ApplicationUser user = await _context.Users.FindAsync(id);
            user.IsAdmin = !user.IsAdmin;
            _context.Update(user);
            await _context.SaveChangesAsync();
            string update = (user.IsAdmin == true) ? "User succesfully made an admin" : "User admin privalages revoked";
            TempData["Updated"] = update;
            return RedirectToAction(nameof(Index));
        }
    }
}
