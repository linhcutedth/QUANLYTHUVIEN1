using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class ChitietPts
    {
        public int IdPts { get; set; }
        public int IdSach { get; set; }
        public decimal? Songmuon { get; set; }
        public decimal? Tienphat { get; set; }

        public virtual Phieutrasach IdPtsNavigation { get; set; }
        public virtual Sach IdSachNavigation { get; set; }
    }
}
