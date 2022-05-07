using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class Dausach
    {
        public Dausach()
        {
            ChitietDausachTacgia = new HashSet<ChitietDausachTacgia>();
            Sach = new HashSet<Sach>();
        }

        public int IdDausach { get; set; }
        public int IdTheloai { get; set; }
        public string Tensach { get; set; }
        public decimal? Namxuatban { get; set; }
        public string Nhaxuatban { get; set; }
        public DateTime? Ngnhap { get; set; }
        public decimal? Trigia { get; set; }
        public int? Tongso { get; set; }
        public int? Sanco { get; set; }
        public int? Dangchomuon { get; set; }
        public string Hinhanh { get; set; }

        public virtual Theloai IdTheloaiNavigation { get; set; }
        public virtual ICollection<ChitietDausachTacgia> ChitietDausachTacgia { get; set; }
        public virtual ICollection<Sach> Sach { get; set; }
    }
}
