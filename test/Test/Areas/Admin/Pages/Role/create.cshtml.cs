﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.Data;

namespace App.Admin.Role
{
    //[Authorize(Roles = "admin")]

    public class CreateModel : RolePageModel
    {
        public CreateModel(RoleManager<IdentityRole> roleManager, QLTVContext myBlogContext) : base(roleManager, myBlogContext)
        {

        }

        public class InputModel
        {
            [Display(Name = "Tên của role")]
            [Required(ErrorMessage = "Phải nhập {0}")]
            [StringLength(200, MinimumLength = 3, ErrorMessage = "{0} phải dài {2} đến {1} ký tự")]
            public string Name { get; set; }
        }

        [BindProperty]
        // binding dữ liệu khi người dùng summit
        public InputModel Input { set; get; }

        public void OnGet()
        {
        }
        // bat dong bo async
        // khi an tao moi thi OnPostAsync duoc ta
        public async Task<IActionResult> OnPostAsync()
        {
            // neu du lieu ko phu hop => page
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newRole = new IdentityRole(Input.Name.ToLower());
            var result = await _roleManager.CreateAsync(newRole);
            if (result.Succeeded)
            {
                StatusMessage = $"Bạn vừa tạo role mới: {Input.Name}";
                return RedirectToPage("./Index");
            }
            else
            {
                result.Errors.ToList().ForEach(error => {
                    ModelState.AddModelError(string.Empty, error.Description);
                });
            }



            return Page();
        }
    }
}