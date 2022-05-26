using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class Phieutrasach
    {
        public Phieutrasach()
        {
            ChitietPts = new HashSet<ChitietPts>();
            Phieuthutienphat = new HashSet<Phieuthutienphat>();
        }
        [Display(Name = "Mã phiếu trả sách")]
        public int IdPts { get; set; }
        [Display(Name = "Mã độc giả")]
        public int IdDg { get; set; }
        [Display(Name = "Ngày trả")]
        public DateTime? Ngtra { get; set; }
        [Display(Name = "Tiền phạt kì này")]
        public decimal? Tienphatkinay { get; set; }
        [Display(Name = "Tổng nợ")]
        public decimal? Tongno { get; set; }

        public virtual Thedocgia IdDgNavigation { get; set; }
        public virtual ICollection<ChitietPts> ChitietPts { get; set; }
        public virtual ICollection<Phieuthutienphat> Phieuthutienphat { get; set; }
    }
}
