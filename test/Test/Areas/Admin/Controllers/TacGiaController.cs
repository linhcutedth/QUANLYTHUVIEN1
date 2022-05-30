using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class TacGiaController : Controller
    {
        private readonly QLTVContext _context;

        private readonly IConfiguration _configuration;
        public TacGiaController(QLTVContext context, IConfiguration config)
        {
            _context = context;
            _configuration = config;
        }

        // GET: TacGia
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tacgia.ToListAsync());
        }

        // GET: TacGia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var tacgia = await _context.Tacgia
                .FirstOrDefaultAsync(m => m.IdTacgia == id);
            if (tacgia == null)
            {
                return NotFound();
            }

            return View(tacgia);
        }

        // GET: TacGia/Create
       

        // POST: TacGia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTacgia,Tentg")] Tacgia tacgia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tacgia);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Tạo thành công";
                TempData["AlertType"] = "alert alert-success";
                return RedirectToAction(nameof(Index));
            }
            return View(tacgia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDS([Bind("IdTacgia,Tentg")] Tacgia tacgia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tacgia);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Tạo thành công";
                TempData["AlertType"] = "alert alert-success";
                return Redirect("/admin/dausach");
            }
            return View(tacgia);
        }

        // GET: TacGia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var tacgia = await _context.Tacgia.FindAsync(id);
            if (tacgia == null)
            {
                return NotFound();
            }
            return View(tacgia);
        }

        // POST: TacGia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTacgia,Tentg")] Tacgia tacgia)
        {
            if (id != tacgia.IdTacgia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tacgia);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Cập nhật thành công";
                    TempData["AlertType"] = "alert alert-success";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TacgiaExists(tacgia.IdTacgia))
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
            return View(tacgia);
        }

        // GET: TacGia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tacgia = await _context.Tacgia
                .FirstOrDefaultAsync(m => m.IdTacgia == id);
            if (tacgia == null)
            {
                return NotFound();
            }

            return View(tacgia);
        }

        // POST: TacGia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var tacgia = await _context.Tacgia.FindAsync(id);
                _context.Tacgia.Remove(tacgia);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Xóa thành công";
                TempData["AlertType"] = "alert alert-success";
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                TempData["AlertMessage"] = "Xóa không thành công vì đã tồn tại sách của tác giả này";
                TempData["AlertType"] = "alert alert-danger";
                return RedirectToAction(nameof(Index));
            }
        }

        private bool TacgiaExists(int id)
        {
            return _context.Tacgia.Any(e => e.IdTacgia == id);
        }
        [HttpPost]
        public JsonResult timTacGia(int id)
        {
            var tg = _context.Theloai.Find(id);
            return Json(tg);
        }
    }
}
