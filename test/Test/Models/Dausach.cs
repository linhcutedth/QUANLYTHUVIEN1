using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Display(Name = "Mã đầu sách")]
        public int IdDausach { get; set; }
        [Display(Name = "Thể loại")]
        public int IdTheloai { get; set; }
        [Display(Name = "Tên sách")]
        public string Tensach { get; set; }
        [Display(Name = "Năm xuất bản")]
        public int? Namxuatban { get; set; }
        [Display(Name = "Nhà xuất bản")]
        public string Nhaxuatban { get; set; }
        [Display(Name = "Ngày nhập")]
        public DateTime? Ngnhap { get; set; }
        [Display(Name = "Trị giá")]
        public int? Trigia { get; set; }
        [Display(Name = "Tổng số")]
        public int Tongso { get; set; }
        [Display(Name = "Sẵn có")]
        public int? Sanco { get; set; }
        [Display(Name = "Đang cho mượn")]
        public int? Dangchomuon { get; set; }
        [Display(Name = "Hình ảnh")]
        public string Hinhanh { get; set; }

        public virtual Theloai IdTheloaiNavigation { get; set; }
        public virtual ICollection<ChitietDausachTacgia> ChitietDausachTacgia { get; set; }
        public virtual ICollection<Sach> Sach { get; set; }

        [NotMapped]
        public IFormFile HinhAnhFile { get; set; }
    }
}
