#pragma checksum "D:\Nam3\HK2\NMCNPM\doan\gith\QUANLYTHUVIEN1\test\Test\Views\DauSach\ChiTietSach.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dda044d48415f08c2d8ea872346dbf68288f657d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DauSach_ChiTietSach), @"mvc.1.0.view", @"/Views/DauSach/ChiTietSach.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Nam3\HK2\NMCNPM\doan\gith\QUANLYTHUVIEN1\test\Test\Views\_ViewImports.cshtml"
using Test;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Nam3\HK2\NMCNPM\doan\gith\QUANLYTHUVIEN1\test\Test\Views\_ViewImports.cshtml"
using Test.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dda044d48415f08c2d8ea872346dbf68288f657d", @"/Views/DauSach/ChiTietSach.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce628290e7931cc4701d19d423f4cc50633f124a", @"/Views/_ViewImports.cshtml")]
    public class Views_DauSach_ChiTietSach : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 2 "D:\Nam3\HK2\NMCNPM\doan\gith\QUANLYTHUVIEN1\test\Test\Views\DauSach\ChiTietSach.cshtml"
  
    ViewData["Title"] = "ChiTietsach";
    var sach = ViewData["sach"] as Dausach;
    var theloai = ViewData["theloai"] as Theloai;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""hero-wrap hero-bread"" style=""background-image: url(/images/bg_6.jpg); "">
    <div class=""container"">
        <div class=""row no-gutters slider-text align-items-center justify-content-center"">
            <div class=""col-md-9 ftco-animate text-center"">
                <h1 class=""mb-0 bread"">Tủ Sách</h1>
            </div>
        </div>
    </div>
</div>

<section class=""ftco-section"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-6 mb-5 ftco-animate"">
                <img");
            BeginWriteAttribute("src", " src=\"", 667, "\"", 686, 1);
#nullable restore
#line 22 "D:\Nam3\HK2\NMCNPM\doan\gith\QUANLYTHUVIEN1\test\Test\Views\DauSach\ChiTietSach.cshtml"
WriteAttributeValue("", 673, sach.Hinhanh, 673, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid\" alt=\"Colorlib Template\">\n            </div>\n            <div class=\"col-lg-6 product-details pl-md-5 ftco-animate\">\n                <h3>");
#nullable restore
#line 25 "D:\Nam3\HK2\NMCNPM\doan\gith\QUANLYTHUVIEN1\test\Test\Views\DauSach\ChiTietSach.cshtml"
               Write(sach.Tensach);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                <div class=""rating d-flex"">
                    <p class=""text-left mr-4"">
                        <a href=""#"" class=""mr-2"">5.0</a>
                        <a href=""#""><span class=""ion-ios-star-outline""></span></a>
                        <a href=""#""><span class=""ion-ios-star-outline""></span></a>
                        <a href=""#""><span class=""ion-ios-star-outline""></span></a>
                        <a href=""#""><span class=""ion-ios-star-outline""></span></a>
                        <a href=""#""><span class=""ion-ios-star-outline""></span></a>
                    </p>
                    <p class=""text-left mr-4"">
                        <a href=""#"" class=""mr-2"" style=""color: #000;"">100 <span style=""color: #bbb;"">Rating</span></a>
                    </p>
                </div>
                <p class=""price""><span>");
