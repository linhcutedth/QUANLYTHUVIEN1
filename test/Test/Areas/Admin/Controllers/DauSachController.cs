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
            var KcNamxb = _context.Thamso
                            .Select(x => new
                            {
                                KcNamxb = x.KcNamxb
                            }).Single();
            ViewBag.TheLoai = _context.Theloai.ToList();
            ViewBag.TacGia = _context.Tacgia.ToList();
            ViewBag.KcNamxb = KcNamxb.KcNamxb;
            return View(await lapTopContext.ToListAsync());
        }

        // GET: Sanpham/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var dausach = _context.Dausach.Where(x => x.IdDausach == id)
                            .Select(x => new 
                            {
                                IdDausach = x.IdDausach,
                                IdTheloai = x.IdTheloai,
                                Tensach = x.Tensach,
                                Namxuatban = x.Namxuatban,
                                Nhaxuatban = x.Nhaxuatban,
                                Ngnhap = x.Ngnhap,
                                Trigia = x.Trigia,
                                Tongso = x.Tongso,
                                Sanco = x.Sanco,
                                Dangchomuon = x.Dangchomuon,
                                Hinhanh = x.Hinhanh,
                                Tentheloai = x.IdTheloaiNavigation.Tentheloai,
                                TacGia = x.ChitietDausachTacgia.Select(c => new 
                                {
                                    IdTacgia = c.IdTacgiaNavigation.IdTacgia,
                                    Tentg = c.IdTacgiaNavigation.Tentg,
                                }).ToList()
                            }).Single();
            //var dausach = _context.Dausach.Find(id);
            ViewBag.TacGia = dausach.TacGia;
            //ViewData["theloainav"] = _context.Theloai.Find(dausach.IdTheloai);
            //ViewData["dausach"] = dausach;
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
        public async Task<IActionResult> Create([Bind("IdDausach,IdTheloai,Tensach,Namxuatban,Nhaxuatban,Trigia,Tongso,HinhAnhFile")] Dausach dausach,string NgNhap, string txttg)
        {
            if (String.IsNullOrEmpty(txttg))
            {
                TempData["AlertMessage"] = "Phải nhấn nút áp dụng ở mục thêm tác giả";
                TempData["AlertType"] = "alert alert-danger";
            }
            else if (ModelState.IsValid)
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
                for(int i = 0; i< dausach.Tongso; i++)
                {
                    them_cuon_sach(dausach.IdDausach);
                }
                xuly_cttg_dausach(dausach.IdDausach, txttg);
                return RedirectToAction(nameof(Index));
            }
            ViewData["theloainav"] = new SelectList(_context.Theloai, "idtheloai", "idtheloai", dausach.IdTheloai);
            return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> Edit(int id, [Bind("IdDausach,IdTheloai,Tensach,Namxuatban,Nhaxuatban,Trigia,Tongso,Ngnhap,HinhAnhFile,Sanco,Dangchomuon")] Dausach dausach, int tongsocu)
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
                    int temp = 0;
                    if(dausach.Tongso != tongsocu)
                    {
                        temp = dausach.Tongso - tongsocu;
                    }
                    dausach.Sanco = dausach.Sanco + temp;
                    _context.Update(dausach);
                    await _context.SaveChangesAsync();
                    for (int i = 0; i < temp; i++)
                    {
                        them_cuon_sach(dausach.IdDausach);
                    }
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
            try
            {
                var dausach = await _context.Dausach.FindAsync(id);
                if (dausach.Tongso == dausach.Sanco)
                {
                    xoa_cuon_sach(dausach.IdDausach);
                    xoa_cttg_ds(dausach.IdDausach);
                }
                _context.Dausach.Remove(dausach);
                await _context.SaveChangesAsync();
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

        private void them_cuon_sach(int iddausach)
        {
            string connStr = "server=127.0.0.1;port=3306;user=root;password=admin;database=QLTV";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            // Câu truy vấn gồm: chèn dữ liệu vào và lấy định danh(Primary key) mới chèn vào
            string query = @"INSERT INTO sach (id_dausach, tinhtrang) VALUES (@id_dausach, @tinhtrang);";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_dausach", iddausach);
            cmd.Parameters.AddWithValue("@tinhtrang", "sẵn có");

            cmd.ExecuteScalar(); // Thi hành SQL trả về giá trị đầu tiên
            
        }
        private void xuly_cttg_dausach(int iddausach,string txttacgia)
        {
            string[] arrListStr = txttacgia.Split('&');
            for (int i = 0; i < arrListStr.Length - 1; i++)
            {
                    int iddtacgia = Int32.Parse(arrListStr[i]);
                    them_cttg_sach(iddausach, iddtacgia);
            }
        }
        private void them_cttg_sach(int iddausach,int idtacgia)
        {
            string connStr = "server=127.0.0.1;port=3306;user=root;password=admin;database=QLTV";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            // Câu truy vấn gồm: chèn dữ liệu vào và lấy định danh(Primary key) mới chèn vào
            string query = @"INSERT INTO chitiet_dausach_tacgia (id_dausach, id_tacgia) VALUES (@id_dausach, @id_tacgia);";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_dausach", iddausach);
            cmd.Parameters.AddWithValue("@id_tacgia", idtacgia);

            cmd.ExecuteScalar(); // Thi hành SQL trả về giá trị đầu tiên

        }
        private void xoa_cuon_sach(int iddausach)
        {
            string connStr = "server=127.0.0.1;port=3306;user=root;password=admin;database=QLTV";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string query = @"delete from sach where id_dausach = @id_dausach;";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_dausach", iddausach);

            cmd.ExecuteNonQuery(); // Thi hành SQL trả về giá trị đầu tiên
        }
        private void xoa_cttg_ds(int iddausach)
        {
            string connStr = "server=127.0.0.1;port=3306;user=root;password=admin;database=QLTV";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            // Câu truy vấn gồm: chèn dữ liệu vào và lấy định danh(Primary key) mới chèn vào
            string query = @"delete from chitiet_dausach_tacgia where id_dausach = @id_dausach;";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_dausach", iddausach);

            cmd.ExecuteNonQuery(); // Thi hành SQL trả về giá trị đầu tiên
        }
    }
}
