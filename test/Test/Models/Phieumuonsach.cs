using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class Phieumuonsach
    {
        public Phieumuonsach()
        {
            ChitietPms = new HashSet<ChitietPms>();
        }

        public int IdPms { get; set; }
        public int IdDg { get; set; }
        public DateTime? Ngmuon { get; set; }

        public virtual Thedocgia IdDgNavigation { get; set; }
        public virtual ICollection<ChitietPms> ChitietPms { get; set; }
    }
}
