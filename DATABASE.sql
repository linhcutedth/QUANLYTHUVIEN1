/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     4/21/2022 10:26:29 AM                        */
/*==============================================================*/
drop database QLTV;
create database QLTV;
use QLTV;

drop table if exists CHITIET_DAUSACH_TACGIA;

drop table if exists CHITIET_PMS;

drop table if exists CHITIET_PTS;

drop table if exists DAUSACH;

drop table if exists PHIEUMUONSACH;

drop table if exists PHIEUTHUTIENPHAT;

drop index THUOC_FK on PHIEUTRASACH;

drop table if exists PHIEUTRASACH;

drop table if exists SACH;

drop table if exists TACGIA;

drop table if exists THAMSO;

drop table if exists THEDOCGIA;

drop table if exists THELOAI;

/*==============================================================*/
/* Table: CHITIETTACGIA                                         */
/*==============================================================*/
create table CHITIET_DAUSACH_TACGIA
(
   ID_DAUSACH           int not null,
   ID_TACGIA            int not null,
   primary key (ID_DAUSACH, ID_TACGIA)
);

/*==============================================================*/
/* Table: CHITIET_PMS                                           */
/*==============================================================*/
create table CHITIET_PMS
(
   ID_PMS               int not null,
   ID_SACH              int not null,
   TINHTRANG            varchar(20),
   primary key (ID_PMS, ID_SACH)
);

/*==============================================================*/
/* Table: CHITIET_PTS                                           */
/*==============================================================*/
create table CHITIET_PTS
(
   ID_PTS               int not null,
   ID_SACH              int not null,
   SONGMUON             numeric(8,0),
   TIENPHAT             numeric(8,0),
   primary key (ID_PTS, ID_SACH)
);

/*==============================================================*/
/* Table: DAUSACH                                               */
/*==============================================================*/
create table DAUSACH
(
   ID_DAUSACH           int AUTO_INCREMENT not null,
   ID_THELOAI           int not null,
   TENSACH              varchar(100),
   NAMXUATBAN           numeric(8,0),
   NHAXUATBAN           varchar(100),
   NGNHAP               date,
   TRIGIA               numeric(8,0),
   TONGSO               int,
   SANCO                int,
   DANGCHOMUON          int,
   HINHANH              varchar(200),
   primary key (ID_DAUSACH)
);

/*==============================================================*/
/* Table: PHIEUMUONSACH                                         */
/*==============================================================*/
create table PHIEUMUONSACH
(
   ID_PMS               int AUTO_INCREMENT not null,
   ID_DG                int not null,
   NGMUON               date,
   primary key (ID_PMS)
);

/*==============================================================*/
/* Table: PHIEUTHUTIENPHAT                                      */
/*==============================================================*/
create table PHIEUTHUTIENPHAT
(
   ID_PHIEUTHU          int AUTO_INCREMENT not null,
   ID_PTS               int not null,
   TONGNO               numeric(8,0),
   CONLAI               numeric(8,0),
   primary key (ID_PHIEUTHU)
);

/*==============================================================*/
/* Table: PHIEUTRASACH                                          */
/*==============================================================*/
create table PHIEUTRASACH
(
   ID_PTS               int not null,
   ID_DG                int not null,
   NGTRA                date,
   TIENPHATKINAY        numeric(8,0),
   TONGNO               numeric(8,0),
   primary key (ID_PTS)
);

/*==============================================================*/
/* Table: SACH                                                  */
/*==============================================================*/
create table SACH
(
   ID_SACH              int AUTO_INCREMENT not null,
   ID_DAUSACH           int not null,
   ATTRIBUTE_22         varchar(20),
   primary key (ID_SACH)
);

/*==============================================================*/
/* Table: TACGIA                                                */
/*==============================================================*/
create table TACGIA
(
   ID_TACGIA            int AUTO_INCREMENT not null,
   TENTG                varchar(50),
   primary key (ID_TACGIA)
);

/*==============================================================*/
/* Table: THAMSO                                                */
/*==============================================================*/
create table THAMSO
(
   MINTUOI              int,
   MAXTUOI              int,
   THOIHANTHE           int,
   KC_NAMXB             numeric(8,0),
   MAXSACHMUON          numeric(8,0),
   MAXNGAYMUON          numeric(8,0)
);

