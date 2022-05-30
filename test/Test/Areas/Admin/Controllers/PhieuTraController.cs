using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;

namespace Test.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class PhieuTraController : Controller
    {
        private readonly QLTVContext _context;

        private readonly IConfiguration _configuration;

        public PhieuTraController(QLTVContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: PhieuTraController
        public async Task<IActionResult> Index()
        {
            var lapTopContext = _context.Phieutrasach.Include(s => s.IdDgNavigation);
            ViewBag.TheDocGia = _context.Thedocgia.ToList();
            ViewBag.Sach = _context.Sach.ToList();
            return View(await _context.Phieutrasach.ToListAsync());
        }

        // GET: PhieuTraController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var pts = _context.Phieutrasach.Where(x => x.IdPts == id)
                             .Select(x => new
                             {
                                 IdPts = x.IdPts,
                                 HotenDG = x.IdDgNavigation.Hotendg,
                                 NgTra = x.Ngtra,
                                 TienPhatKiNay = x.Tienphatkinay,
                                 TongNo = x.Tongno,
                                 ChitietPts = x.ChitietPts.Select(c => new
                                 {
                                     IdSach = c.IdSach,
                                     SoNgMuon = c.Songmuon,
                                     TienPhat = c.Tienphat,
                                     NgayMuon = c.IdSachNavigation.ChitietPms.Where(t => t.Tinhtrang == "chưa trả")
                                     .Select(t => new
                                     {
                                         NgMuon = t.IdPmsNavigation.Ngmuon,
                                     })
                                 }).ToList()

                             }).Single();

                
        

            ViewBag.ChitietPts = pts.ChitietPts;
            if (pts == null)
            {
                return NotFound();
            }

            return View(pts);

        }

        // GET: PhieuTraController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhieuTraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PhieuTraController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PhieuTraController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PhieuTraController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PhieuTraController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
       
    } 
}
