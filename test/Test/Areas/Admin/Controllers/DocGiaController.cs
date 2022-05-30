using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
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
    public class DocGiaController : Controller
    {
        private readonly QLTVContext _context;

        private readonly IConfiguration _configuration;
        public DocGiaController(QLTVContext context, IConfiguration config)
        {
            _context = context;
            _configuration = config;
        }

        // GET: DocGia
        public async Task<IActionResult> Index()
        {
            return View(await _context.Thedocgia.ToListAsync());
        }

        // GET: DocGia/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var docgia = await _context.Thedocgia
                .FirstOrDefaultAsync(m => m.IdDg == id);
            if (docgia == null)
            {
                return NotFound();
            }

            return View(docgia);

        }

        // POST: DocGia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDg,Hotendg,Loaidg,Diachi,Email")] Thedocgia docgia, string NgSinh)
        {
            if (ModelState.IsValid)
            {
                docgia.Ngsinh = Convert.ToDateTime(NgSinh);
                docgia.Tinhtrang = "Còn hạn";
                docgia.Nglapthe = DateTime.Now;
                _context.Add(docgia);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Tạo thành công";
                TempData["AlertType"] = "alert alert-success";
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: DocGia/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var docgia = await _context.Thedocgia.FindAsync(id);
            if (docgia == null)
            {
                return NotFound();
            }
            return View(docgia);
        }

        // POST: Sanpham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDg,Hotendg,Loaidg,Diachi,Email,Ngsinh,Tinhtrang,Nglapthe")] Thedocgia docgia)
        {

            if (id != docgia.IdDg)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(docgia);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Cập nhật thành công";
                    TempData["AlertType"] = "alert alert-success";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocGiaExists(docgia.IdDg))
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
            return View(docgia);
        }

        // GET: Sanpham/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var sanpham = await _context.Sanpham
        //        .Include(s => s.BoxulyNavigation)
        //        .Include(s => s.CongketnoiNavigation)
        //        .Include(s => s.DanhmucNavigation)
        //        .Include(s => s.ManhinhNavigation)
        //        .Include(s => s.RamNavigation)
        //        .FirstOrDefaultAsync(m => m.Masp == id);
        //    if (sanpham == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(sanpham);
        //}

        // POST: DocGia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var docgia = await _context.Thedocgia.FindAsync(id);
                _context.Thedocgia.Remove(docgia);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Xóa thành công";
                TempData["AlertType"] = "alert alert-success";
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                TempData["AlertMessage"] = "Xóa không thành công vì độc giả đang mượn sách";
                TempData["AlertType"] = "alert alert-danger";
                return RedirectToAction(nameof(Index));
            }
        }

        private bool DocGiaExists(int id)
        {
            return _context.Thedocgia.Any(e => e.IdDg == id);
        }
        [HttpPost]
        public JsonResult timDocGia(int id)
        {
            var dg = _context.Thedocgia.Find(id);
            return Json(dg);
        }

      
       
    }
}
