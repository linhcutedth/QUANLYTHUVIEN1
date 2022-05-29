using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class Thamso
    {
        [Display(Name = "Tuổi nhỏ nhất")]
        public int? Mintuoi { get; set; }
        [Display(Name = "Tuổi lớn nhất")]
        public int? Maxtuoi { get; set; }
        public int Thoihanthe { get; set; }
        [Display(Name = "Thời hạn thẻ")]

        public decimal? KcNamxb { get; set; }
        [Display(Name = "Số sách mượn lớn nhất")]
        public decimal? Maxsachmuon { get; set; }
        [Display(Name = "Số ngày mượn lớn nhất")]
        public decimal? Maxngaymuon { get; set; }
    }
}
