using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class ChitietPts
    {
        [Display(Name = "Mã phiếu trả sách")]
        public int IdPts { get; set; }
        [Display(Name = "Mã sách")]
        public int IdSach { get; set; }
        [Display(Name = "Số ngày mượn")]
        public decimal? Songmuon { get; set; }
        [Display(Name = "Tiền phạt")]
        public decimal? Tienphat { get; set; }

        public virtual Phieutrasach IdPtsNavigation { get; set; }
        public virtual Sach IdSachNavigation { get; set; }
    }
}