#nullable restore
#line 39 "D:\Nam3\HK2\NMCNPM\doan\gith\QUANLYTHUVIEN1\test\Test\Views\DauSach\ChiTietSach.cshtml"
                                  Write(sach.Trigia?.ToString("#,##0 VNĐ"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></p>\n\n");
            WriteLiteral(@"            </div>

        </div>

        <div class=""row mt-5"">
            <div class=""col-md-12 nav-link-wrap"">
                <div class=""nav nav-pills d-flex text-center"" id=""v-pills-tab"" role=""tablist"" aria-orientation=""vertical"">
                    <a class=""nav-link ftco-animate active mr-lg-1"" id=""v-pills-1-tab"" data-toggle=""pill"" href=""#v-pills-1"" role=""tab"" aria-controls=""v-pills-1"" aria-selected=""true"">Mô tả</a>

                    <a class=""nav-link ftco-animate mr-lg-1"" id=""v-pills-2-tab"" data-toggle=""pill"" href=""#v-pills-2"" role=""tab"" aria-controls=""v-pills-2"" aria-selected=""false"">Chi Tiết</a>

                    <a class=""nav-link ftco-animate"" id=""v-pills-3-tab"" data-toggle=""pill"" href=""#v-pills-3"" role=""tab"" aria-controls=""v-pills-3"" aria-selected=""false"">Nhận xét của người dùng</a>

                </div>
            </div>
            <div class=""col-md-12 tab-wrap"">

                <div class=""tab-content bg-light"" id=""v-pills-tabContent"">

                    <div class=""tab-pane");
            WriteLiteral(@" fade show active"" id=""v-pills-1"" role=""tabpanel"" aria-labelledby=""day-1-tab"">
                        <div class=""p-4"">
                            <p>Chiếc laptop này mang đến cảm giác cực hầm hố thể hiện sự mạnh mẽ trên từng đường nét với gam màu đen tuyền, các góc cạnh cứng cáp. Vỏ máy được làm từ nhựa cao cấp đem đến khả năng chịu lực tốt, không quá nặng khi cho vào balo để di chuyển đối với một chiếc máy tính gaming. Mặt lưng của phiên bản mới này được tô điểm thêm bằng những đường cắt góc cạnh tựa như những tia sét trên nền đen nhám, tạo cảm giác khí thể mỗi khi mở nắp máy.</p>
                        </div>
                    </div>

                    <div class=""tab-pane fade"" id=""v-pills-2"" role=""tabpanel"" aria-labelledby=""v-pills-day-2-tab"">
                        <div class=""p-4"">
                            <div class=""container"">
                                <table class=""table"">
                                    <thead class=""thead-light"">
                                        <tr>
 ");
            WriteLiteral(@"                                           <th colspan=""2"">Thể loại</th>
                                        </tr>
                                    </thead>
                                    <tbody>

                                        <tr>
                                            <th scope=""row"">Tên thể loại</th>
                                            <td>");
#nullable restore
#line 111 "D:\Nam3\HK2\NMCNPM\doan\gith\QUANLYTHUVIEN1\test\Test\Views\DauSach\ChiTietSach.cshtml"
                                           Write(theloai.Tentheloai);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                        </tr>
                                    </tbody>
                                </table>
                                <table class=""table"">
                                    <thead class=""thead-light"">
                                        <tr>
                                            <th colspan=""2"">Đầu sách</th>
                                        </tr>
                                    </thead>
                                    <tbody>

                                        <tr>
                                            <th scope=""row"">Tên sách</th>
                                            <td>");
#nullable restore
#line 125 "D:\Nam3\HK2\NMCNPM\doan\gith\QUANLYTHUVIEN1\test\Test\Views\DauSach\ChiTietSach.cshtml"
                                           Write(sach.Tensach);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                        </tr>\n                                        <tr>\n                                            <th scope=\"row\">Năm xuất bản</th>\n                                            <td>");
#nullable restore
#line 129 "D:\Nam3\HK2\NMCNPM\doan\gith\QUANLYTHUVIEN1\test\Test\Views\DauSach\ChiTietSach.cshtml"
                                           Write(sach.Namxuatban);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                        </tr>\n                                        <tr>\n                                            <th scope=\"row\">Nhà xuất bản</th>\n                                            <td>");
#nullable restore
#line 133 "D:\Nam3\HK2\NMCNPM\doan\gith\QUANLYTHUVIEN1\test\Test\Views\DauSach\ChiTietSach.cshtml"
                                           Write(sach.Nhaxuatban);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                        </tr>\n                                        <tr>\n                                            <th scope=\"row\">Tổng số</th>\n                                            <td>");
#nullable restore
#line 137 "D:\Nam3\HK2\NMCNPM\doan\gith\QUANLYTHUVIEN1\test\Test\Views\DauSach\ChiTietSach.cshtml"
                                           Write(sach.Tongso);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                        </tr>\n                                        <tr>\n                                            <th scope=\"row\">Sẵn có</th>\n                                            <td>");
#nullable restore
#line 141 "D:\Nam3\HK2\NMCNPM\doan\gith\QUANLYTHUVIEN1\test\Test\Views\DauSach\ChiTietSach.cshtml"
                                           Write(sach.Sanco);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                        </tr>\n                                        <tr>\n                                            <th scope=\"row\">Đang cho mượn</th>\n                                            <td>");
