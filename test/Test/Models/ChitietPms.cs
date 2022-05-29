using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class ChitietPms
    {
        [Display(Name = "Mã phiếu mượn sách")]
        public int IdPms { get; set; }
        [Display(Name = "Mã sách")]
        public int IdSach { get; set; }
        [Display(Name = "Tình trạng")]
        public string Tinhtrang { get; set; }

        public virtual Phieumuonsach IdPmsNavigation { get; set; }
        public virtual Sach IdSachNavigation { get; set; }
    }
}
