using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class Phieuthutienphat
    {
        public int IdPhieuthu { get; set; }
        public int IdPts { get; set; }
        public decimal? Tongno { get; set; }
        public decimal? Conlai { get; set; }

        public virtual Phieutrasach IdPtsNavigation { get; set; }
    }
}
