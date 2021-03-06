/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     4/21/2022 10:26:29 AM                        */
/*==============================================================*/
drop database QLTV;
create database QLTV;
use QLTV;

CREATE TABLE `roleclaims` (
  `Id` int(11) NOT NULL primary key ,
  `RoleId` varchar(450) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `roles` (
  `Id` varchar(450) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` varchar(256) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `userclaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `userlogins` (
  `LoginProvider` varchar(127) NOT NULL,
  `ProviderKey` varchar(127) NOT NULL,
  `ProviderDisplayName` longtext DEFAULT NULL,
  `UserId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `userroles` (
  `UserId` varchar(127) NOT NULL,
  `RoleId` varchar(127) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `usertokens` (
  `UserId` varchar(127) NOT NULL,
  `LoginProvider` varchar(127) NOT NULL,
  `Name` varchar(127) NOT NULL,
  `Value` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `users` (
  `Id` varchar(255) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
	FullName 			varchar(100) null,
	Birthday            datetime(6) null,
    GIOITINH 			char(5),
	Address              varchar(100) null,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext DEFAULT NULL,
  `SecurityStamp` longtext DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  `PhoneNumber` longtext DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `Photo` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


-- Indexes for table `aspnetroles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Indexes for table `aspnetuserclaims`
--
ALTER TABLE `userclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetUserClaims_UserId` (`UserId`);

--
-- Indexes for table `aspnetuserlogins`
--
ALTER TABLE `userlogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_AspNetUserLogins_UserId` (`UserId`);

--
-- Indexes for table `aspnetuserroles`
--
ALTER TABLE `userroles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_AspNetUserRoles_RoleId` (`RoleId`);

--
-- Indexes for table `aspnetusers`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `EmailIndex` (`NormalizedEmail`);
  
-- Indexes for table `aspnetusertokens`
--
ALTER TABLE `usertokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);
  
--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `aspnetroleclaims`
--
ALTER TABLE `roleclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `aspnetuserclaims`
--
ALTER TABLE `userclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
  
  
  --
-- Constraints for table `aspnetroleclaims`
--
ALTER TABLE `roleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `roles` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserclaims`
--
ALTER TABLE `userclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserlogins`
--
ALTER TABLE `userlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserroles`
--
ALTER TABLE `userroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `roles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetusertokens`
--
ALTER TABLE `usertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE;

--------------------------------------------
drop table if exists CHITIET_DAUSACH_TACGIA;

drop table if exists CHITIET_PMS;

drop table if exists CHITIET_PTS;

drop table if exists DAUSACH;

drop table if exists PHIEUMUONSACH;

drop table if exists PHIEUTHUTIENPHAT;

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
   SONGMUON             int,
   TIENPHAT             int,
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
   ID_PTS               int AUTO_INCREMENT not null,
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
   TINHTRANG 		varchar(20),
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

insert into thedocgia values (1,'Nguy???n Th??? ??i Linh','Sinh Vi??n',str_to_date('31/5/2001','%d/%m/%Y'),'KTX Khu A, ??HQG','ntalinh@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'C??n h???n');
insert into thedocgia values (2,'Nguy???n Th??? H???ng H???i','Sinh Vi??n',str_to_date('2/12/2001','%d/%m/%Y'),'KTX Khu A, ??HQG','nthhai@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'C??n h???n');
insert into thedocgia values (3,'Nguy???n Nh???t Minh','Sinh Vi??n',str_to_date('25/7/2001','%d/%m/%Y'),'KTX Khu A, ??HQG','nnminh@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'C??n h???n');
insert into thedocgia values (4,'B??i B??ch Ch??m','Sinh Vi??n',str_to_date('20/11/2001','%d/%m/%Y'),'KTX Khu A, ??HQG','bbcham@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'C??n h???n');
insert into thedocgia values (5,'V?? Quang Huy','Sinh Vi??n',str_to_date('5/8/2001','%d/%m/%Y'),'KTX Khu A, ??HQG','vqhuy@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'C??n h???n');
insert into thedocgia values (6,'Nguy???n V?? V??n ?????c','Sinh Vi??n',str_to_date('20/6/2001','%d/%m/%Y'),'KTX Khu A, ??HQG','nvvduc@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'C??n h???n');
insert into thedocgia values (7,'L?? Mai Duy Kh??nh','Sinh Vi??n',str_to_date('4/5/2001','%d/%m/%Y'),'KTX Khu A, ??HQG','lmdkhanh@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'C??n h???n');
insert into thedocgia values (8,'Nguy???n Ng???c Ch??u Pha','Sinh Vi??n',str_to_date('1/6/2001','%d/%m/%Y'),'KTX Khu A, ??HQG','nncpha@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'C??n h???n');
insert into thedocgia values (9,'Ho??ng Ng???c Th???o Quy??n','Sinh Vi??n',str_to_date('21/4/2001','%d/%m/%Y'),'KTX Khu A, ??HQG','hntquyen@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'C??n h???n');
insert into thedocgia values (10,'Nguy???n L?? Nguy??n Khang','Sinh Vi??n',str_to_date('1/7/2001','%d/%m/%Y'),'KTX Khu A, ??HQG','nlnkhang@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'C??n h???n');
insert into thedocgia values (11,'Ph???m Nh?? Long','Sinh Vi??n',str_to_date('21/4/2001','%d/%m/%Y'),'KTX Khu A, ??HQG','pnlong@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'C??n h???n');
insert into thedocgia values (12,'Ng?? T?????ng Vy','Sinh Vi??n',str_to_date('1/8/2001','%d/%m/%Y'),'KTX Khu A, ??HQG','ntvy@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'C??n h???n');
insert into thedocgia values (13,'Ph???m ????ng Khoa','Sinh Vi??n',str_to_date('20/11/2001','%d/%m/%Y'),'KTX Khu A, ??HQG','pdkhoa@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'C??n h???n');
insert into thedocgia values (14,'Nguy???n V??n Ch??','Gi???ng Vi??n',str_to_date('23/1/1992','%d/%m/%Y'),'KTX Khu A, ??HQG','nvchi@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'C??n h???n');
insert into thedocgia values (15,'L???c Th??? T????i','Gi???ng Vi??n',str_to_date('25/2/1991','%d/%m/%Y'),'KTX Khu A, ??HQG','lttuoi@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'C??n h???n');
insert into thedocgia values (16,'Hu???nh Duy T??n','Gi???ng Vi??n',str_to_date('23/12/1993','%d/%m/%Y'),'KTX Khu A, ??HQG','hdtan@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'C??n h???n');
insert into thedocgia values (17,'Ph???m H???ng Ph?????c','Gi???ng Vi??n',str_to_date('25/3/1992','%d/%m/%Y'),'KTX Khu A, ??HQG','phphuoc@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'C??n h???n');
insert into thedocgia values (18,'??o??n Th??y Trang','Gi???ng Vi??n',str_to_date('23/1/1994','%d/%m/%Y'),'KTX Khu A, ??HQG','dttrang@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'C??n h???n');
insert into thedocgia values (19,'Nguy???n Th??? Nh??n','Gi???ng Vi??n',str_to_date('25/6/1993','%d/%m/%Y'),'KTX Khu A, ??HQG','ntnhan@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'C??n h???n');
insert into thedocgia values (20,'Nguy???n Th??? H???ng','Gi???ng Vi??n',str_to_date('23/1/1995','%d/%m/%Y'),'KTX Khu A, ??HQG','nthong@gmail.com',str_to_date('26/4/2022','%d/%m/%Y'),'C??n h???n');

-- INSERT Th??? lo???i
INSERT INTO theloai VALUES ('1', 'S??ch tham kh???o');
INSERT INTO theloai VALUES (2, 'S??ch ng??n ng???');
INSERT INTO theloai (`ID_THELOAI`, `TENTHELOAI`) VALUES ('3', 'S??ch ti???u thuy???t');


-- INSERT ?????U S??CH

INSERT INTO dausach VALUES ('1', '1', 'Chinh Ph???c Luy???n Thi V??o L???p 10 M??n Ti???ng Anh Theo Ch??? ?????', '2020', 'Nh?? Xu???t B???n ?????i H???c Qu???c Gia H?? N???i', '2022-04-25', '102900', '3', '3', '0', '/HinhAnh/1.jpg');
INSERT INTO dausach VALUES ('2', '1', 'T??? H???c ?????t Ph?? - K?? N??ng Vi???t L???i C??u Ti???ng Anh', '2017', 'Nh?? Xu???t B???n ?????i H???c Qu???c Gia H?? N???i', '2022-04-25', '89000', '3', '3', '0', '/HinhAnh/2.jpg');
INSERT INTO dausach VALUES ('3', '1', 'Luy???n Gi???i B??? ????? B???i D?????ng H???c Sinh Gi???i Ti???ng Anh L???p 9', '2017', 'Nh?? Xu???t B???n ?????i H???c Qu???c Gia H?? N???i', '2022-04-25', '64100', '3', '3', '0', '/HinhAnh/3.jpg');
INSERT INTO dausach VALUES ('4', '1', 'T??ng t???c luy???n ????? thi ????nh gi?? n??ng l???c', '2021', 'Nh?? Xu???t B???n ?????i H???c Qu???c Gia H?? N???i', '2022-04-25', '180000', '3', '3', '0', '/HinhAnh/4.png');
INSERT INTO dausach VALUES ('5', '1', 'C??ng Ph?? To??n 3', '2018', 'Nh?? Xu???t B???n ?????i H???c Qu???c Gia H?? N???i', '2022-04-25', '175000', '3', '3', '0', '/HinhAnh/5.jpg');
INSERT INTO dausach VALUES ('6', '1', 'C??ng Ph?? K??? Thu???t Casio', '2018', 'Nh?? Xu???t B???n ?????i H???c Qu???c Gia H?? N???i', '2022-04-25', '229000', '3', '3', '0', '/HinhAnh/6.jpg');
INSERT INTO dausach VALUES ('7', '1', '500 b??i luy???n ?????c Hi???u ??? ?????c ??i???n Ti???ng Anh', '2018', 'Nh?? Xu???t B???n H???ng ?????c', '2022-04-25', '169000', '3', '3', '0', '/HinhAnh/7.jpg');
INSERT INTO dausach VALUES ('8', '1', 'Chinh Ph???c C???m ?????ng T??? Ti???ng Anh', '2018', 'Nh?? Xu???t B???n ?????i H???c S?? Ph???m', '2022-04-25', '52000', '3', '3', '0', '/HinhAnh/8.jpg');
INSERT INTO dausach VALUES ('9', '1', 'B???i D?????ng H???c Sinh Gi???i Sinh H???c 11', '2019', 'Nh?? Xu???t B???n ?????i H???c Qu???c Gia H?? N???i', '2022-04-25', '43200', '3', '3', '0', '/HinhAnh/9.jpg');
INSERT INTO dausach VALUES ('10', '1', 'T??? H???c To??n Di???n H??a H???c - T??? C?? B???n ?????n N??ng Cao L???p 9', '2020', 'Nh?? Xu???t B???n ?????i H???c Qu???c Gia H?? N???i', '2022-04-25', '64100', '3', '3', '0', '/HinhAnh/10.jpg');
INSERT INTO dausach VALUES ('11', '1', 'Luy???n Thi V??o L???p 10 M??n Ng??? V??n Chuy??n ????? Ngh??? Lu???n V??n H???c 2019', '2019', 'Nh?? Xu???t B???n ?????i H???c S?? Ph???m', '2022-04-25', '135000', '3', '3', '0', '/HinhAnh/11.jpg');
INSERT INTO dausach VALUES ('12', '1', 'All In One - H??a H???c Trung H???c Ph??? Th??ng', '2019', 'Nh?? Xu???t B???n H???ng ?????c', '2022-04-25', '31640', '3', '3', '0', '/HinhAnh/12.jpg');
INSERT INTO dausach VALUES ('13', '1', 'Ti???t L??? B?? Quy???t 3 B?????c ?????t ??i???m 8+ Ng??? V??n', '2020', 'Nh?? Xu???t B???n ?????i H???c Qu???c Gia H?? N???i', '2022-04-25', '154000', '3', '3', '0', '/HinhAnh/13.jpg');
INSERT INTO dausach VALUES ('14', '1', 'Mega 2021 - Si??u Luy???n ????? 9 + THPT Qu???c Gia 2021 - V??n H???c', '2021', 'Nh?? Xu???t B???n ?????i H???c Qu???c Gia H?? N???i', '2022-04-25', '82500', '3', '3', '0', '/HinhAnh/14.jpg');
INSERT INTO dausach VALUES ('15', '1', 'B??? ????? minh h???a 2022 - S??ch ID 50 ????? thi tr???c nghi???m m??n V???t L??', '2021', 'Nh?? Xu???t B???n H???ng ?????c', '2022-04-25', '109000', '3', '3', '0', '/HinhAnh/15.jpg');
INSERT INTO DAUSACH(ID_DAUSACH,ID_THELOAI,TENSACH,NAMXUATBAN,NHAXUATBAN,NGNHAP,TRIGIA,TONGSO,SANCO,DANGCHOMUON,HINHANH) VALUES (16,2,'C???m Nang C???u Tr??c Ti???ng Anh',2016,'Nh?? Xu???t B???n ?????i H???c Qu???c Gia H?? N???i','2022-04-26',264000,3,3,0,'/HinhAnh/16.jpg');
INSERT INTO DAUSACH(ID_DAUSACH,ID_THELOAI,TENSACH,NAMXUATBAN,NHAXUATBAN,NGNHAP,TRIGIA,TONGSO,SANCO,DANGCHOMUON,HINHANH) VALUES (17,2,'Ng??? Ph??p Ti???ng Anh',2018,'Nh?? Xu???t B???n ???? N???ng','2022-04-26',280000,3,3,0,'/HinhAnh/16.jpg');
INSERT INTO DAUSACH(ID_DAUSACH,ID_THELOAI,TENSACH,NAMXUATBAN,NHAXUATBAN,NGNHAP,TRIGIA,TONGSO,SANCO,DANGCHOMUON,HINHANH) VALUES (18,2,'S??ch luy???n thi B1 Vstep 4 k??? n??ng',2019,'Nh?? Xu???t B???n ?????i H???c Qu???c Gia H?? N???i','2022-04-26',290000,3,3,0,'/HinhAnh/18.jpg');
INSERT INTO DAUSACH(ID_DAUSACH,ID_THELOAI,TENSACH,NAMXUATBAN,NHAXUATBAN,NGNHAP,TRIGIA,TONGSO,SANCO,DANGCHOMUON,HINHANH) VALUES (19,2,'Hackers Ielts: Writing',2020,'Alphabooks','2022-04-26',143000,3,3,0,'/HinhAnh/19.jpg');
INSERT INTO DAUSACH(ID_DAUSACH,ID_THELOAI,TENSACH,NAMXUATBAN,NHAXUATBAN,NGNHAP,TRIGIA,TONGSO,SANCO,DANGCHOMUON,HINHANH) VALUES (20,2,'Toeic Vocab Basic',2013,'Nh?? Xu???t B???n D??n Tr??','2022-04-26',289000,3,3,0,'/HinhAnh/20.jpg');
INSERT INTO DAUSACH(ID_DAUSACH,ID_THELOAI,TENSACH,NAMXUATBAN,NHAXUATBAN,NGNHAP,TRIGIA,TONGSO,SANCO,DANGCHOMUON,HINHANH) VALUES (21,2,'Hackers Toeic Vocabulary',2017,'Nh?? Xu???t B???n D??n Tr??','2022-04-26',255000,3,3,0,'/HinhAnh/21.jpg');
INSERT INTO DAUSACH(ID_DAUSACH,ID_THELOAI,TENSACH,NAMXUATBAN,NHAXUATBAN,NGNHAP,TRIGIA,TONGSO,SANCO,DANGCHOMUON,HINHANH) VALUES (22,2,'Barron''s Essential Words For The Toeic',2011,'First News - Tr?? Vi???t','2022-04-26',210000,3,3,0,'/HinhAnh/22.jpg');
INSERT INTO DAUSACH(ID_DAUSACH,ID_THELOAI,TENSACH,NAMXUATBAN,NHAXUATBAN,NGNHAP,TRIGIA,TONGSO,SANCO,DANGCHOMUON,HINHANH) VALUES (23,2,'Luy???n Thi TOEIC C???p T???c Trong 30 Ng??y - Plan B - Nghe Hi???u',2015,'Nh?? Xu???t B???n ?????i H???c Qu???c Gia H?? N???i','2022-04-26',227000,3,3,0,'/HinhAnh/23.jpg');
INSERT INTO DAUSACH(ID_DAUSACH,ID_THELOAI,TENSACH,NAMXUATBAN,NHAXUATBAN,NGNHAP,TRIGIA,TONGSO,SANCO,DANGCHOMUON,HINHANH) VALUES (24,2,'Tomato Toeic Compact Reading',2015,'Nh?? Xu???t B???n T???ng h???p TP.HCM','2022-04-26',265000,3,3,0,'/HinhAnh/24.jpg');
INSERT INTO DAUSACH(ID_DAUSACH,ID_THELOAI,TENSACH,NAMXUATBAN,NHAXUATBAN,NGNHAP,TRIGIA,TONGSO,SANCO,DANGCHOMUON,HINHANH) VALUES (25,2,'S???ng S??t N??i C??ng S??? English Business Writing',2017,'Nh?? Xu???t B???n D??n Tr??','2022-04-26',165000,3,3,0,'/HinhAnh/25.jpg');
INSERT INTO DAUSACH(ID_DAUSACH,ID_THELOAI,TENSACH,NAMXUATBAN,NHAXUATBAN,NGNHAP,TRIGIA,TONGSO,SANCO,DANGCHOMUON,HINHANH) VALUES (26,2,'YBM Actual Toeic Tests RC 1000 - Vol 1',2016,'Nh?? Xu???t B???n D??n Tr??','2022-04-26',287000,3,3,0,'/HinhAnh/26.jpg');
INSERT INTO DAUSACH(ID_DAUSACH,ID_THELOAI,TENSACH,NAMXUATBAN,NHAXUATBAN,NGNHAP,TRIGIA,TONGSO,SANCO,DANGCHOMUON,HINHANH) VALUES (27,2,'Perfect IELTS Listeng Dictation Vol.2',2012,'Nh?? Xu???t B???n Th??? Gi???i','2022-04-26',164000,3,3,0,'/HinhAnh/27.jpg');
INSERT INTO DAUSACH(ID_DAUSACH,ID_THELOAI,TENSACH,NAMXUATBAN,NHAXUATBAN,NGNHAP,TRIGIA,TONGSO,SANCO,DANGCHOMUON,HINHANH) VALUES (28,2,'Hackers Toeic Start Listening',2015,'First News - Tr?? Vi???t','2022-04-26',291000,3,3,0,'/HinhAnh/28.jpg');
INSERT INTO DAUSACH(ID_DAUSACH,ID_THELOAI,TENSACH,NAMXUATBAN,NHAXUATBAN,NGNHAP,TRIGIA,TONGSO,SANCO,DANGCHOMUON,HINHANH) VALUES (29,2,'Luy???n Thi Toeic 750',2010,'Nh?? Xu???t B???n Khoa H???c X?? H???i','2022-04-26',147000,3,3,0,'/HinhAnh/29.jpg');
INSERT INTO DAUSACH(ID_DAUSACH,ID_THELOAI,TENSACH,NAMXUATBAN,NHAXUATBAN,NGNHAP,TRIGIA,TONGSO,SANCO,DANGCHOMUON,HINHANH) VALUES (30,2,'Cao Th??? IELTS ??u???i Theo Ch??n Ch???m',2010,'Nh?? Xu???t B???n Th??? Gi???i','2022-04-26',104000,3,3,0,'/HinhAnh/30.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('31', '3', 'Lu???t t??m th???c', '2021', 'Nh?? Xu???t B???n D??n Tr??', '2022-04-26', '180439', '3', '3', '0', '/HinhAnh/31.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('32', '3', 'H???i ch???ng E', '2020', 'NXB H???i Nh?? V??n', '2022-04-26', '288500', '3', '3', '0', '/HinhAnh/32.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('33', '3', '??n M???ng M?????i M???t Ch???', '2020', 'Nh?? Xu???t B???n H???i Nh?? V??n', '2022-04-26', '288500', '3', '3', '0', '/HinhAnh/33.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('34', '3', 'N???i bu???n chi???n tranh', '2017', 'NXB Tr???', '2022-04-26', '115000', '3', '3', '0', '/HinhAnh/34.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('35', '3', 'Nh???ng ng??y th?? ???u', '2021', 'Nh?? Xu???t B???n H???i Nh?? V??n', '2022-04-26', '54800', '3', '3', '0', '/HinhAnh/35.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('36', '3', 'Kh??ng gia ????nh', '2022', 'Nh?? Xu???t B???n M??? Thu???t', '2022-04-26', '84400', '3', '3', '0', '/HinhAnh/36.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('37', '3', 'Su???i ngu???n', '2018', 'NXB Tr???', '2022-04-26', '230800', '3', '3', '0', '/HinhAnh/37.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('38', '3', 'B??? gi??', '2016', 'Nh?? Xu???t B???n V??n H???c', '2022-04-26', '63923', '3', '3', '0', '/HinhAnh/38.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('39', '3', 'Hai s??? ph???n', '2018', 'Nh?? Xu???t B???n V??n H???c', '2022-04-26', '111000', '3', '3', '0', '/HinhAnh/39.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('40', '3', 'Nh?? gi??? kim', '2020', 'Nh?? Xu???t B???n H?? N???i', '2022-04-26', '53544', '3', '3', '0', '/HinhAnh/40.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('41', '3', '??i???u k?? di???u ', '2019', 'NXB Tr???', '2022-04-26', '118400', '3', '3', '0', '/HinhAnh/41.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('42', '3', 'Nh???ng ????m kh??ng ng??? nh???ng ng??y ch???m tr??i', '2021', 'Nh?? Xu???t B???n V??n H???c', '2022-04-26', '54960 ', '3', '3', '0', '/HinhAnh/42.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('43', '3', 'R???ng Nauy', '2021', 'Nh?? Xu???t B???n H???i Nh?? V??n', '2022-04-26', '109500', '3', '3', '0', '/HinhAnh/43.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('44', '3', '??i t??m l??? s???ng', '2019', 'NXB T???ng H???p TPHCM', '2022-04-26', '62400', '3', '3', '0', '/HinhAnh/44.jpg');
INSERT INTO dausach (`ID_DAUSACH`, `ID_THELOAI`, `TENSACH`, `NAMXUATBAN`, `NHAXUATBAN`, `NGNHAP`, `TRIGIA`, `TONGSO`, `SANCO`, `DANGCHOMUON`, `HINHANH`) VALUES ('45', '3', 'Tr?? hoa n???', '2015', 'NXB V??n H???c', '2022-04-26', '55800', '3', '3', '0', '/HinhAnh/45.jpg');
INSERT INTO dausach VALUES (46,	3,'Chuy???n Con M??o D???y H???i ??u Bay',2019,'Nh?? xu???t b???n H???i nh?? v??n',str_to_date('21/4/2022','%d/%m/%Y'),49000,3,3,0,'/HinhAnh/46.jpg');
INSERT INTO dausach VALUES (47,	3,'C?? Hai Con M??o Ng???i B??n C???a S???',2012,'Nh?? xu???t b???n Tr???',str_to_date('21/4/2022','%d/%m/%Y'),85000,3,	3,0,'/HinhAnh/47.jpg');
INSERT INTO dausach VALUES (48,	3,'L??m b???n v???i b???u tr???i',2019,'Nh?? xu???t b???n Tr???',str_to_date('21/4/2022','%d/%m/%Y'),110000,3,3,0,'/HinhAnh/48.jpg');
INSERT INTO dausach VALUES (49,	3,'Cho t??i xin m???t ve ??i tu???i th??',2019,'Nh?? xu???t b???n Tr???',str_to_date('21/4/2022','%d/%m/%Y'),80000,3,3,0,'/HinhAnh/49.jpg');
INSERT INTO dausach VALUES (50,	3,'L?????c s??? th???i gian',2018,'Nh?? xu???t b???n Tr???',str_to_date('21/4/2022','%d/%m/%Y'),90000,3,3,0,'/HinhAnh/50.jpg');
INSERT INTO dausach VALUES (51,	3,'L?????c s??? v???n v???t',2018,'Nh?? xu???t b???n Khoa H???c H?? N???i',str_to_date('21/4/2022','%d/%m/%Y'),245000,3,3,0,'/HinhAnh/51.jpg');
INSERT INTO dausach VALUES (52,	3,'Einstein ??? Cu???c ?????i V?? V?? Tr???',2017,'Nh?? xu???t b???n Th??? gi???i',	str_to_date('21/4/2022','%d/%m/%Y'),277000,3,3,0,'/HinhAnh/52.jpg');
INSERT INTO dausach VALUES (53,	3,'T??? B??o G???c: Kh??m Ph?? C??ng Nh?? Khoa H???c',2018,'Nh?? xu???t b???n D??n Tr??',	str_to_date('21/4/2022','%d/%m/%Y'),133000,3,3,0,'/HinhAnh/53.jpg');
INSERT INTO dausach VALUES (54,	3,'GEN: L???ch S??? V?? T????ng Lai C???a Nh??n Lo???i',2018,'Nh?? xu???t b???n D??n Tr??',str_to_date('21/4/2022','%d/%m/%Y'),233000,3,3,0,'/HinhAnh/54.jpg');
INSERT INTO dausach VALUES (55,	3,'Ngu???n G???c C??c Lo??i',2015,'Nh?? xu???t b???n Th??? gi???i',str_to_date('21/4/2022','%d/%m/%Y'),155000,3,3,0,'/HinhAnh/55.jpg');
INSERT INTO dausach VALUES (56,	3,'S??ng, Vi Tr??ng V?? Th??p',2019,'Nh?? xu???t b???n Th??? gi???i',str_to_date('21/4/2022','%d/%m/%Y'),249000,3,3,0,'/HinhAnh/56.jpg');
INSERT INTO dausach VALUES (57,	3,'Ch??? Ki???n Th???c Ng??? V??n 9??- ph???n 1',2018,'Nh?? xu???t b???n ?????i H???c Qu???c Gia H?? N???i',str_to_date('21/4/2022','%d/%m/%Y'),102000,3,3,0,'/HinhAnh/57.jpg');
INSERT INTO dausach VALUES (58,	3,'Chi???n th???ng k?? thi 9 v??o 10 chuy??n m??n V???t L?? - t???p 1',2018,'Nh?? xu???t b???n ?????i H???c Qu???c Gia H?? N???i',str_to_date('21/4/2022','%d/%m/%Y'),189000,3,3,0,'/HinhAnh/58.jpg');
INSERT INTO dausach VALUES (59,	1,'Luy???n Chuy??n s??u ng??? ph??p v?? b??i t???p Ti???ng Anh 7 - t???p 1',2018,'Nh?? xu???t b???n ?????i H???c Qu???c Gia H?? N???i',str_to_date('21/4/2022','%d/%m/%Y'),60000,3,3,0,'/HinhAnh/59.jpg');
INSERT INTO dausach VALUES (60,	1,'Luy???n Chuy??n S??u  ng??? ph??p v?? b??i t???p Ti???ng Anh 7 - t???p 2',2018,'Nh?? xu???t b???n ?????i H???c Qu???c Gia H?? N???i',str_to_date('21/4/2022','%d/%m/%Y'),69000,3,3,0,'/HinhAnh/60.jpg');

-- INSERT T??C GI???

INSERT INTO tacgia VALUES ('1', 'D????ng H????ng');
INSERT INTO tacgia VALUES ('2', 'V??n Tr???nh Qu???nh An');
INSERT INTO tacgia VALUES ('3', 'Qu???c T??');
INSERT INTO tacgia VALUES ('4', 'Tr???nh Nguy??n');
INSERT INTO tacgia VALUES ('5', 'B???o Tr??n');
INSERT INTO tacgia VALUES ('6', 'Anh Trung');
INSERT INTO tacgia VALUES ('7', 'Minh T??m');
INSERT INTO tacgia VALUES ('8', 'Ho??i ?????c');
INSERT INTO tacgia VALUES ('9', 'Qu???c H????ng');
INSERT INTO tacgia VALUES ('10', 'Minh ????ng');
INSERT INTO tacgia VALUES ('11', 'Ng???c Huy???n LB');
INSERT INTO tacgia VALUES ('12', 'Nguy???n Ng???c Nam');
INSERT INTO tacgia VALUES ('13', 'Trang Anh');
INSERT INTO tacgia VALUES ('14', 'Phan Kh???c Ngh???');
INSERT INTO tacgia VALUES ('15', 'Tr???n M???nh H??ng');
INSERT INTO TACGIA(ID_TACGIA,TENTG) VALUES ('16','Nguy???n Thanh Loan');
INSERT INTO TACGIA(ID_TACGIA,TENTG) VALUES ('17','V?? Th??? L?? Vy');
INSERT INTO TACGIA(ID_TACGIA,TENTG) VALUES ('18','Vi???n ng??n ng??? Hackers');
INSERT INTO TACGIA(ID_TACGIA,TENTG) VALUES ('19','Siwonschool English Lab');
INSERT INTO TACGIA(ID_TACGIA,TENTG) VALUES ('20','David Cho');
INSERT INTO TACGIA(ID_TACGIA,TENTG) VALUES ('21','Anh L?? TOEIC');
INSERT INTO TACGIA(ID_TACGIA,TENTG) VALUES ('22','John Boswell');
INSERT INTO TACGIA(ID_TACGIA,TENTG) VALUES ('23','Andrew E. Bennette');
INSERT INTO TACGIA(ID_TACGIA,TENTG) VALUES ('24','Kim Hakin');
INSERT INTO TACGIA(ID_TACGIA,TENTG) VALUES ('25','Lee Eungyu');
INSERT INTO TACGIA(ID_TACGIA,TENTG) VALUES ('26','Kim Jiyeon');
INSERT INTO TACGIA(ID_TACGIA,TENTG) VALUES ('27','Juliana Jiyoon Lee');
INSERT INTO TACGIA(ID_TACGIA,TENTG) VALUES ('28','YBM');
INSERT INTO TACGIA(ID_TACGIA,TENTG) VALUES ('29','William Jang');
INSERT INTO TACGIA(ID_TACGIA,TENTG) VALUES ('30','Jo Gang');
INSERT INTO TACGIA(ID_TACGIA,TENTG) VALUES ('31','L?? Minh H??');
INSERT INTO TACGIA(ID_TACGIA,TENTG) VALUES ('32','?????ng Tr???n T??ng');
INSERT INTO TACGIA(ID_TACGIA,TENTG) VALUES ('33','?????ng B??ch Ph????ng');
INSERT INTO TACGIA(ID_TACGIA,TENTG) VALUES ('34','L?? Minh H??');
INSERT INTO TACGIA(ID_TACGIA,TENTG) VALUES ('35','Karen Kovacs');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('36', 'Ng?? Sa Th???ch');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('37', 'Franck Thilliez');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('38', 'Higashino Keigo');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('39', 'B???o Ninh');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('40', 'Nguy??n H???ng');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('41', 'Hector Malot');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('42', 'Ayn Rand');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('43', 'Mario Puzo');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('44', 'Jeffrey Archer');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('45', 'Paulo Coelho');
INSERT INTO tacgia VALUES (46,'Luis Sep??lveda');
INSERT INTO tacgia VALUES (47,'Nguy???n Nh???t ??nh');
INSERT INTO tacgia VALUES (48,'Stephen Hawking');
INSERT INTO tacgia VALUES (49,'William McGuire ???Bill??? Bryson');
INSERT INTO tacgia VALUES (50,'Walter Isaacson');
INSERT INTO tacgia VALUES (51,'Paul Knoepflef');
INSERT INTO tacgia VALUES (52,'Siddhartha Mukerjee');
INSERT INTO tacgia VALUES (53,'Charles Robert Darwin');
INSERT INTO tacgia VALUES (54,'Jared Diamond');
INSERT INTO tacgia VALUES (55,'Ph???m Chung T??nh');
INSERT INTO tacgia VALUES (56,'Tr???nh Minh Hi???p');
INSERT INTO tacgia VALUES (57,'T???ng Ng???c Huy???n');
INSERT INTO tacgia VALUES (58,'Nguy???n Du');
INSERT INTO tacgia VALUES (59,'T?? Ho??i');
INSERT INTO tacgia VALUES (60,'Nguy???n Tr??i');
INSERT INTO tacgia VALUES ('61', '????o Th??? Ho??ng Ly');
INSERT INTO tacgia VALUES ('62', '????o L????ng H??ng');
INSERT INTO tacgia VALUES ('63', 'Nguy???n Th??nh Hu??n');
INSERT INTO tacgia VALUES ('64', 'Nguy???n Th??? Ng???c');
INSERT INTO tacgia VALUES ('65', 'Ph??ng Th??? Thanh Th??y');
INSERT INTO tacgia VALUES ('66', '??o??n M???nh Linh');
INSERT INTO tacgia VALUES ('67', 'L???i ?????c H???p');
INSERT INTO tacgia VALUES ('68', 'Nguy???n Th??? L????ng');
INSERT INTO TACGIA(ID_TACGIA,TENTG) VALUES ('69','Mai Lan H????ng');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('70', 'A Crazy Mind team');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('71', 'Haruki Murakami');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('72', 'Viktor Emil Frankl');
INSERT INTO tacgia (`ID_TACGIA`, `TENTG`) VALUES ('73', 'Alexandre Dumas');

-- INSERT S??CH

INSERT INTO sach VALUES ('1', '1', 's???n c??');
INSERT INTO sach VALUES ('2', '1', 's???n c??');
INSERT INTO sach VALUES ('3', '1', 's???n c??');
INSERT INTO sach VALUES ('4', '2', 's???n c??');
INSERT INTO sach VALUES ('5', '2', 's???n c??');
INSERT INTO sach VALUES ('6', '2', 's???n c??');
INSERT INTO sach VALUES ('7', '3', 's???n c??');
INSERT INTO sach VALUES ('8', '3', 's???n c??');
INSERT INTO sach VALUES ('9', '3', 's???n c??');
INSERT INTO sach VALUES ('10', '4', 's???n c??');
INSERT INTO sach VALUES ('11', '4', 's???n c??');
INSERT INTO sach VALUES ('12', '4', 's???n c??');
INSERT INTO sach VALUES ('13', '5', 's???n c??');
INSERT INTO sach VALUES ('14', '5', 's???n c??');
INSERT INTO sach VALUES ('15', '5', 's???n c??');
INSERT INTO sach VALUES ('16', '6', 's???n c??');
INSERT INTO sach VALUES ('17', '6', 's???n c??');
INSERT INTO sach VALUES ('18', '6', 's???n c??');
INSERT INTO sach VALUES ('19', '7', 's???n c??');
INSERT INTO sach VALUES ('20', '7', 's???n c??');
INSERT INTO sach VALUES ('21', '7', 's???n c??');
INSERT INTO sach VALUES ('22', '8', 's???n c??');
INSERT INTO sach VALUES ('23', '8', 's???n c??');
INSERT INTO sach VALUES ('24', '8', 's???n c??');
INSERT INTO sach VALUES ('25', '9', 's???n c??');
INSERT INTO sach VALUES ('26', '9', 's???n c??');
INSERT INTO sach VALUES ('27', '9', 's???n c??');
INSERT INTO sach VALUES ('28', '10', 's???n c??');
INSERT INTO sach VALUES ('29', '10', 's???n c??');
INSERT INTO sach VALUES ('30', '10', 's???n c??');
INSERT INTO sach VALUES ('31', '11', 's???n c??');
INSERT INTO sach VALUES ('32', '11', 's???n c??');
INSERT INTO sach VALUES ('33', '11', 's???n c??');
INSERT INTO sach VALUES ('34', '12', 's???n c??');
INSERT INTO sach VALUES ('35', '12', 's???n c??');
INSERT INTO sach VALUES ('36', '12', 's???n c??');
INSERT INTO sach VALUES ('37', '13', 's???n c??');
INSERT INTO sach VALUES ('38', '13', 's???n c??');
INSERT INTO sach VALUES ('39', '13', 's???n c??');
INSERT INTO sach VALUES ('40', '14', 's???n c??');
INSERT INTO sach VALUES ('41', '14', 's???n c??');
INSERT INTO sach VALUES ('42', '14', 's???n c??');
INSERT INTO sach VALUES ('43', '15', 's???n c??');
INSERT INTO sach VALUES ('44', '15', 's???n c??');
INSERT INTO sach VALUES ('45', '15', 's???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (46,15,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (47,15,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (48,15,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (49,16,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (50,16,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (51,16,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (52,17,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (53,17,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (54,17,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (55,18,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (56,18,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (57,18,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (58,19,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (59,19,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (60,19,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (61,20,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (62,20,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (63,20,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (64,21,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (65,21,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (66,21,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (67,22,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (68,22,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (69,22,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (70,23,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (71,23,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (72,23,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (73,24,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (74,24,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (75,24,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (76,25,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (77,25,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (78,25,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (79,26,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (80,26,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (81,26,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (82,27,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (83,27,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (84,27,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (85,28,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (86,28,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (87,28,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (88,29,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (89,29,'s???n c??');
INSERT INTO SACH(ID_SACH,ID_DAUSACH,TINHTRANG) VALUES (90,29,'s???n c??');
INSERT INTO sach VALUES ('91', '31', 's???n c??');
INSERT INTO sach VALUES ('92', '31', 's???n c??');
INSERT INTO sach VALUES ('93', '31', 's???n c??');
INSERT INTO sach VALUES ('94', '32', 's???n c??');
INSERT INTO sach VALUES ('95', '32', 's???n c??');
INSERT INTO sach VALUES ('96', '32', 's???n c??');
INSERT INTO sach VALUES ('97', '33', 's???n c??');
INSERT INTO sach VALUES ('98', '33', 's???n c??');
INSERT INTO sach VALUES ('99', '33', 's???n c??');
INSERT INTO sach VALUES ('100', '34', 's???n c??');
INSERT INTO sach VALUES ('101', '34', 's???n c??');
INSERT INTO sach VALUES ('102', '34', 's???n c??');
INSERT INTO sach VALUES ('103', '35', 's???n c??');
INSERT INTO sach VALUES ('104', '35', 's???n c??');
INSERT INTO sach VALUES ('105', '35', 's???n c??');
INSERT INTO sach VALUES ('106', '36', 's???n c??');
INSERT INTO sach VALUES ('107', '36', 's???n c??');
INSERT INTO sach VALUES ('108', '36', 's???n c??');
INSERT INTO sach VALUES ('109', '37', 's???n c??');
INSERT INTO sach VALUES ('110', '37', 's???n c??');
INSERT INTO sach VALUES ('111', '37', 's???n c??');
INSERT INTO sach VALUES ('112', '38', 's???n c??');
INSERT INTO sach VALUES ('113', '38', 's???n c??');
INSERT INTO sach VALUES ('114', '38', 's???n c??');
INSERT INTO sach VALUES ('115', '39', 's???n c??');
INSERT INTO sach VALUES ('116', '39', 's???n c??');
INSERT INTO sach VALUES ('117', '39', 's???n c??');
INSERT INTO sach VALUES ('118', '40', 's???n c??');
INSERT INTO sach VALUES ('119', '40', 's???n c??');
INSERT INTO sach VALUES ('120', '40', 's???n c??');
INSERT INTO sach VALUES ('121', '41', 's???n c??');
INSERT INTO sach VALUES ('122', '41', 's???n c??');
INSERT INTO sach VALUES ('123', '41', 's???n c??');
INSERT INTO sach VALUES ('124', '42', 's???n c??');
INSERT INTO sach VALUES ('125', '42', 's???n c??');
INSERT INTO sach VALUES ('126', '42', 's???n c??');
INSERT INTO sach VALUES ('127', '43', 's???n c??');
INSERT INTO sach VALUES ('128', '43', 's???n c??');
INSERT INTO sach VALUES ('129', '43', 's???n c??');
INSERT INTO sach VALUES ('130', '44', 's???n c??');
INSERT INTO sach VALUES ('131', '44', 's???n c??');
INSERT INTO sach VALUES ('132', '44', 's???n c??');
INSERT INTO sach VALUES ('133', '45', 's???n c??');
INSERT INTO sach VALUES ('134', '45', 's???n c??');
INSERT INTO sach VALUES ('135', '45', 's???n c??');
INSERT INTO sach VALUES ('136', '46', 's???n c??');
INSERT INTO sach VALUES ('137', '46', 's???n c??');
INSERT INTO sach VALUES ('138', '46', 's???n c??');
INSERT INTO sach VALUES ('139', '47', 's???n c??');
INSERT INTO sach VALUES ('140', '47', 's???n c??');
INSERT INTO sach VALUES ('141', '47', 's???n c??');
INSERT INTO sach VALUES ('142', '48', 's???n c??');
INSERT INTO sach VALUES ('143', '48', 's???n c??');
INSERT INTO sach VALUES ('144', '48', 's???n c??');
INSERT INTO sach VALUES ('145', '49', 's???n c??');
INSERT INTO sach VALUES ('146', '49', 's???n c??');
INSERT INTO sach VALUES ('147', '49', 's???n c??');
INSERT INTO sach VALUES ('148', '50', 's???n c??');
INSERT INTO sach VALUES ('149', '50', 's???n c??');
INSERT INTO sach VALUES ('150', '50', 's???n c??');
INSERT INTO sach VALUES ('151', '51', 's???n c??');
INSERT INTO sach VALUES ('152', '51', 's???n c??');
INSERT INTO sach VALUES ('153', '51', 's???n c??');
INSERT INTO sach VALUES ('154', '52', 's???n c??');
INSERT INTO sach VALUES ('155', '52', 's???n c??');
INSERT INTO sach VALUES ('156', '52', 's???n c??');
INSERT INTO sach VALUES ('157', '53', 's???n c??');
INSERT INTO sach VALUES ('158', '53', 's???n c??');
INSERT INTO sach VALUES ('159', '53', 's???n c??');
INSERT INTO sach VALUES ('160', '54', 's???n c??');
INSERT INTO sach VALUES ('161', '54', 's???n c??');
INSERT INTO sach VALUES ('162', '54', 's???n c??');
INSERT INTO sach VALUES ('163', '55', 's???n c??');
INSERT INTO sach VALUES ('164', '55', 's???n c??');
INSERT INTO sach VALUES ('165', '55', 's???n c??');
INSERT INTO sach VALUES ('166', '56', 's???n c??');
INSERT INTO sach VALUES ('167', '56', 's???n c??');
INSERT INTO sach VALUES ('168', '56', 's???n c??');
INSERT INTO sach VALUES ('169', '57', 's???n c??');
INSERT INTO sach VALUES ('170', '57', 's???n c??');
INSERT INTO sach VALUES ('171', '57', 's???n c??');
INSERT INTO sach VALUES ('172', '58', 's???n c??');
INSERT INTO sach VALUES ('173', '58', 's???n c??');
INSERT INTO sach VALUES ('174', '58', 's???n c??');
INSERT INTO sach VALUES ('175', '59', 's???n c??');
INSERT INTO sach VALUES ('176', '59', 's???n c??');
INSERT INTO sach VALUES ('177', '59', 's???n c??');
INSERT INTO sach VALUES ('178', '60', 's???n c??');
INSERT INTO sach VALUES ('179', '60', 's???n c??');
INSERT INTO sach VALUES ('180', '60', 's???n c??');



-- insert chitiet_dausach_tacgia

INSERT INTO chitiet_dausach_tacgia VALUES ('1', '1');
INSERT INTO chitiet_dausach_tacgia VALUES ('2', '1');
INSERT INTO chitiet_dausach_tacgia VALUES ('3', '1');
INSERT INTO chitiet_dausach_tacgia VALUES ('4', '2');
INSERT INTO chitiet_dausach_tacgia VALUES ('4', '3');
INSERT INTO chitiet_dausach_tacgia VALUES ('4', '4');
INSERT INTO chitiet_dausach_tacgia VALUES ('4', '5');
INSERT INTO chitiet_dausach_tacgia VALUES ('4', '6');
INSERT INTO chitiet_dausach_tacgia VALUES ('4', '7');
INSERT INTO chitiet_dausach_tacgia VALUES ('4', '8');
INSERT INTO chitiet_dausach_tacgia VALUES ('4', '9');
INSERT INTO chitiet_dausach_tacgia VALUES ('4', '10');
INSERT INTO chitiet_dausach_tacgia VALUES ('5', '11');
INSERT INTO chitiet_dausach_tacgia VALUES ('6', '11');
INSERT INTO chitiet_dausach_tacgia VALUES ('6', '12');
INSERT INTO chitiet_dausach_tacgia VALUES ('7', '13');
INSERT INTO chitiet_dausach_tacgia VALUES ('8', '13');
INSERT INTO chitiet_dausach_tacgia VALUES ('9', '14');
INSERT INTO chitiet_dausach_tacgia VALUES ('9', '15');
INSERT INTO chitiet_dausach_tacgia VALUES ('10', '61');
INSERT INTO chitiet_dausach_tacgia VALUES ('10', '62');
INSERT INTO chitiet_dausach_tacgia VALUES ('11', '63');
INSERT INTO chitiet_dausach_tacgia VALUES ('12', '64');
INSERT INTO chitiet_dausach_tacgia VALUES ('12', '65');
INSERT INTO chitiet_dausach_tacgia VALUES ('13', '66');
INSERT INTO chitiet_dausach_tacgia VALUES ('14', '66');
INSERT INTO chitiet_dausach_tacgia VALUES ('15', '67');
INSERT INTO chitiet_dausach_tacgia VALUES ('15', '68');

INSERT INTO `CHITIET_DAUSACH_TACGIA` (`ID_DAUSACH`, `ID_TACGIA`) VALUES
(16, 16),
(17, 17),
(18, 18),
(19, 19),
(20, 20),
(21, 21),
(22, 22),
(23, 23),
(24, 24),
(25, 25),
(26, 26),
(27, 27),
(28, 28),
(29, 29),
(30, 30);
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
INSERT INTO chitiet_dausach_tacgia VALUES (46,46);
INSERT INTO chitiet_dausach_tacgia VALUES (47,70);
INSERT INTO chitiet_dausach_tacgia VALUES (48,70);
INSERT INTO chitiet_dausach_tacgia VALUES (49,70);
INSERT INTO chitiet_dausach_tacgia VALUES (50,71);
INSERT INTO chitiet_dausach_tacgia VALUES (51,72);
INSERT INTO chitiet_dausach_tacgia VALUES (52,73);
INSERT INTO chitiet_dausach_tacgia VALUES (53,51);
INSERT INTO chitiet_dausach_tacgia VALUES (54,52);
INSERT INTO chitiet_dausach_tacgia VALUES (55,53);
INSERT INTO chitiet_dausach_tacgia VALUES (56,54);
INSERT INTO chitiet_dausach_tacgia VALUES (57,55);
INSERT INTO chitiet_dausach_tacgia VALUES (58,56);
INSERT INTO chitiet_dausach_tacgia VALUES (59,57);
INSERT INTO chitiet_dausach_tacgia VALUES (60,57);



-- procedure

drop procedure xuli;
delimiter //
CREATE PROCEDURE xuli (IN fidsach int, fiddocgia int, fngtra datetime, fidpts int)
  BEGIN
    declare n_ngmuon datetime;
    declare n_songaymuon int;
    declare n_songaytratre int;
    declare n_maxngaymuon int;
    
    -- l???y ng??y m?????n
    select ngmuon into n_ngmuon
    from phieumuonsach p, chitiet_pms c
    where p.id_pms = c.id_pms
    and id_dg = fiddocgia
    and id_sach = fidsach
    and tinhtrang = 'ch??a tr???';
    
    -- ?????m s??? ng??y tr??? tr???
    select datediff(fngtra, n_ngmuon) into n_songaymuon;
    
    -- l???y tham s???
    select maxngaymuon into n_maxngaymuon
    from thamso;
    -- c???p nh???t chi ti???t tr??? s??ch
    update chitiet_pts
    set songmuon =n_songaymuon, tienphat = (n_songaymuon-n_maxngaymuon)*1000
    where id_sach = fidsach and id_pts = fidpts;
	-- c???p nh???t ti???n ph???t
     update phieutrasach
    set tienphatkinay= tienphatkinay + (n_songaymuon-n_maxngaymuon)*1000, tongno = tienphatkinay 
    where id_pts = fidpts;
  END//
delimiter ;
insert into thamso values (18,55,6,8,5,4);