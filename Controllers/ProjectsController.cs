using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IS4439_CA2.Data;
using IS4439_CA2.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Net.Http.Headers;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace IS4439_CA2.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _User;
        public ProjectsController(ApplicationDbContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
            _User = user;
        }

        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await _User.GetUserAsync(HttpContext.User);
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {   
            IEnumerable<Projects> p = await _context.Projects
                .Where(p => p.isVideo == false)
                .Include(c => c.ProjectImages)
                .ToListAsync();
            return View(p);
        }

        public async Task<IActionResult> Videos()
        {
            IEnumerable<Projects> p = await _context.Projects
                .Where(p => p.isVideo == true)
                .Include(c => c.ProjectImages)
                .ToListAsync();
            return View(p);
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var projects = await _context.Projects
                .Include(c => c.ProjectImages)
                .Include(b => b.ProjectCommentsID).ThenInclude(c => c.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ProjectsID == id);


            if (projects == null)
            {
                return NotFound();
            }

            return View(projects);
        }

        // GET: Projects/Create
        public async Task<IActionResult> Create()
        {
            var user = await GetCurrentUser();

            if (!user.IsAdmin)
            {
                //Assigning my own status code just for completion to the end user
                ViewData["Error"] = "401: You do not have the appropiate permissions to create projects!";
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(IFormFileCollection formFiles, int ProjectsID, string ProjectDescription, string ProjectTitle, string DateCompleted, string Resolution, bool isVideo)
        {
            if (formFiles == null)
            {
                ViewData["Error"] = "Please uploade at least one image!";
                return View();
            }
            var user = await GetCurrentUser();

            if (!user.IsAdmin)
            {
                return RedirectToAction(nameof(Index));
            }

            Projects newProject = new Projects() { DateCompleted = DateCompleted, isVideo = isVideo, ProjectDescription = ProjectDescription, ProjectTitle = ProjectTitle, Resolution = Resolution };
            if (ModelState.IsValid)
            {
                List<ProjectImages> projectImages = new List<ProjectImages>();
        
                foreach (IFormFile image in formFiles)
                {
                    
                    string imageName = ContentDispositionHeaderValue.Parse(image.ContentDisposition).FileName.Trim('"');
                    string myUniqueImageName = Convert.ToString(Guid.NewGuid());
                    string FileExtension = Path.GetExtension(imageName);
                    string fullImageID = myUniqueImageName + FileExtension;
                    string newProjectTitle = Regex.Replace("fam", @"\s+", "");

                    string dir = $"wwwroot/Projects/{newProjectTitle}/{fullImageID}";
                    string path = $"~/Projects/{newProjectTitle}/{fullImageID}";

                    if (!Directory.Exists($"wwwroot/Projects/{newProjectTitle}"))
                    {
                        Directory.CreateDirectory($"wwwroot/Projects/{newProjectTitle}");

                    }
                    using (FileStream fs = System.IO.File.Create(dir))
                    {
                        image.CopyTo(fs);
                        fs.Flush();
                    }
                    projectImages.Add(new ProjectImages() { imageRoute = path });
                    }
                newProject.ProjectImages = projectImages;
                _context.Add(newProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Projects/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ApplicationUser applicationUser = await GetCurrentUser();
            if (!applicationUser.IsAdmin)
            {
                //Assigning my own status code just for completion to the end user
                ViewData["Error"] = "401: You do not have the appropiate permissions to create projects!";
                return RedirectToAction("Details");
            }
            var projects = await _context.Projects.FindAsync(id);
            if (projects == null)
            {
                return NotFound();
            }
            return View(projects);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectsID,ProjectDescription,ProjectTitle,DateCompleted,Resolution,isVideo")] Projects projects)
        {
            if (id != projects.ProjectsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projects);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectsExists(projects.ProjectsID))
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
            return View(projects);
        }

        // GET: Projects/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {

            ApplicationUser applicationUser = await GetCurrentUser();
            if (!applicationUser.IsAdmin)
            {
                //Assigning my own status code just for completion to the end user
                TempData["Error"] = "401: You do not have the appropiate permissions to create projects!";
                return RedirectToAction("Details");
            }

            if (id == null)
            {
                return NotFound();
            }

            var projects = await _context.Projects
                .FirstOrDefaultAsync(m => m.ProjectsID == id);
            if (projects == null)
            {
                return NotFound();
            }

            return View(projects);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projects = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(projects);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectsExists(int id)
        {
            return _context.Projects.Any(e => e.ProjectsID == id);
        }
    }
}
