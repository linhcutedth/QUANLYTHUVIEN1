using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Test.Data;

namespace App.Admin.Role
{
    //[Authorize(Roles = "admin")]
 
    public class IndexModel : RolePageModel
    {
        public IndexModel(RoleManager<IdentityRole> roleManager, QLTVContext myBlogContext) : base(roleManager, myBlogContext)
        {
        }
        // doc tata ca role trong manager roi hien ben index de thuc hien
        public List<IdentityRole> roles { set; get; }

        public async Task OnGet()
        {
            // sap xep theo ten
            roles = await _roleManager.Roles.OrderBy(r => r.Name).ToListAsync();
        }

        public void OnPost() => RedirectToPage();
    }
}