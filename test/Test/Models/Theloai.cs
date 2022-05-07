using System;
using System.Collections.Generic;

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

        public int IdTheloai { get; set; }
        public string Tentheloai { get; set; }

        public virtual ICollection<Dausach> Dausach { get; set; }
    }
}
