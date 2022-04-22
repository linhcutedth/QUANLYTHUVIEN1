/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     4/21/2022 10:26:29 AM                        */
/*==============================================================*/


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
   ID_DAUSACH           int not null,
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
   ID_PMS               int not null,
   ID_DG                int not null,
   NGMUON               date,
   primary key (ID_PMS)
);

/*==============================================================*/
/* Table: PHIEUTHUTIENPHAT                                      */
/*==============================================================*/
create table PHIEUTHUTIENPHAT
(
   ID_PHIEUTHU          int not null,
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
/* Index: THUOC_FK                                              */
/*==============================================================*/
create index THUOC_FK on PHIEUTRASACH
(
   
);

/*==============================================================*/
/* Table: SACH                                                  */
/*==============================================================*/
create table SACH
(
   ID_SACH              int not null,
   ID_DAUSACH           int not null,
   ATTRIBUTE_22         varchar(20),
   primary key (ID_SACH)
);

/*==============================================================*/
/* Table: TACGIA                                                */
/*==============================================================*/
create table TACGIA
(
   ID_TACGIA            int not null,
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
   ID_DG                int not null,
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
   ID_THELOAI           int not null,
   TENTHELOAI           varchar(100),
   primary key (ID_THELOAI)
);

alter table CHITIETTACGIA add constraint FK_CHITIETTACGIA foreign key (ID_DAUSACH)
      references DAUSACH (ID_DAUSACH);

alter table CHITIETTACGIA add constraint FK_CHITIETTACGIA2 foreign key (ID_TACGIA)
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

