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
    public class SachController : Controller
    {
        private readonly QLTVContext _context;

        private readonly IConfiguration _configuration;
        public SachController(QLTVContext context, IConfiguration config)
        {
            _context = context;
            _configuration = config;
        }
        public async Task<IActionResult> Index()
        {
            var lapTopContext = _context.Sach.Include(s => s.IdDausachNavigation);
            ViewBag.DauSach = _context.Dausach.ToList();
            return View(await lapTopContext.ToListAsync());
        }
        // GET: Sach/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var sach = await _context.Sach
                .Include(d => d.IdDausachNavigation)
                .FirstOrDefaultAsync(m => m.IdSach == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }
        // POST: Sach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("IdDausach,IdSach")] Sach sach)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        sach.TinhTrang = "Sẵn có";
        //        _context.Add(sach);
        //        await _context.SaveChangesAsync();
        //        TempData["AlertMessage"] = "Tạo thành công";
        //        TempData["AlertType"] = "alert alert-success";
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(sach);
        //}
        
        // GET: TacGia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sach = await _context.Sach
                .FirstOrDefaultAsync(m => m.IdSach == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        // POST: TacGia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var sach = await _context.Sach.FindAsync(id);
                _context.Sach.Remove(sach);
                await _context.SaveChangesAsync();
                update_dau_sach(sach.IdDausach);
                TempData["AlertMessage"] = "Xóa thành công";
                TempData["AlertType"] = "alert alert-success";

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                TempData["AlertMessage"] = "Xóa không thành công vì sách đang được mượn";
                TempData["AlertType"] = "alert alert-danger";
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpPost]
        public JsonResult timSach(int id)
        {
            var sach = _context.Sach.Find(id);
            return Json(sach);
        }

        private void update_dau_sach(int iddausach)
        {
            string connStr = "server=127.0.0.1;port=3306;user=root;password=admin;database=QLTV";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            // Câu truy vấn gồm: chèn dữ liệu vào và lấy định danh(Primary key) mới chèn vào
            string query = @"UPDATE DAUSACH SET TONGSO = TONGSO - 1, SANCO = SANCO - 1 WHERE ID_DAUSACH = @id_dausach";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_dausach", iddausach);

            cmd.ExecuteScalar(); // Thi hành SQL trả về giá trị đầu tiên

        }

    }
}
