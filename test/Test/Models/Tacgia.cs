using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class Tacgia
    {
        public Tacgia()
        {
            ChitietDausachTacgia = new HashSet<ChitietDausachTacgia>();
        }

        public int IdTacgia { get; set; }
        public string Tentg { get; set; }

        public virtual ICollection<ChitietDausachTacgia> ChitietDausachTacgia { get; set; }
    }
}