#nullable restore
#line 145 "D:\Nam3\HK2\NMCNPM\doan\gith\QUANLYTHUVIEN1\test\Test\Views\DauSach\ChiTietSach.cshtml"
                                           Write(sach.Dangchomuon);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                        </tr>
                                    </tbody>
                                </table>
                                
                            </div>
                        </div>
                    </div>
                    <div class=""tab-pane fade"" id=""v-pills-3"" role=""tabpanel"" aria-labelledby=""v-pills-day-3-tab"">
                        <div class=""row p-4"">
                            <div class=""col-md-7"">
                                <h3 class=""mb-4"">23 Reviews</h3>
                                <div class=""review"">
                                    <div class=""user-img"" style=""background-image: url(images/person_1.jpg)""></div>
                                    <div class=""desc"">
                                        <h4>
                                            <span class=""text-left"">Jacob Webb</span>
                                            <span class=""text-right"">14 March 2018</span>
                                      ");
            WriteLiteral(@"  </h4>
                                        <p class=""star"">
                                            <span>
                                                <i class=""ion-ios-star-outline""></i>
                                                <i class=""ion-ios-star-outline""></i>
                                                <i class=""ion-ios-star-outline""></i>
                                                <i class=""ion-ios-star-outline""></i>
                                                <i class=""ion-ios-star-outline""></i>
                                            </span>
                                            <span class=""text-right""><a href=""#"" class=""reply""><i class=""icon-reply""></i></a></span>
                                        </p>
                                        <p>When she reached the first hills of the Italic Mountains, she had a last view back on the skyline of her hometown Bookmarksgrov</p>
                                    </div>
                                </d");
            WriteLiteral(@"iv>
                                <div class=""review"">
                                    <div class=""user-img"" style=""background-image: url(images/person_2.jpg)""></div>
                                    <div class=""desc"">
                                        <h4>
                                            <span class=""text-left"">Jacob Webb</span>
                                            <span class=""text-right"">14 March 2018</span>
                                        </h4>
                                        <p class=""star"">
                                            <span>
                                                <i class=""ion-ios-star-outline""></i>
                                                <i class=""ion-ios-star-outline""></i>
                                                <i class=""ion-ios-star-outline""></i>
                                                <i class=""ion-ios-star-outline""></i>
                                                <i class=""ion-ios-star-outline""><");
            WriteLiteral(@"/i>
                                            </span>
                                            <span class=""text-right""><a href=""#"" class=""reply""><i class=""icon-reply""></i></a></span>
                                        </p>
                                        <p>When she reached the first hills of the Italic Mountains, she had a last view back on the skyline of her hometown Bookmarksgrov</p>
                                    </div>
                                </div>
                                <div class=""review"">
                                    <div class=""user-img"" style=""background-image: url(images/person_3.jpg)""></div>
                                    <div class=""desc"">
                                        <h4>
                                            <span class=""text-left"">Jacob Webb</span>
                                            <span class=""text-right"">14 March 2018</span>
                                        </h4>
                                        <p");
            WriteLiteral(@" class=""star"">
                                            <span>
                                                <i class=""ion-ios-star-outline""></i>
                                                <i class=""ion-ios-star-outline""></i>
                                                <i class=""ion-ios-star-outline""></i>
                                                <i class=""ion-ios-star-outline""></i>
                                                <i class=""ion-ios-star-outline""></i>
                                            </span>
                                            <span class=""text-right""><a href=""#"" class=""reply""><i class=""icon-reply""></i></a></span>
                                        </p>
                                        <p>When she reached the first hills of the Italic Mountains, she had a last view back on the skyline of her hometown Bookmarksgrov</p>
                                    </div>
                                </div>
                            </div>
           ");
            WriteLiteral(@"                 <div class=""col-md-4"">
                                <div class=""rating-wrap"">
                                    <h3 class=""mb-4"">Give a Review</h3>
                                    <p class=""star"">
                                        <span>
                                            <i class=""ion-ios-star-outline""></i>
                                            <i class=""ion-ios-star-outline""></i>
                                            <i class=""ion-ios-star-outline""></i>
                                            <i class=""ion-ios-star-outline""></i>
                                            <i class=""ion-ios-star-outline""></i>
                                            (98%)
                                        </span>
                                        <span>20 Reviews</span>
                                    </p>
                                    <p class=""star"">
                                        <span>
                                            <i");
            WriteLiteral(@" class=""ion-ios-star-outline""></i>
                                            <i class=""ion-ios-star-outline""></i>
                                            <i class=""ion-ios-star-outline""></i>
                                            <i class=""ion-ios-star-outline""></i>
                                            <i class=""ion-ios-star-outline""></i>
                                            (85%)
                                        </span>
                                        <span>10 Reviews</span>
                                    </p>
                                    <p class=""star"">
                                        <span>
                                            <i class=""ion-ios-star-outline""></i>
                                            <i class=""ion-ios-star-outline""></i>
                                            <i class=""ion-ios-star-outline""></i>
                                            <i class=""ion-ios-star-outline""></i>
                                      ");
            WriteLiteral(@"      <i class=""ion-ios-star-outline""></i>
                                            (98%)
                                        </span>
                                        <span>5 Reviews</span>
                                    </p>
                                    <p class=""star"">
                                        <span>
                                            <i class=""ion-ios-star-outline""></i>
                                            <i class=""ion-ios-star-outline""></i>
                                            <i class=""ion-ios-star-outline""></i>
                                            <i class=""ion-ios-star-outline""></i>
                                            <i class=""ion-ios-star-outline""></i>
                                            (98%)
                                        </span>
                                        <span>0 Reviews</span>
                                    </p>
                                    <p class=""star"">
                   ");
            WriteLiteral(@"                     <span>
                                            <i class=""ion-ios-star-outline""></i>
                                            <i class=""ion-ios-star-outline""></i>
                                            <i class=""ion-ios-star-outline""></i>
                                            <i class=""ion-ios-star-outline""></i>
                                            <i class=""ion-ios-star-outline""></i>
                                            (98%)
                                        </span>
                                        <span>0 Reviews</span>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<style>
    .table .thead-light th {
        font-weight: bold;
    }

    .table th {
        font-weight: bold;
        text-align: center !important;
        vertical-align: m");
            WriteLiteral("iddle;\n        padding: 40px 10px;\n        border-bottom: 1px solid rgba(0, 0, 0, 0.05) !important;\n    }\n</style>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
