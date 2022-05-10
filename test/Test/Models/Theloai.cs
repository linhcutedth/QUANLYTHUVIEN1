using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class Theloai
    {
        public Theloai()
        {
            Dausach = new HashSet<Dausach>();
        }
        [Display(Name = "Mã thể loại")]
        public int IdTheloai { get; set; }
        [Display(Name = "Tên thể loại")]
        public string Tentheloai { get; set; }

        public virtual ICollection<Dausach> Dausach { get; set; }
    }
}
