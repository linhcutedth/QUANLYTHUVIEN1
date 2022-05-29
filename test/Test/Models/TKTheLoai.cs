using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class TKTheLoai
    {
        public TKTheLoai()
        {
        }
        [Display(Name = "STT")]
        public int STT { get; set; }
        [Display(Name = "Số lượt mượn")]
        public long Soluot { get; set; }
        [Display(Name = "Tên thể loại")]
        public string Tentheloai { get; set; }
        [Display(Name = "Tỷ lệ")]
        public Double Tyle { get; set; }
    }
}
