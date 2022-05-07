using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class ChitietPms
    {
        public int IdPms { get; set; }
        public int IdSach { get; set; }
        public string Tinhtrang { get; set; }

        public virtual Phieumuonsach IdPmsNavigation { get; set; }
        public virtual Sach IdSachNavigation { get; set; }
    }
}
