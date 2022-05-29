using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class Phieuthutienphat
    {
        [Display(Name = "Mã phiếu thu tiền phạt")]
        public int IdPhieuthu { get; set; }
        [Display(Name = "Mã phiếu trả sách")]
        public int IdPts { get; set; }
        [Display(Name = "Tổng nợ")]
        public decimal? Tongno { get; set; }
        [Display(Name = "Còn lại")]
        public decimal? Conlai { get; set; }

        public virtual Phieutrasach IdPtsNavigation { get; set; }
    }
}
