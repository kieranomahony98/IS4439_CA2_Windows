using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IS4439_CA2.Data;
using IS4439_CA2.Models;
using System.Security.Claims;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace IS4439_CA2.Controllers

{
    [Authorize]
    public class ProjectCommentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _User;


        public ProjectCommentsController(ApplicationDbContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
            _User = user;

        }

        // GET: ProjectComments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProjectComments.Include(p => p.Project).Where(c => c.ApplicationUserID == User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var myComments = await applicationDbContext.ToListAsync();
               
            return View(myComments);
        }
        [Authorize]
        public async Task<IActionResult> AdminView()
        {
            ApplicationUser user =  await _User.GetUserAsync(HttpContext.User);
            if (!user.IsAdmin) return Redirect("/");

            var comments = await _context.ProjectComments.ToListAsync();

            return View(comments);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectComments = await _context.ProjectComments
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ProjectCommentsID == id);
            if (projectComments == null)
            {
                return NotFound();
            }

            return View(projectComments);
        }

        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectsID", "ProjectsID");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectCommentsID,CommentText,ProjectID")] ProjectComments projectComments)
        {
            projectComments.CommentTimeStamp = DateTime.Today;
            projectComments.ApplicationUserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                _context.Add(projectComments);
                await _context.SaveChangesAsync();
                return Redirect($"/Projects/Details/{projectComments.ProjectID}");
            }
            TempData["CommentError"] = "Unable to add comment, please try again later";
            return Redirect($"/Projects/Details/{projectComments.ProjectID}");
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProjectComments projectComments = await _context.ProjectComments
                .Include(p => p.Project)
                .FirstOrDefaultAsync(c => c.ProjectCommentsID == id);
                

            if (projectComments == null)
            {
                return NotFound();
            }
           
            ViewData["ProjectID"] =  projectComments.ProjectID;
            ViewData["ProjectTitle"] = projectComments.Project.ProjectTitle;
            return View(projectComments);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, [Bind("ProjectCommentsID,CommentText,CommentTimeStamp,ProjectID")] ProjectComments projectComments)
        {
            if (id != projectComments.ProjectCommentsID)
            {
                return NotFound();
            }
            projectComments.ApplicationUserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectComments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectCommentsExists(projectComments.ProjectCommentsID))
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
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectsID", "ProjectsID", projectComments.ProjectID);
            return View(projectComments);
        }
   

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectComments = await _context.ProjectComments
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ProjectCommentsID == id);
            if (projectComments == null)
            {
                return NotFound();
            }
            TempData["Updated"] = "Comment Succesfully Removed";
            return View(projectComments);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectComments = await _context.ProjectComments.FindAsync(id);
            _context.ProjectComments.Remove(projectComments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectCommentsExists(int id)
        {
            return _context.ProjectComments.Any(e => e.ProjectCommentsID == id);
        }
    }
}
