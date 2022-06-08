# QUANLYTHUVIEN1
GIỚI THIỆU ĐỒ ÁN

THUVIEN là trang web quản lý thư viện. Trang web được xây dựng trên nền tảng ASP.Net với ngôn ngữ chính là C#. Cơ sở dữ liệu sử dụng là MySQL 8.0. Trang web tích hợp các tính năng cơ bản của 1 trang web quản lý cùng với một số chức năng nâng cao khác. Giao diện trang web được tối ưu cho trải nghiệm người dùng tốt nhất có thể ở cả những trang khách hàng sử dụng hoặc trang quan trị dành cho admin.

CÁC CHỨC NĂNG ĐÃ LÀM

Admin:

Quản lý người dùng và phân quyền.
Quản lý đầu sách: Thông tin sách, tác giả, thể loại
Tìm kiếm đầu sách
Quản lý các phiếu mượn sách, phiếu trả sách
Chức năng báo cáo thống kê
Hỗ trợ nâng cấp hệ thống thông qua việc cập nhật các quy định

User:

Tạo tài khoản, đăng nhập
Hiển thị thông tin sách

---------------------

Giới thiệu công nghệ mới đã sử dụng đồ án (Không nằm trong phạm vi môn học) (Nếu có):

Đăng nhập bằng Google

------------------

CÀI ĐẶT CHƯƠNG TRÌNH WEB

Cơ sở dữ liệu sử dụng: MySQL 8.0
Thư viện sử dụng:
Microsoft.AspNetCore (ver 3.1.21)
Microsoft.EntityFrameworkCore (ver 3.1.21)
Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore( ver 3.1.21)
Microsoft.AspNetCore.Identity.EntityFrameworkCore( ver 3.1.21)
Microsoft.AspNetCore.Authentication.Google(ver 3.1.21)
Microsoft.EntityFrameworkCore.Design (ver 3.1.21)
Microsoft.AspNetCore.Identity.UI( ver 3.1.22)
Microsoft.EntityFrameworkCore.Tools(ver 3.1.21)
MySQL.Data( ver 8.0.27)
MySql.Data.EntityFrameworkCore( ver 8.0.22)
Microsoft.VisualStudio.Web.CodeGeneration.Design( ver 3.1.5)


CÁC BƯỚC CHẠY FRONTEND / BACKEND

B1: Clone project về máy.

B2: Cài đặt cơ sở dữ liệu MySQl 8.0

https://dev.mysql.com/downloads/mysql/
https://dev.mysql.com/downloads/workbench/
Thông số: UserName: ‘root’; Password: ‘admin’( Hoặc vào file appsettings để đặt lại phù hợp với cấu hình)

B3: Chạy file DATABASE.sql để tạo cơ sở dữ liệu.

B4: Kiểm tra các gói Nuget, cài đặt lại nếu không có hoặc có lỗi Xóa thư mục .vs Note: Microsoft.AspNetCore.Identity.UI ( cập nhật lên phiên bản 3.1.22) nếu bị lỗi UI.

B5: Chuyển IIS express thành Test để chạy

B6: Chạy chương trình và trải nghiệm
