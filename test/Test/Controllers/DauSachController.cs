using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test.Models;
using Test.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Test.Controllers
{
    public class DauSachController : Controller
    {
        private readonly QLTVContext _context;

        private readonly IConfiguration _configuration;
        public DauSachController(QLTVContext context)
        {
            _context = context;
        }
        private List<Dausach> docDauSach(MySqlDataReader reader)
        {
            List<Dausach> list = new List<Dausach>();
            using (reader)
            {
                while (reader.Read())
                {
                    list.Add(new Dausach()
                    {
                        IdDausach = Convert.ToInt32(reader["id_dausach"]),
                        IdTheloai = Convert.ToInt32(reader["id_theloai"]),
                        Tensach = reader["tensach"].ToString(),
                        Nhaxuatban = reader["nhaxuatban"].ToString(),
                        Namxuatban = Convert.ToInt32(reader["namxuatban"]),
                        Ngnhap = (DateTime)reader["ngnhap"],
                        Trigia = Convert.ToInt32(reader["trigia"]),
                        Tongso = Convert.ToInt32(reader["tongso"]),
                        Sanco = Convert.ToInt32(reader["sanco"]),
                        Dangchomuon = Convert.ToInt32(reader["dangchomuon"]),
                        Hinhanh = reader["hinhanh"].ToString(),
                    });

                }
            }
            return list;
        }
        private List<Dausach> LayDauSachTheoTrang(int page)
        {
            List<Dausach> list = new List<Dausach>();
            //string connStr = _configuration.GetConnectionString("DefaultConnection");
            string connStr = "server=127.0.0.1;port=3306;user=root;password=admin;database=QLTV";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string query = "select * from Dausach LIMIT @page,12";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@page", (page - 1) * 12);
            var reader = cmd.ExecuteReader();
            list = docDauSach(reader);
            return list;

        }

        private List<Dausach> LayDauSachTheoTheLoai(int idtheloai)
        {
            List<Dausach> list = new List<Dausach>();
            string connStr = "server=127.0.0.1;port=3306;user=root;password=admin;database=QLTV";
            //string connStr = _configuration.GetConnectionString("DefaultConnection");
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string query = "select * from dausach where id_theloai = @idtheloai";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idtheloai", idtheloai);
            var reader = cmd.ExecuteReader();
            list = docDauSach(reader);
            return list;

        }

        private List<Dausach> LayDSSPTheoTheLoaiTheoTrang(int idtheloai, int page)
        {
            List<Dausach> list = new List<Dausach>();
            string connStr = _configuration.GetConnectionString("DefaultConnection");
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string query = "select * from Dausach where id_theloai = @id_theloai LIMIT @page,6 ;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_theloai", idtheloai);
            cmd.Parameters.AddWithValue("@page", page * 6);
            var reader = cmd.ExecuteReader();
            list = docDauSach(reader);
            return list;

        }

        // GET: Sanpham
        public IActionResult Sach(int idtheloai, int page)
        {
            Console.WriteLine(idtheloai);
            List<Dausach> spList = new List<Dausach>();
            var qLTVContext = _context.Dausach.Include(d => d.IdTheloaiNavigation);
            double totalPage;
                if (idtheloai == 0)
                {
                Console.WriteLine('1');
                    spList = qLTVContext.ToList();
                    float temp = spList.Count() / (float)12;
                    totalPage = Math.Ceiling(temp);
                    if (page == 0)
                    {
                        spList = spList.Take(12).ToList();
                    Console.WriteLine('3');
                }
                    else
                    {
                        spList = LayDauSachTheoTrang(page);
                    Console.WriteLine('4');
                }
                }
                else
                {
                Console.WriteLine('2');
                spList = LayDauSachTheoTheLoai(idtheloai);
                    float temp = spList.Count() / (float)12;
                    totalPage = Math.Ceiling(temp);
                    if (page == 0)
                    {
                        spList = spList.Take(12).ToList();
                    }
                    else
                    {
                        spList = LayDSSPTheoTheLoaiTheoTrang(idtheloai, page);
                    }
                }

                ViewBag.dsTheLoai = _context.Theloai.ToList();
                ViewBag.totalPage = totalPage;
                ViewBag.pageCurrent = page;
            return View(spList);
        }

        // GET: Sanpham/Details/5
        public async Task<IActionResult> ChiTietSach(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sach = _context.Dausach.Find(id);

            ViewData["TheLoai"] = _context.Theloai.Find(sach.IdTheloai);
            ViewData["sach"] = sach;
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }


        // GET: DauSach
        public async Task<IActionResult> Index()
        {
            var qLTVContext = _context.Dausach.Include(d => d.IdTheloaiNavigation);
            return View(await qLTVContext.ToListAsync());
        }

        // GET: DauSach/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dausach = await _context.Dausach
                .Include(d => d.IdTheloaiNavigation)
                .FirstOrDefaultAsync(m => m.IdDausach == id);
            if (dausach == null)
            {
                return NotFound();
            }

            return View(dausach);
        }

        // GET: DauSach/Create
        public IActionResult Create()
        {
            ViewData["IdTheloai"] = new SelectList(_context.Theloai, "IdTheloai", "IdTheloai");
            return View();
        }

        // POST: DauSach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDausach,IdTheloai,Tensach,Namxuatban,Nhaxuatban,Ngnhap,Trigia,Tongso,Sanco,Dangchomuon,Hinhanh")] Dausach dausach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dausach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTheloai"] = new SelectList(_context.Theloai, "IdTheloai", "IdTheloai", dausach.IdTheloai);
            return View(dausach);
        }

        // GET: DauSach/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dausach = await _context.Dausach.FindAsync(id);
            if (dausach == null)
            {
                return NotFound();
            }
            ViewData["IdTheloai"] = new SelectList(_context.Theloai, "IdTheloai", "IdTheloai", dausach.IdTheloai);
            return View(dausach);
        }

        // POST: DauSach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDausach,IdTheloai,Tensach,Namxuatban,Nhaxuatban,Ngnhap,Trigia,Tongso,Sanco,Dangchomuon,Hinhanh")] Dausach dausach)
        {
            if (id != dausach.IdDausach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dausach);
                    await _context.SaveChangesAsync();
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
            ViewData["IdTheloai"] = new SelectList(_context.Theloai, "IdTheloai", "IdTheloai", dausach.IdTheloai);
            return View(dausach);
        }

        // GET: DauSach/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dausach = await _context.Dausach
                .Include(d => d.IdTheloaiNavigation)
                .FirstOrDefaultAsync(m => m.IdDausach == id);
            if (dausach == null)
            {
                return NotFound();
            }

            return View(dausach);
        }

        // POST: DauSach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dausach = await _context.Dausach.FindAsync(id);
            _context.Dausach.Remove(dausach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DausachExists(int id)
        {
            return _context.Dausach.Any(e => e.IdDausach == id);
        }
    }
}
