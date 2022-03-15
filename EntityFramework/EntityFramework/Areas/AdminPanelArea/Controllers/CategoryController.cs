using EntityFramework.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Areas.AdminPanelArea.Controllers
{
    [Area("AdminPanelArea")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var category = await _context.Categories.ToListAsync();
            return View(category);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var category = _context.Categories.FirstOrDefault(m => m.Id == id);
            return Json(new
            {
                categoryName = category.Name,
                action = "Detail",
                Id = id
            });
        }
        public async Task<IActionResult> Edit(int id)
        {
            return Json(new
            {
                action = "Edit",
                Id = id
            });
        }
        public async Task<IActionResult> Delete(int id)
        {
            return Json(new
            {
                action = "Delete",
                Id = id
            });
        }
    }
}
