using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class SachTraTre
    {
        public SachTraTre() { }
        [Display(Name = "STT")]
        public int STT { get; set; }
        [Display(Name = "Tên sách")]
        public string Tensach { get; set; }
        [Display(Name = "số ngày trả trễ")]
        public decimal Songtratre { get; set; }
        [Display(Name = "Ngày mượn")]
        public DateTime Ngmuon { get; set; }

    }
}
