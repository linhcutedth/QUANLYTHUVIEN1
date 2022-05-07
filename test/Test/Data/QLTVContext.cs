using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Test.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Data
{
    public partial class QLTVContext : IdentityDbContext<AppUser>
    {
        public QLTVContext()
        {
        }

        public QLTVContext(DbContextOptions<QLTVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChitietDausachTacgia> ChitietDausachTacgia { get; set; }
        public virtual DbSet<ChitietPms> ChitietPms { get; set; }
        public virtual DbSet<ChitietPts> ChitietPts { get; set; }
        public virtual DbSet<Dausach> Dausach { get; set; }
        public virtual DbSet<Phieumuonsach> Phieumuonsach { get; set; }
        public virtual DbSet<Phieuthutienphat> Phieuthutienphat { get; set; }
        public virtual DbSet<Phieutrasach> Phieutrasach { get; set; }
  
        public virtual DbSet<Sach> Sach { get; set; }
        public virtual DbSet<Tacgia> Tacgia { get; set; }
        public virtual DbSet<Thamso> Thamso { get; set; }
        public virtual DbSet<Thedocgia> Thedocgia { get; set; }
        public virtual DbSet<Theloai> Theloai { get; set; }
        public virtual DbSet<AppUser> AppUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;user=root;password=admin;database=QLTV");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChitietDausachTacgia>(entity =>
            {
                entity.HasKey(e => new { e.IdDausach, e.IdTacgia })
                    .HasName("PRIMARY");

                entity.ToTable("chitiet_dausach_tacgia");

                entity.HasIndex(e => e.IdTacgia)
                    .HasName("FK_CHITIET_DAUSACH_TACGIA2");

                entity.Property(e => e.IdDausach).HasColumnName("ID_DAUSACH");

                entity.Property(e => e.IdTacgia).HasColumnName("ID_TACGIA");

                entity.HasOne(d => d.IdDausachNavigation)
                    .WithMany(p => p.ChitietDausachTacgia)
                    .HasForeignKey(d => d.IdDausach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHITIET_DAUSACH_TACGIA");

                entity.HasOne(d => d.IdTacgiaNavigation)
                    .WithMany(p => p.ChitietDausachTacgia)
                    .HasForeignKey(d => d.IdTacgia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHITIET_DAUSACH_TACGIA2");
            });

            modelBuilder.Entity<ChitietPms>(entity =>
            {
                entity.HasKey(e => new { e.IdPms, e.IdSach })
                    .HasName("PRIMARY");

                entity.ToTable("chitiet_pms");

                entity.HasIndex(e => e.IdSach)
                    .HasName("FK_CHITIET_PMS2");

                entity.Property(e => e.IdPms).HasColumnName("ID_PMS");

                entity.Property(e => e.IdSach).HasColumnName("ID_SACH");

                entity.Property(e => e.Tinhtrang)
                    .HasColumnName("TINHTRANG")
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdPmsNavigation)
                    .WithMany(p => p.ChitietPms)
                    .HasForeignKey(d => d.IdPms)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHITIET_PMS");

                entity.HasOne(d => d.IdSachNavigation)
                    .WithMany(p => p.ChitietPms)
                    .HasForeignKey(d => d.IdSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHITIET_PMS2");
            });

            modelBuilder.Entity<ChitietPts>(entity =>
            {
                entity.HasKey(e => new { e.IdPts, e.IdSach })
                    .HasName("PRIMARY");

                entity.ToTable("chitiet_pts");

                entity.HasIndex(e => e.IdSach)
                    .HasName("FK_CHITIET_PTS2");

                entity.Property(e => e.IdPts).HasColumnName("ID_PTS");

                entity.Property(e => e.IdSach).HasColumnName("ID_SACH");

                entity.Property(e => e.Songmuon)
                    .HasColumnName("SONGMUON")
                    .HasColumnType("decimal(8,0)");

                entity.Property(e => e.Tienphat)
                    .HasColumnName("TIENPHAT")
                    .HasColumnType("decimal(8,0)");

                entity.HasOne(d => d.IdPtsNavigation)
                    .WithMany(p => p.ChitietPts)
                    .HasForeignKey(d => d.IdPts)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHITIET_PTS");

                entity.HasOne(d => d.IdSachNavigation)
                    .WithMany(p => p.ChitietPts)
                    .HasForeignKey(d => d.IdSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHITIET_PTS2");
            });

            modelBuilder.Entity<Dausach>(entity =>
            {
                entity.HasKey(e => e.IdDausach)
                    .HasName("PRIMARY");

                entity.ToTable("dausach");

                entity.HasIndex(e => e.IdTheloai)
                    .HasName("FK_THUOC1");

                entity.Property(e => e.IdDausach).HasColumnName("ID_DAUSACH");

                entity.Property(e => e.Dangchomuon).HasColumnName("DANGCHOMUON");

                entity.Property(e => e.Hinhanh)
                    .HasColumnName("HINHANH")
                    .HasMaxLength(200);

                entity.Property(e => e.IdTheloai).HasColumnName("ID_THELOAI");

                entity.Property(e => e.Namxuatban)
                    .HasColumnName("NAMXUATBAN")
                    .HasColumnType("decimal(8,0)");

                entity.Property(e => e.Ngnhap)
                    .HasColumnName("NGNHAP")
                    .HasColumnType("date");

                entity.Property(e => e.Nhaxuatban)
                    .HasColumnName("NHAXUATBAN")
                    .HasMaxLength(100);

                entity.Property(e => e.Sanco).HasColumnName("SANCO");

                entity.Property(e => e.Tensach)
                    .HasColumnName("TENSACH")
                    .HasMaxLength(100);

                entity.Property(e => e.Tongso).HasColumnName("TONGSO");

                entity.Property(e => e.Trigia)
                    .HasColumnName("TRIGIA")
                    .HasColumnType("decimal(8,0)");

                entity.HasOne(d => d.IdTheloaiNavigation)
                    .WithMany(p => p.Dausach)
                    .HasForeignKey(d => d.IdTheloai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_THUOC1");
            });

            modelBuilder.Entity<Phieumuonsach>(entity =>
            {
                entity.HasKey(e => e.IdPms)
                    .HasName("PRIMARY");

                entity.ToTable("phieumuonsach");

                entity.HasIndex(e => e.IdDg)
                    .HasName("FK_CO");

                entity.Property(e => e.IdPms).HasColumnName("ID_PMS");

                entity.Property(e => e.IdDg).HasColumnName("ID_DG");

                entity.Property(e => e.Ngmuon)
                    .HasColumnName("NGMUON")
                    .HasColumnType("date");

                entity.HasOne(d => d.IdDgNavigation)
                    .WithMany(p => p.Phieumuonsach)
                    .HasForeignKey(d => d.IdDg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CO");
            });

            modelBuilder.Entity<Phieuthutienphat>(entity =>
            {
                entity.HasKey(e => e.IdPhieuthu)
                    .HasName("PRIMARY");

                entity.ToTable("phieuthutienphat");

                entity.HasIndex(e => e.IdPts)
                    .HasName("FK_THUOC2");

                entity.Property(e => e.IdPhieuthu).HasColumnName("ID_PHIEUTHU");

                entity.Property(e => e.Conlai)
                    .HasColumnName("CONLAI")
                    .HasColumnType("decimal(8,0)");

                entity.Property(e => e.IdPts).HasColumnName("ID_PTS");

                entity.Property(e => e.Tongno)
                    .HasColumnName("TONGNO")
                    .HasColumnType("decimal(8,0)");

                entity.HasOne(d => d.IdPtsNavigation)
                    .WithMany(p => p.Phieuthutienphat)
                    .HasForeignKey(d => d.IdPts)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_THUOC2");
            });

            modelBuilder.Entity<Phieutrasach>(entity =>
            {
                entity.HasKey(e => e.IdPts)
                    .HasName("PRIMARY");

                entity.ToTable("phieutrasach");

                entity.HasIndex(e => e.IdDg)
                    .HasName("FK_CO1");

                entity.Property(e => e.IdPts).HasColumnName("ID_PTS");

                entity.Property(e => e.IdDg).HasColumnName("ID_DG");

                entity.Property(e => e.Ngtra)
                    .HasColumnName("NGTRA")
                    .HasColumnType("date");

                entity.Property(e => e.Tienphatkinay)
                    .HasColumnName("TIENPHATKINAY")
                    .HasColumnType("decimal(8,0)");

                entity.Property(e => e.Tongno)
                    .HasColumnName("TONGNO")
                    .HasColumnType("decimal(8,0)");

                entity.HasOne(d => d.IdDgNavigation)
                    .WithMany(p => p.Phieutrasach)
                    .HasForeignKey(d => d.IdDg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CO1");
            });

            

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.IdSach)
                    .HasName("PRIMARY");

                entity.ToTable("sach");

                entity.HasIndex(e => e.IdDausach)
                    .HasName("FK_CO12");

                entity.Property(e => e.IdSach).HasColumnName("ID_SACH");

                entity.Property(e => e.TinhTrang)
                    .HasColumnName("TINHTRANG")
                    .HasMaxLength(20);

                entity.Property(e => e.IdDausach).HasColumnName("ID_DAUSACH");

                entity.HasOne(d => d.IdDausachNavigation)
                    .WithMany(p => p.Sach)
                    .HasForeignKey(d => d.IdDausach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CO12");
            });

            modelBuilder.Entity<Tacgia>(entity =>
            {
                entity.HasKey(e => e.IdTacgia)
                    .HasName("PRIMARY");

                entity.ToTable("tacgia");

                entity.Property(e => e.IdTacgia).HasColumnName("ID_TACGIA");

                entity.Property(e => e.Tentg)
                    .HasColumnName("TENTG")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Thamso>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("thamso");

                entity.Property(e => e.KcNamxb)
                    .HasColumnName("KC_NAMXB")
                    .HasColumnType("decimal(8,0)");

                entity.Property(e => e.Maxngaymuon)
                    .HasColumnName("MAXNGAYMUON")
                    .HasColumnType("decimal(8,0)");

                entity.Property(e => e.Maxsachmuon)
                    .HasColumnName("MAXSACHMUON")
                    .HasColumnType("decimal(8,0)");

                entity.Property(e => e.Maxtuoi).HasColumnName("MAXTUOI");

                entity.Property(e => e.Mintuoi).HasColumnName("MINTUOI");

                entity.Property(e => e.Thoihanthe).HasColumnName("THOIHANTHE");
            });

            modelBuilder.Entity<Thedocgia>(entity =>
            {
                entity.HasKey(e => e.IdDg)
                    .HasName("PRIMARY");

                entity.ToTable("thedocgia");

                entity.Property(e => e.IdDg).HasColumnName("ID_DG");

                entity.Property(e => e.Diachi)
                    .HasColumnName("DIACHI")
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50);

                entity.Property(e => e.Hotendg)
                    .HasColumnName("HOTENDG")
                    .HasMaxLength(50);

                entity.Property(e => e.Loaidg)
                    .HasColumnName("LOAIDG")
                    .HasMaxLength(40);

                entity.Property(e => e.Nglapthe)
                    .HasColumnName("NGLAPTHE")
                    .HasColumnType("date");

                entity.Property(e => e.Ngsinh)
                    .HasColumnName("NGSINH")
                    .HasColumnType("date");

                entity.Property(e => e.Tinhtrang)
                    .HasColumnName("TINHTRANG")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Theloai>(entity =>
            {
                entity.HasKey(e => e.IdTheloai)
                    .HasName("PRIMARY");

                entity.ToTable("theloai");

                entity.Property(e => e.IdTheloai).HasColumnName("ID_THELOAI");

                entity.Property(e => e.Tentheloai)
                    .HasColumnName("TENTHELOAI")
                    .HasMaxLength(100);
            });

            

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
            // Bỏ tiền tố AspNet của các bảng: mặc định các bảng trong IdentityDbContext có
            // tên với tiền tố AspNet như: AspNetUserRoles, AspNetUser ...
            // Đoạn mã sau chạy khi khởi tạo DbContext, tạo database sẽ loại bỏ tiền tố đó
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
