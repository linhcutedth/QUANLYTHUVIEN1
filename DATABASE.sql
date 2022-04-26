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
