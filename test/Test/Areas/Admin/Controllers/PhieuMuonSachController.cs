using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;

namespace Test.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class PhieuMuonSachController : Controller
    {
        private readonly QLTVContext _context;

        private readonly IConfiguration _configuration;

        public PhieuMuonSachController(QLTVContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        // GET: PhieuMuonSachController
        public async Task<IActionResult> Index()
        {
            var lapTopContext = _context.Phieumuonsach.Include(s => s.IdDgNavigation);
            ViewBag.Thedocgia = _context.Thedocgia.ToList();
            ViewBag.Sach = _context.Sach.ToList();
            return View(await lapTopContext.ToListAsync());
        }

        // GET: PhieuMuonSachController/Details/5
        public ActionResult Details(int id)
        {

            if (id == 0)
            {
                return NotFound();
            }
            var pms = _context.Phieumuonsach.Where(x => x.IdPms == id)
                            .Select(x => new
                            {
                                IdPms = x.IdPms,
                                HotenDG = x.IdDgNavigation.Hotendg,
                                NgMuon = x.Ngmuon,
                                Sach = x.ChitietPms.Select(c => new
                                {
                                    IdSach = c.IdSach,
                                    TenSach = c.IdSachNavigation.IdDausachNavigation.Tensach,
                                    TheLoai = c.IdSachNavigation.IdDausachNavigation.IdTheloaiNavigation.Tentheloai,
                                    TacGia = c.IdSachNavigation.IdDausachNavigation.ChitietDausachTacgia.Select(ct=> new
                                    {
                                      //  IdTacgia = ct.IdTacgiaNavigation.IdTacgia,
                                        ct.IdTacgiaNavigation.Tentg,
                                    }).ToList()    
                                    
                                   
                                }).ToList()

                            }).Single();
            ViewBag.Sach = pms.Sach;
            


            if (pms == null)
            {
                return NotFound();
            }

            return View(pms);
        }

        // GET: PhieuMuonSachController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhieuMuonSachController/Create
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

        // GET: PhieuMuonSachController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PhieuMuonSachController/Edit/5
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

        // GET: PhieuMuonSachController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PhieuMuonSachController/Delete/5
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
