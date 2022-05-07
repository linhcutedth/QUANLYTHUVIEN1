using System;
using System.Collections.Generic;

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

        public int IdPts { get; set; }
        public int IdDg { get; set; }
        public DateTime? Ngtra { get; set; }
        public decimal? Tienphatkinay { get; set; }
        public decimal? Tongno { get; set; }

        public virtual Thedocgia IdDgNavigation { get; set; }
        public virtual ICollection<ChitietPts> ChitietPts { get; set; }
        public virtual ICollection<Phieuthutienphat> Phieuthutienphat { get; set; }
    }
}