/*==============================================================*/
/* Table: THEDOCGIA                                             */
/*==============================================================*/
create table THEDOCGIA
(
   ID_DG                int AUTO_INCREMENT not null,
   HOTENDG              varchar(50),
   LOAIDG               varchar(40),
   NGSINH               date,
   DIACHI               varchar(100),
   EMAIL                varchar(50),
   NGLAPTHE             date,
   TINHTRANG            varchar(20),
   primary key (ID_DG)
);

/*==============================================================*/
/* Table: THELOAI                                               */
/*==============================================================*/
create table THELOAI
(
   ID_THELOAI           int AUTO_INCREMENT not null,
   TENTHELOAI           varchar(100),
   primary key (ID_THELOAI)
);

alter table CHITIET_DAUSACH_TACGIA add constraint FK_CHITIET_DAUSACH_TACGIA foreign key (ID_DAUSACH)
      references DAUSACH (ID_DAUSACH);

alter table CHITIET_DAUSACH_TACGIA add constraint FK_CHITIET_DAUSACH_TACGIA2 foreign key (ID_TACGIA)
      references TACGIA (ID_TACGIA);

alter table CHITIET_PMS add constraint FK_CHITIET_PMS foreign key (ID_PMS)
      references PHIEUMUONSACH (ID_PMS);

alter table CHITIET_PMS add constraint FK_CHITIET_PMS2 foreign key (ID_SACH)
      references SACH (ID_SACH);

alter table CHITIET_PTS add constraint FK_CHITIET_PTS foreign key (ID_PTS)
      references PHIEUTRASACH (ID_PTS);

alter table CHITIET_PTS add constraint FK_CHITIET_PTS2 foreign key (ID_SACH)
      references SACH (ID_SACH);

alter table DAUSACH add constraint FK_THUOC1 foreign key (ID_THELOAI)
      references THELOAI (ID_THELOAI);

alter table PHIEUMUONSACH add constraint FK_CO foreign key (ID_DG)
      references THEDOCGIA (ID_DG);

alter table PHIEUTHUTIENPHAT add constraint FK_THUOC2 foreign key (ID_PTS)
      references PHIEUTRASACH (ID_PTS);

alter table PHIEUTRASACH add constraint FK_CO1 foreign key (ID_DG)
      references THEDOCGIA (ID_DG);

alter table SACH add constraint FK_CO12 foreign key (ID_DAUSACH)
      references DAUSACH (ID_DAUSACH);

