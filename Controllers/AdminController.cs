using IS4439_CA2.Data;
using IS4439_CA2.Models;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _User;


        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
            _User = user;

        }
        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await _User.GetUserAsync(HttpContext.User);
        }

        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUser();

            if (user == null || !user.IsAdmin)
            {
                //Assigning my own status code just for completion to the end user
                TempData["Error"] = "401: You do not have the appropiate permissions to create projects!";
                return Redirect("/");
            }

            IEnumerable<ApplicationUser> users = await _context.Users.ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var u = await GetCurrentUser();

            if (u == null || !u.IsAdmin)
            {
                //Assigning my own status code just for completion to the end user
                TempData["Error"] = "401: You do not have the appropiate permissions to create projects!";
                return Redirect("/");
            }

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
