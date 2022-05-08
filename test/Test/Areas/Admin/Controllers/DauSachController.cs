﻿using Microsoft.AspNetCore.Authorization;
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
    public class DauSachController : Controller
    {
        private readonly QLTVContext _context;

        private readonly IConfiguration _configuration;
        public DauSachController(QLTVContext context, IConfiguration config)
        {
            _context = context;
            _configuration = config;
        }

        // GET: Sanpham
        public async Task<IActionResult> Index()
        {
            var lapTopContext = _context.Dausach.Include(s => s.IdTheloaiNavigation);
            ViewBag.TheLoai = _context.Theloai.ToList();
            return View(await lapTopContext.ToListAsync());
        }

        // GET: Sanpham/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var dausach = _context.Dausach.Find(id);

            ViewData["theloainav"] = _context.Theloai.Find(dausach.IdTheloai);
            ViewData["dausach"] = dausach;
            if (dausach == null)
            {
                return NotFound();
            }

            return View(dausach);

        }


        // POST: Sanpham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDausach,IdTheloai,Tensach,Namxuatban,Nhaxuatban,Trigia,Tongso,HinhAnhFile")] Dausach dausach,string NgNhap)
        {
            if (ModelState.IsValid)
            {
                if (dausach.HinhAnhFile != null)
                {
                    string fullPath = Path.Combine(Directory.GetCurrentDirectory(),
                                        "wwwroot", "HinhAnh", dausach.HinhAnhFile.FileName);
                    using (var file = new FileStream(fullPath, FileMode.Create))
                    {
                        dausach.HinhAnhFile.CopyTo(file);
                    }
                    dausach.Hinhanh = "/HinhAnh/" + dausach.HinhAnhFile.FileName;
                }
                dausach.Ngnhap = Convert.ToDateTime(NgNhap);
                dausach.Sanco = dausach.Tongso;
                dausach.Dangchomuon = 0;
                _context.Add(dausach);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Tạo thành công";
                TempData["AlertType"] = "alert alert-success";
                return RedirectToAction(nameof(Index));
            }
            ViewData["theloainav"] = new SelectList(_context.Theloai, "idtheloai", "idtheloai", dausach.IdTheloai);
            return View(dausach);
        }

        // GET: Sanpham/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var dausach = await _context.Dausach.FindAsync(id);
            if (dausach == null)
            {
                return NotFound();
            }
            ViewBag.TheLoai = _context.Theloai.ToList();
            ViewData["IdTheloai"] = new SelectList(_context.Theloai, "IdTheloai", "IdTheloai", dausach.IdTheloai);
            Console.WriteLine(ViewData["IdTheloai"]);
            return View(dausach);
        }

        // POST: Sanpham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDausach,IdTheloai,Tensach,Namxuatban,Nhaxuatban,Trigia,Tongso,NgNhap,HinhAnhFile")] Dausach dausach)
        {
            if (id != dausach.IdDausach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (dausach.HinhAnhFile != null)
                    {
                        string fullPath = Path.Combine(Directory.GetCurrentDirectory(),
                                            "wwwroot", "HinhAnh", dausach.HinhAnhFile.FileName);
                        using (var file = new FileStream(fullPath, FileMode.Create))
                        {
                            dausach.HinhAnhFile.CopyTo(file);
                        }
                        dausach.Hinhanh = "/HinhAnh/" + dausach.HinhAnhFile.FileName;
                    }
                    _context.Update(dausach);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Cập nhật thành công";
                    TempData["AlertType"] = "alert alert-success";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DausachExists(dausach.IdDausach))
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
            ViewData["TheLoai"] = new SelectList(_context.Theloai, "TheLoai", "TheLoai", dausach.IdTheloai);
           
            return View(dausach);
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

        // POST: Sanpham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Console.WriteLine(id);
            try
            {
                var dausach = await _context.Dausach.FindAsync(id);
                Console.WriteLine(dausach.Tensach);
                _context.Dausach.Remove(dausach);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Xóa thành công";
                TempData["AlertType"] = "alert alert-success";
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                TempData["AlertMessage"] = "Xóa không thành công";
                TempData["AlertType"] = "alert alert-danger";
                return RedirectToAction(nameof(Index));
            }
        }

        private bool DausachExists(int id)
        {
            return _context.Dausach.Any(e => e.IdDausach == id);
        }
        [HttpPost]
        public JsonResult timDausach(int id)
        {
            var sp = _context.Dausach.Find(id);
            return Json(sp);
        }
    }
}