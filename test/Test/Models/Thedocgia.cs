using System;
using System.Collections.Generic;

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

        public int IdDg { get; set; }
        public string Hotendg { get; set; }
        public string Loaidg { get; set; }
        public DateTime? Ngsinh { get; set; }
        public string Diachi { get; set; }
        public string Email { get; set; }
        public DateTime? Nglapthe { get; set; }
        public string Tinhtrang { get; set; }

        public virtual ICollection<Phieumuonsach> Phieumuonsach { get; set; }
        public virtual ICollection<Phieutrasach> Phieutrasach { get; set; }
    }
}
