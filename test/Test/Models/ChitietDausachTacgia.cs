using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class ChitietDausachTacgia
    {
        public int IdDausach { get; set; }
        public int IdTacgia { get; set; }

        public virtual Dausach IdDausachNavigation { get; set; }
        public virtual Tacgia IdTacgiaNavigation { get; set; }
    }
}
