using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Data;
using Test.Models;

namespace Test.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThongKeController : Controller
    {
        private readonly QLTVContext _context;

        private readonly IConfiguration _configuration;
        public ThongKeController(QLTVContext context, IConfiguration config)
        {
            _context = context;
            _configuration = config;
        }
        public IActionResult Index()
        {
            return View();
        }
        private int TongCongTheLoai(int month, int year)
        {
            string connStr = "server=127.0.0.1;port=3306;user=root;password=admin;database=QLTV";
            //string connStr = _configuration.GetConnectionString("DefaultConnection");
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string query = @"select count(tl.tentheloai)
                            from phieumuonsach pms, chitiet_pms ct, sach s, dausach ds, theloai tl
                            where pms.id_pms = ct.id_pms 
                            and ct.id_sach = s.id_sach
                            and s.id_dausach = ds.id_dausach
                            and ds.id_theloai = tl.id_theloai
                            and month(ngmuon) = @month and year(ngmuon) = @year;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@month", month);
            cmd.Parameters.AddWithValue("@year", year);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return i;

        }
        [HttpPost]
        public IActionResult TKTheLoai(string datepicker)
        {
            string[] arrListStr = datepicker.Split('-');
            int month = Int32.Parse(arrListStr[0]);
            int year = Int32.Parse(arrListStr[1]);
            int tc = TongCongTheLoai(month, year);
            if ( tc == 0)
            {
                TempData["AlertMessage"] = "Chọn ngày tháng không hợp lệ";
                TempData["AlertType"] = "alert alert-danger";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                string connStr = "server=127.0.0.1;port=3306;user=root;password=admin;database=QLTV";
                //string connStr = _configuration.GetConnectionString("DefaultConnection");
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string query = @"select tl.tentheloai, count(tl.tentheloai)
                            from phieumuonsach pms, chitiet_pms ct, sach s, dausach ds, theloai tl
                            where pms.id_pms = ct.id_pms 
                            and ct.id_sach = s.id_sach
                            and s.id_dausach = ds.id_dausach
                            and ds.id_theloai = tl.id_theloai
                            and month(ngmuon) = @month and year(ngmuon) = @year
                            group by tl.tentheloai";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);
                List<TKTheLoai> list = new List<TKTheLoai>();
                int i = 1;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string temp = reader[1].ToString();
                        Double so = Double.Parse(temp);
                        list.Add(new TKTheLoai()
                        {
                            STT = i,
                            Tentheloai = reader[0].ToString(),
                            Soluot = (Int64)reader[1],
                            Tyle = so / tc * 100,
                        });
                        i++;
                    }
                }
                ViewBag.TongCong = tc;
                ViewBag.Month = month;
                ViewBag.Year = year;
                return View(list);
            }
            
        }

        [HttpPost]
        public JsonResult timThamSo()
        {
            var ts = _context.Thamso;
            return Json(ts);
        }
        [HttpPost]
        public async Task<IActionResult> TDTuoiThe(int TuoiMin,int TuoiMax,int The)
        {
            try
            {
                string connStr = "server=127.0.0.1;port=3306;user=root;password=admin;database=QLTV";
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();

                // Câu truy vấn gồm: chèn dữ liệu vào và lấy định danh(Primary key) mới chèn vào
                string query = @"UPDATE THAMSO SET MINTUOI = @MINTUOI, MAXTUOI = @MAXTUOI, THOIHANTHE= @THOIHANTHE";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MINTUOI", TuoiMin);
                cmd.Parameters.AddWithValue("@MAXTUOI", TuoiMax);
                cmd.Parameters.AddWithValue("@THOIHANTHE", The);
                cmd.ExecuteScalar(); // Thi hành SQL trả về giá trị đầu tiên  
                TempData["AlertMessage"] = "Thay đổi thành công";
                TempData["AlertType"] = "alert alert-success";

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                TempData["AlertMessage"] = "Thay đổi không thành công";
                TempData["AlertType"] = "alert alert-danger";
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpPost]
        public async Task<IActionResult> TDNamXB(int NamXBinput)
        {
            try
            {
                string connStr = "server=127.0.0.1;port=3306;user=root;password=admin;database=QLTV";
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();

                // Câu truy vấn gồm: chèn dữ liệu vào và lấy định danh(Primary key) mới chèn vào
                string query = @"UPDATE THAMSO SET KC_NAMXB = @KC_NAMXB";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@KC_NAMXB", NamXBinput);
                cmd.ExecuteScalar(); // Thi hành SQL trả về giá trị đầu tiên  
                TempData["AlertMessage"] = "Thay đổi thành công";
                TempData["AlertType"] = "alert alert-success";

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                TempData["AlertMessage"] = "Thay đổi không thành công";
                TempData["AlertType"] = "alert alert-danger";
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpPost]
        public async Task<IActionResult> TDNgaySach(int SoNgay, int SoSach)
        {
            try
            {
                string connStr = "server=127.0.0.1;port=3306;user=root;password=admin;database=QLTV";
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();

                // Câu truy vấn gồm: chèn dữ liệu vào và lấy định danh(Primary key) mới chèn vào
                string query = @"UPDATE THAMSO SET MAXSACHMUON = @MAXSACHMUON, MAXNGAYMUON=@MAXNGAYMUON";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MAXSACHMUON", SoSach);
                cmd.Parameters.AddWithValue("@MAXNGAYMUON", SoNgay);
                cmd.ExecuteScalar(); // Thi hành SQL trả về giá trị đầu tiên  
                TempData["AlertMessage"] = "Thay đổi thành công";
                TempData["AlertType"] = "alert alert-success";

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                TempData["AlertMessage"] = "Thay đổi không thành công";
                TempData["AlertType"] = "alert alert-danger";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public IActionResult TKSachTraTre(string datepicker)
        {
            string[] arrListStr = datepicker.Split('-');
            int month = Int32.Parse(arrListStr[0]);
            int year = Int32.Parse(arrListStr[1]);
            Console.WriteLine(month);
            Console.WriteLine(year);
            string connStr = "server=127.0.0.1;port=3306;user=root;password=admin;database=QLTV";
            //string connStr = _configuration.GetConnectionString("DefaultConnection");
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string query = @"select ds.TENSACH, s.ID_SACH, DATE_ADD(NGTRA,INTERVAL -SONGMUON DAY), SONGMUON - MAXNGAYMUON as SoNgTraTre
                            from phieutrasach pts, chitiet_pts ct, sach s, dausach ds, thamso ts
                            where pts.id_pts = ct.id_pts 
                            and ct.id_sach = s.id_sach
                            and s.id_dausach = ds.id_dausach
                            and month(NGTRA) = @month and year(NGTRA) = @year
                            and SONGMUON > ts.MAXNGAYMUON";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);
                List<SachTraTre> list = new List<SachTraTre>();
                int i = 1;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new SachTraTre()
                        {
                            STT = i,
                            Tensach = reader[0].ToString() + " - " + reader[1].ToString(),
                            Ngmuon = (DateTime)reader[2],
                            Songtratre = (decimal)reader[3],
                        });
                        i++;
                    }
                ViewBag.Month = month;
                ViewBag.Year = year;
                return View(list);
            }

        }

    }
}