------------------------------------------ 
---- insert THEDOCGIA -------
insert into thedocgia values (1,'Nguyễn Thị Ái Linh','Sinh Viên',str_to_date('31/5/2001','%d/%m/%Y'),'KTX Khu A, ĐHQG','ntalinh@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'Còn hạn');
insert into thedocgia values (2,'Nguyễn Thị Hồng Hải','Sinh Viên',str_to_date('2/12/2001','%d/%m/%Y'),'KTX Khu A, ĐHQG','nthhai@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'Còn hạn');
insert into thedocgia values (3,'Nguyễn Nhật Minh','Sinh Viên',str_to_date('25/7/2001','%d/%m/%Y'),'KTX Khu A, ĐHQG','nnminh@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'Còn hạn');
insert into thedocgia values (4,'Bùi Bích Chăm','Sinh Viên',str_to_date('20/11/2001','%d/%m/%Y'),'KTX Khu A, ĐHQG','bbcham@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'Còn hạn');
insert into thedocgia values (5,'Võ Quang Huy','Sinh Viên',str_to_date('5/8/2001','%d/%m/%Y'),'KTX Khu A, ĐHQG','vqhuy@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'Còn hạn');
insert into thedocgia values (6,'Nguyễn Vũ Văn Đức','Sinh Viên',str_to_date('20/6/2001','%d/%m/%Y'),'KTX Khu A, ĐHQG','nvvduc@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'Còn hạn');
insert into thedocgia values (7,'Lê Mai Duy Khánh','Sinh Viên',str_to_date('4/5/2001','%d/%m/%Y'),'KTX Khu A, ĐHQG','lmdkhanh@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'Còn hạn');
insert into thedocgia values (8,'Nguyễn Ngọc Châu Pha','Sinh Viên',str_to_date('1/6/2001','%d/%m/%Y'),'KTX Khu A, ĐHQG','nncpha@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'Còn hạn');
insert into thedocgia values (9,'Hoàng Ngọc Thảo Quyên','Sinh Viên',str_to_date('21/4/2001','%d/%m/%Y'),'KTX Khu A, ĐHQG','hntquyen@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'Còn hạn');
insert into thedocgia values (10,'Nguyễn Lê Nguyên Khang','Sinh Viên',str_to_date('1/7/2001','%d/%m/%Y'),'KTX Khu A, ĐHQG','nlnkhang@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'Còn hạn');
insert into thedocgia values (11,'Phạm Như Long','Sinh Viên',str_to_date('21/4/2001','%d/%m/%Y'),'KTX Khu A, ĐHQG','pnlong@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'Còn hạn');
insert into thedocgia values (12,'Ngô Tường Vy','Sinh Viên',str_to_date('1/8/2001','%d/%m/%Y'),'KTX Khu A, ĐHQG','ntvy@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'Còn hạn');
insert into thedocgia values (13,'Phạm Đăng Khoa','Sinh Viên',str_to_date('20/11/2001','%d/%m/%Y'),'KTX Khu A, ĐHQG','pdkhoa@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'Còn hạn');
insert into thedocgia values (14,'Nguyễn Văn Chí','Giảng Viên',str_to_date('23/1/1992','%d/%m/%Y'),'KTX Khu A, ĐHQG','nvchi@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'Còn hạn');
insert into thedocgia values (15,'Lục Thị Tươi','Giảng Viên',str_to_date('25/2/1991','%d/%m/%Y'),'KTX Khu A, ĐHQG','lttuoi@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'Còn hạn');
insert into thedocgia values (16,'Huỳnh Duy Tân','Giảng Viên',str_to_date('23/12/1993','%d/%m/%Y'),'KTX Khu A, ĐHQG','hdtan@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'Còn hạn');
insert into thedocgia values (17,'Phạm Hồng Phước','Giảng Viên',str_to_date('25/3/1992','%d/%m/%Y'),'KTX Khu A, ĐHQG','phphuoc@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'Còn hạn');
insert into thedocgia values (18,'Đoàn Thùy Trang','Giảng Viên',str_to_date('23/1/1994','%d/%m/%Y'),'KTX Khu A, ĐHQG','dttrang@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'Còn hạn');
insert into thedocgia values (19,'Nguyễn Thị Nhân','Giảng Viên',str_to_date('25/6/1993','%d/%m/%Y'),'KTX Khu A, ĐHQG','ntnhan@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'Còn hạn');
insert into thedocgia values (20,'Nguyễn Thị Hồng','Giảng Viên',str_to_date('23/1/1995','%d/%m/%Y'),'KTX Khu A, ĐHQG','nthong@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'Còn hạn');




INSERT INTO theloai (`ID_THELOAI`, `TENTHELOAI`) VALUES ('3', 'Sách tiểu thuyết');



INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('31', '3', 'Luật tâm thức', '2021', 'Nhà Xuất Bản Dân Trí', '2022-04-26', '180439', '3', '3', '0', '/HinhAnh/31.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('32', '3', 'Hội chứng E', '2020', 'NXB Hội Nhà Văn', '2022-04-26', '288500', '3', '3', '0', '/HinhAnh/32.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('33', '3', 'Án Mạng Mười Một Chữ', '2020', 'Nhà Xuất Bản Hội Nhà Văn', '2022-04-26', '288500', '3', '3', '0', '/HinhAnh/33.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('34', '3', 'Nỗi buồn chiến tranh', '2017', 'NXB Trẻ', '2022-04-26', '115000', '3', '3', '0', '/HinhAnh/34.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('35', '3', 'Những ngày thơ ấu', '2021', 'Nhà Xuất Bản Hội Nhà Văn', '2022-04-26', '54800', '3', '3', '0', '/HinhAnh/35.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('36', '3', 'Không gia đình', '2022', 'Nhà Xuất Bản Mỹ Thuật', '2022-04-26', '84400', '3', '3', '0', '/HinhAnh/36.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('37', '3', 'Suối nguồn', '2018', 'NXB Trẻ', '2022-04-26', '230800', '3', '3', '0', '/HinhAnh/37.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('38', '3', 'Bố già', '2016', 'Nhà Xuất Bản Văn Học', '2022-04-26', '63923', '3', '3', '0', '/HinhAnh/38.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('39', '3', 'Hai số phận', '2018', 'Nhà Xuất Bản Văn Học', '2022-04-26', '111000', '3', '3', '0', '/HinhAnh/39.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('40', '3', 'Nhà giả kim', '2020', 'Nhà Xuất Bản Hà Nội', '2022-04-26', '53544', '3', '3', '0', '/HinhAnh/40.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('41', '3', 'Điều kì diệu ', '2019', 'NXB Trẻ', '2022-04-26', '118400', '3', '3', '0', '/HinhAnh/41.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('42', '3', 'Những đêm không ngủ những ngày chậm trôi', '2021', 'Nhà Xuất Bản Văn Học', '2022-04-26', '54960 ', '3', '3', '0', '/HinhAnh/42.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('43', '3', 'Rừng Nauy', '2021', 'Nhà Xuất Bản Hội Nhà Văn', '2022-04-26', '109500', '3', '3', '0', '/HinhAnh/43.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('44', '3', 'Đi tìm lẽ sống', '2019', 'NXB Tổng Hợp TPHCM', '2022-04-26', '62400', '3', '3', '0', '/HinhAnh/44.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('45', '3', 'Trà hoa nữ', '2015', 'NXB Văn Học', '2022-04-26', '55800', '3', '3', '0', '/HinhAnh/45.jpg');



INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('36', 'Ngô Sa Thạch');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('37', 'Franck Thilliez');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('38', 'Higashino Keigo');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('39', 'Bảo Ninh');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('40', 'Nguyên Hồng');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('41', 'Hector Malot');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('42', 'Ayn Rand');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('43', 'Mario Puzo');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('44', 'Jeffrey Archer');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('45', 'Paulo Coelho');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('46', 'R.J.Palacio');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('47', 'A Crazy Mind team');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('48', 'Haruki Murakami');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('49', 'Viktor Emil Frankl');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('50', 'Alexandre Dumas');



INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('91', '31', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('92', '31', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('93', '31', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('94', '32', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('95', '32', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('96', '32', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('97', '33', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('98', '33', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('99', '33', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('100', '34', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('101', '34', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('102', '34', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('103', '35', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('104', '35', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('105', '35', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('106', '36', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('107', '36', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('108', '36', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('109', '37', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('110', '37', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('111', '37', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('112', '38', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('113', '38', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('114', '38', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('115', '39', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('116', '39', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('117', '39', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('118', '40', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('119', '40', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('120', '40', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('121', '41', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('122', '41', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('123', '41', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('124', '42', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('125', '42', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('126', '42', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('127', '43', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('128', '43', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('129', '43', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('130', '44', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('131', '44', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('132', '44', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('133', '45', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('134', '45', 'sẵn có');
INSERT INTO sach (`ID_SACH`, `ID_DAUSACH`, `ATTRIBUTE_22`) VALUES ('135', '45', 'sẵn có');



INSERT INTO chitiet_dausach_tacgia (`ID_DAUSACH`, `ID_TACGIA`) VALUES ('31', '36');
INSERT INTO chitiet_dausach_tacgia (`ID_DAUSACH`, `ID_TACGIA`) VALUES ('32', '37');
INSERT INTO chitiet_dausach_tacgia (`ID_DAUSACH`, `ID_TACGIA`) VALUES ('33', '38');
INSERT INTO chitiet_dausach_tacgia (`ID_DAUSACH`, `ID_TACGIA`) VALUES ('34', '39');
INSERT INTO chitiet_dausach_tacgia (`ID_DAUSACH`, `ID_TACGIA`) VALUES ('35', '40');
INSERT INTO chitiet_dausach_tacgia (`ID_DAUSACH`, `ID_TACGIA`) VALUES ('36', '41');
INSERT INTO chitiet_dausach_tacgia (`ID_DAUSACH`, `ID_TACGIA`) VALUES ('37', '42');
INSERT INTO chitiet_dausach_tacgia (`ID_DAUSACH`, `ID_TACGIA`) VALUES ('38', '43');
INSERT INTO chitiet_dausach_tacgia (`ID_DAUSACH`, `ID_TACGIA`) VALUES ('39', '44');
INSERT INTO chitiet_dausach_tacgia (`ID_DAUSACH`, `ID_TACGIA`) VALUES ('40', '45');
INSERT INTO chitiet_dausach_tacgia (`ID_DAUSACH`, `ID_TACGIA`) VALUES ('41', '46');
INSERT INTO chitiet_dausach_tacgia (`ID_DAUSACH`, `ID_TACGIA`) VALUES ('42', '47');
INSERT INTO chitiet_dausach_tacgia (`ID_DAUSACH`, `ID_TACGIA`) VALUES ('43', '48');
INSERT INTO chitiet_dausach_tacgia (`ID_DAUSACH`, `ID_TACGIA`) VALUES ('44', '49');
INSERT INTO chitiet_dausach_tacgia (`ID_DAUSACH`, `ID_TACGIA`) VALUES ('45', '50');