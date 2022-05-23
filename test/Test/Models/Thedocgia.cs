using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class Thedocgia
    {
        public Thedocgia()
        {
            Phieumuonsach = new HashSet<Phieumuonsach>();
            Phieutrasach = new HashSet<Phieutrasach>();
        }
        [Display(Name = "Mã độc giả")]
        public int IdDg { get; set; }
        [Display(Name = "Họ tên tác giả")]
        public string Hotendg { get; set; }
        [Display(Name = "Loại độc giả")]
        public string Loaidg { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime? Ngsinh { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Diachi { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Ngày lập thẻ")]
        public DateTime? Nglapthe { get; set; }
        [Display(Name = "Tình trạng")]
        public string Tinhtrang { get; set; }

        public virtual ICollection<Phieumuonsach> Phieumuonsach { get; set; }
        public virtual ICollection<Phieutrasach> Phieutrasach { get; set; }
    }
}
