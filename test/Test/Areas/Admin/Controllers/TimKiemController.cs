using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
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
    public class TimKiemController : Controller
    {
        private readonly QLTVContext _context;

        private readonly IConfiguration _configuration;
        public TimKiemController(QLTVContext context, IConfiguration config)
        {
            _context = context;
            _configuration = config;
        }
        public async Task<IActionResult> Index()
        {
            var lapTopContext = _context.Dausach
                .Include(s => s.IdTheloaiNavigation)
                .Include(ct => ct.ChitietDausachTacgia)
                    .ThenInclude(i => i.IdTacgiaNavigation);
            
            return View(await lapTopContext.ToListAsync());
        }
        public void ExportToExcel()
        {
            var lapTopContext = _context.Dausach
                .Include(s => s.IdTheloaiNavigation)
                .Include(ct => ct.ChitietDausachTacgia)
                    .ThenInclude(i => i.IdTacgiaNavigation).ToList();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet Sheet = pck.Workbook.Worksheets.Add("Report");
            Sheet.Cells["A1"].Value = "Mã đầu sách";
            Sheet.Cells["B1"].Value = "Tên sách";
            Sheet.Cells["C1"].Value = "Thể loại";

            int row = 2;
            foreach (var item in lapTopContext)
            {

                Sheet.Cells[string.Format("A{0}", row)].Value = item.IdDausach;
                Sheet.Cells[string.Format("B{0}", row)].Value = item.Tensach;
                Sheet.Cells[string.Format("C{0}", row)].Value = item.IdTheloaiNavigation.Tentheloai;
                row++;
            }


            Sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.Headers.Add("content-disposition", "attachment: filename=" + "Report.xlsx");
            Response.Body.WriteAsync(pck.GetAsByteArray());
        }
    }
}
