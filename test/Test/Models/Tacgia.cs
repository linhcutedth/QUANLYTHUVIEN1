using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Mã tác giả")]
        public int IdTacgia { get; set; }
        [Display(Name = "Tên tác giả")]
        public string Tentg { get; set; }

        public virtual ICollection<ChitietDausachTacgia> ChitietDausachTacgia { get; set; }
    }
}
