using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;
using Test.Models;

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
            ViewBag.Sach = _context.Sach.Where(c => c.TinhTrang == "đang cho mượn").ToList();
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDg")] Phieutrasach pts, string NgTra, string txtSach)
        {
            if (String.IsNullOrEmpty(txtSach))
            {
                TempData["AlertMessage"] = "Phải nhấn nút áp dụng ở mục thêm sách";
                TempData["AlertType"] = "alert alert-danger";
            }
            else if (ModelState.IsValid)
            {

                pts.Ngtra = Convert.ToDateTime(NgTra);
                _context.Add(pts);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Tạo thành công";
                TempData["AlertType"] = "alert alert-success";

                xuly_pts_xtpts(pts.IdPts, txtSach);

                return RedirectToAction(nameof(Index));
            }
            ViewData["docgianav"] = new SelectList(_context.Thedocgia, "IdDg", "IdDg", pts.IdDg);
            return RedirectToAction(nameof(Index));
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
        private void xuly_pts_xtpts(int idpts, string txtSach)
        {
            string[] arrListStr = txtSach.Split('&');
                for (int i = 0; i < arrListStr.Length - 1; i++)
                {
                    int idsach = Int32.Parse(arrListStr[i]);
                   // them_cttg_sach(idpms, idsach);
                    them_ctpts_sach(idpts, idsach);
                    int iddausach = getdausach(idsach);
                    capnhatdausach(iddausach);
                    capnhatcuonsach(idsach);

            }
        }
        private void them_cttg_sach(int idpms, int idsach)
        {
            string connStr = "server=127.0.0.1;port=3306;user=root;password=admin;database=QLTV";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            // Câu truy vấn gồm: chèn dữ liệu vào và lấy định danh(Primary key) mới chèn vào
            string query = @"INSERT INTO chitiet_pms (id_pms, id_sach, tinhtrang) VALUES (@id_pms, @id_sach, @tinhtrang);";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_pms", idpms);
            cmd.Parameters.AddWithValue("@id_sach", idsach);
            cmd.Parameters.AddWithValue("@tinhtrang", "đã trả");
            cmd.ExecuteScalar(); // Thi hành SQL trả về giá trị đầu tiên

        }
        private void them_ctpts_sach(int idpts, int idsach)
        {
            string connStr = "server=127.0.0.1;port=3306;user=root;password=admin;database=QLTV";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            // Câu truy vấn gồm: chèn dữ liệu vào và lấy định danh(Primary key) mới chèn vào
            string query = @"INSERT INTO chitiet_pts (id_pts, id_sach) VALUES (@id_pts, @id_sach);";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_pts", idpts);
            cmd.Parameters.AddWithValue("@id_sach", idsach);
            cmd.ExecuteScalar(); // Thi hành SQL trả về giá trị đầu tiên

        }
        public void capnhatdausach(int iddausach)
        {
            string connStr = "server=127.0.0.1;port=3306;user=root;password=admin;database=QLTV";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            string query = @"update dausach set dangchomuon = dangchomuon - 1, sanco = sanco + 1 where id_dausach = @id_dausach";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_dausach", iddausach);

            cmd.ExecuteNonQuery();

        }
        public void capnhatcuonsach(int idsach)
        {
            string connStr = "server=127.0.0.1;port=3306;user=root;password=admin;database=QLTV";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            string query = @"update sach set tinhtrang = 'có sẵn' where id_sach = @id_sach";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_sach", idsach);

            cmd.ExecuteNonQuery();
        }
        
        public int getdausach(int idsach)
        {
            int kq = 0;
            string connStr = "server=127.0.0.1;port=3306;user=root;password=admin;database=QLTV";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            string query = @"select id_dausach from sach where id_sach = @id_sach";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_sach", idsach);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {

                    kq = Convert.ToInt32(reader["id_dausach"]);
                };

            }
            return kq;

        }
    } 
}
