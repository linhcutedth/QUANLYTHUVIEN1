using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
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
            ViewBag.TacGia = _context.Tacgia.ToList();
            ViewBag.Sach = _context.Sach.Where(c => c.TinhTrang == "sẵn có" ).ToList();
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
                                    TacGia = c.IdSachNavigation.IdDausachNavigation.ChitietDausachTacgia.Select(ct => new
                                    {
                                        //  IdTacgia = ct.IdTacgiaNavigation.IdTacgia,
                                        Tentg = ct.IdTacgiaNavigation.Tentg,
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

     
       
        // POST: PhieuMuonSachController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDg")] Phieumuonsach pms, string NgMuon, string txtSach)
        {
            if (String.IsNullOrEmpty(txtSach))
            {
                TempData["AlertMessage"] = "Phải nhấn nút áp dụng ở mục thêm sách";
                TempData["AlertType"] = "alert alert-danger";
            }
            else if (ModelState.IsValid)
            {

                pms.Ngmuon = Convert.ToDateTime(NgMuon);
                _context.Add(pms);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Tạo thành công";
                TempData["AlertType"] = "alert alert-success";

                xuly_pms_xtpms(pms.IdPms, txtSach);
               
                return RedirectToAction(nameof(Index));
            }
            ViewData["docgianav"] = new SelectList(_context.Thedocgia, "IdDg", "IdDg", pms.IdDg);
            return RedirectToAction(nameof(Index));
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


        private void xuly_pms_xtpms(int idpms, string txtSach)
        {
            string[] arrListStr = txtSach.Split('&');
            int iddocgia = getdocgia(idpms);
            int max_sachmuon = maxsachmuon();
            if (demsosachmuon(iddocgia) + arrListStr.Length - 1 > max_sachmuon)
            {
                TempData["AlertMessage"] = "Mượn hơn " + max_sachmuon + " cuốn rồi ông ơi";
                TempData["AlertType"] = "alert alert-danger";
                string connStr = "server=127.0.0.1;port=3306;user=root;password=admin;database=QLTV";
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();

                // Câu truy vấn gồm: chèn dữ liệu vào và lấy định danh(Primary key) mới chèn vào
                string query = @"Delete from phieumuonsach where id_pms = @id_pms";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_pms", idpms);
                cmd.ExecuteNonQuery();

            } else 
            for (int i = 0; i < arrListStr.Length - 1; i++)
            {
                int idsach = Int32.Parse(arrListStr[i]);
                them_cttg_sach(idpms, idsach);
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
            cmd.Parameters.AddWithValue("@tinhtrang", "chưa trả");
            cmd.ExecuteScalar(); // Thi hành SQL trả về giá trị đầu tiên

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

        public int getdocgia(int idpms)
        {
            int kq = 0;
            string connStr = "server=127.0.0.1;port=3306;user=root;password=admin;database=QLTV";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            string query = @"select id_dg from phieumuonsach where id_pms = @id_pms";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_pms", idpms);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {

                    kq = Convert.ToInt32(reader["id_dg"]);
                };

            }
            return kq;

        }
        public void capnhatdausach(int iddausach)
        {
            string connStr = "server=127.0.0.1;port=3306;user=root;password=admin;database=QLTV";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            string query = @"update dausach set dangchomuon = dangchomuon + 1, sanco = sanco - 1 where id_dausach = @id_dausach";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_dausach", iddausach);

            cmd.ExecuteNonQuery();

        }
        public void capnhatcuonsach(int idsach)
        {
            string connStr = "server=127.0.0.1;port=3306;user=root;password=admin;database=QLTV";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            string query = @"update sach set tinhtrang = 'đang cho mượn' where id_sach = @id_sach";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_sach", idsach);

            cmd.ExecuteNonQuery();
        }

        public int demsosachmuon(int iddocgia)
        {
            int kq = 0;

            string connStr = "server=127.0.0.1;port=3306;user=root;password=admin;database=QLTV";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();


            string query = @"select count(*) as sl from phieumuonsach p, chitiet_pms c where p.id_pms = c.id_pms and c.tinhtrang = 'chưa trả' and id_dg = @id_docgia";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_docgia", iddocgia);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {

                    kq = Convert.ToInt32(reader["sl"]);
                };

            }
            return kq;
        }

        public int maxsachmuon()
        {
            int kq = 0;

            string connStr = "server=127.0.0.1;port=3306;user=root;password=admin;database=QLTV";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();


            string query = @"select maxsachmuon from thamso";

            MySqlCommand cmd = new MySqlCommand(query, conn);
           

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {

                    kq = Convert.ToInt32(reader["maxsachmuon"]);
                };

            }
            return kq;
        }
    }
}
