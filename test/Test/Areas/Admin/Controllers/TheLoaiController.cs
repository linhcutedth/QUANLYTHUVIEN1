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

namespace Test.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class TheLoaiController : Controller
    {
        private readonly QLTVContext _context;

        private readonly IConfiguration _configuration;
        public TheLoaiController(QLTVContext context, IConfiguration config)
        {
            _context = context;
            _configuration = config;
        }

        // GET: Sanpham
        public async Task<IActionResult> Index()
        {
            return View(await _context.Theloai.ToListAsync());
        }

        // GET: Sanpham/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var theloai = await _context.Theloai
                .FirstOrDefaultAsync(m => m.IdTheloai == id);
            if (theloai == null)
            {
                return NotFound();
            }

            return View(theloai);
        }


        // POST: Sanpham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        public async Task<IActionResult> Create([Bind("IdTheloai,Tentheloai")] Theloai theloai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(theloai);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Tạo thành công";
                TempData["AlertType"] = "alert alert-success";
                return RedirectToAction(nameof(Index));
            }
            return View(theloai);
        }

        // GET: Sanpham/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var theloai = await _context.Theloai.FindAsync(id);
            if (theloai == null)
            {
                return NotFound();
            }
            return View(theloai);
        }

        // POST: Sanpham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTheloai,Tentheloai")] Theloai theloai)
        {
            if (id != theloai.IdTheloai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(theloai);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Cập nhật thành công";
                    TempData["AlertType"] = "alert alert-success";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TheloaiExists(theloai.IdTheloai))
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
            return View(theloai);
        }

        

        // POST: Sanpham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var theloai = await _context.Theloai.FindAsync(id);
                _context.Theloai.Remove(theloai);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Xóa thành công";
                TempData["AlertType"] = "alert alert-success";
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                TempData["AlertMessage"] = "Xóa không thành công vì đã tồn tại sách của thể loại này";
                TempData["AlertType"] = "alert alert-danger";
                return RedirectToAction(nameof(Index));
            }
        }

        private bool TheloaiExists(int id)
        {
            return _context.Theloai.Any(e => e.IdTheloai == id);
        }
        [HttpPost]
        public JsonResult timTheLoai(int id)
        {
            var tl = _context.Theloai.Find(id);
            return Json(tl);
        }
    }
}
