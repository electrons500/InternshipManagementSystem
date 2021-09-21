using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using static OnlineInternshipPortal.Models.Enum;

namespace OnlineInternshipPortal.Controllers
{
    public class GuardianCategoryController : BaseController
    {
        private readonly OnlineInternshipContext _context;

        public GuardianCategoryController(OnlineInternshipContext context)
        {
            _context = context;
        }

        // GET: GuardianCategory
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
           
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GuardianCategoryList()
        {
            var model = await _context.GuardianCategories.ToListAsync();
            return Json(new { data = model });
        }

        // GET: GuardianCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guardianCategory = await _context.GuardianCategories
                .FirstOrDefaultAsync(m => m.GuardianCategoryId == id);
            if (guardianCategory == null)
            {
                return NotFound();
            }

            return View(guardianCategory);
        }

        // GET: GuardianCategory/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Addcategory()
        {
            return View();
        }

        // POST: GuardianCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Addcategory([Bind("GuardianCategoryId,Name")] GuardianCategory guardianCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guardianCategory);
                int i = await _context.SaveChangesAsync();
                if (i > 0)
                {
                    Alert("Congratulations", "New category successfully added!", NotificationType.success);
                   
                }
                return RedirectToAction(nameof(Index));
            }
            return View(guardianCategory);
        }

        // GET: GuardianCategory/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guardianCategory = await _context.GuardianCategories.FindAsync(id);
            if (guardianCategory == null)
            {
                return NotFound();
            }
            return View(guardianCategory);
        }

        // POST: GuardianCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(int id, [Bind("GuardianCategoryId,Name")] GuardianCategory guardianCategory)
        {
            if (id != guardianCategory.GuardianCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guardianCategory);
                    int i = await _context.SaveChangesAsync();
                    if (i > 0)
                    {
                        Alert("Congratulations", "Category successfully updated!", NotificationType.success);
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuardianCategoryExists(guardianCategory.GuardianCategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
               // return RedirectToAction(nameof(Index));
            }
            return View(guardianCategory);
        }

        // GET: GuardianCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guardianCategory = await _context.GuardianCategories
                .FirstOrDefaultAsync(m => m.GuardianCategoryId == id);
            if (guardianCategory == null)
            {
                return NotFound();
            }

            return View(guardianCategory);
        }

        // POST: GuardianCategory/Delete/5
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guardianCategory = await _context.GuardianCategories.FindAsync(id);
            _context.GuardianCategories.Remove(guardianCategory);
            int i = await _context.SaveChangesAsync();
            if (i > 0)
            {
                return Json(new { success = true, message = "Category successfully deleted!" });
            }
            return RedirectToAction(nameof(Index));
        }

        private bool GuardianCategoryExists(int id)
        {
            return _context.GuardianCategories.Any(e => e.GuardianCategoryId == id);
        }
    }
}
