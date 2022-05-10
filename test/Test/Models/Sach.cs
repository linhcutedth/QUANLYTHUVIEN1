using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class Sach
    {
        public Sach()
        {
            ChitietPms = new HashSet<ChitietPms>();
            ChitietPts = new HashSet<ChitietPts>();
        }
        [Display(Name = "Mã sách")]
        public int IdSach { get; set; }
        [Display(Name = "Mã đầu sách")]
        public int IdDausach { get; set; }
        [Display(Name = "Tình trạng")]
        public string TinhTrang { get; set; }

        public virtual Dausach IdDausachNavigation { get; set; }
        public virtual ICollection<ChitietPms> ChitietPms { get; set; }
        public virtual ICollection<ChitietPts> ChitietPts { get; set; }
    }
}
