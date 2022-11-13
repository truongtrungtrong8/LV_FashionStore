using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Model.DataDB
{
    public partial class LV_FashionStoreContext : DbContext
    {
        public LV_FashionStoreContext()
        {
        }

        public LV_FashionStoreContext(DbContextOptions<LV_FashionStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CoMau> CoMaus { get; set; } = null!;
        public virtual DbSet<CoSize> CoSizes { get; set; } = null!;
        public virtual DbSet<CtDdh> CtDdhs { get; set; } = null!;
        public virtual DbSet<CtDn> CtDns { get; set; } = null!;
        public virtual DbSet<CtGh> CtGhs { get; set; } = null!;
        public virtual DbSet<CtHd> CtHds { get; set; } = null!;
        public virtual DbSet<CtT> CtTs { get; set; } = null!;
        public virtual DbSet<Cuahang> Cuahangs { get; set; } = null!;
        public virtual DbSet<DanhgiaSanpham> DanhgiaSanphams { get; set; } = null!;
        public virtual DbSet<DoanhThuNam> DoanhThuNams { get; set; } = null!;
        public virtual DbSet<DoanhThuQuy> DoanhThuQuies { get; set; } = null!;
        public virtual DbSet<DoanhThuThang> DoanhThuThangs { get; set; } = null!;
        public virtual DbSet<Dondathang> Dondathangs { get; set; } = null!;
        public virtual DbSet<Donnhap> Donnhaps { get; set; } = null!;
        public virtual DbSet<Giohang> Giohangs { get; set; } = null!;
        public virtual DbSet<Hinhanh> Hinhanhs { get; set; } = null!;
        public virtual DbSet<Hoadon> Hoadons { get; set; } = null!;
        public virtual DbSet<Hx> Hxs { get; set; } = null!;
        public virtual DbSet<Khachhang> Khachhangs { get; set; } = null!;
        public virtual DbSet<Khuyenmai> Khuyenmais { get; set; } = null!;
        public virtual DbSet<LoaiSp> LoaiSps { get; set; } = null!;
        public virtual DbSet<Mau> Maus { get; set; } = null!;
        public virtual DbSet<Nhacungcap> Nhacungcaps { get; set; } = null!;
        public virtual DbSet<Nhanvien> Nhanviens { get; set; } = null!;
        public virtual DbSet<QuanLyNv> QuanLyNvs { get; set; } = null!;
        public virtual DbSet<Sanpham> Sanphams { get; set; } = null!;
        public virtual DbSet<Size> Sizes { get; set; } = null!;
        public virtual DbSet<Taikhoan> Taikhoans { get; set; } = null!;
        public virtual DbSet<Thongsosp> Thongsosps { get; set; } = null!;
        public virtual DbSet<Tonkho> Tonkhos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-NE1IVP2;Database=LV_FashionStore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoMau>(entity =>
            {
                entity.HasKey(e => new { e.Mamau, e.MaSp, e.Id });

                entity.ToTable("CO_MAU");

                entity.Property(e => e.Mamau)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MAMAU");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_SP");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.CoMaus)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CO_MAU_CO_MAU2_SANPHAM");

                entity.HasOne(d => d.MamauNavigation)
                    .WithMany(p => p.CoMaus)
                    .HasForeignKey(d => d.Mamau)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CO_MAU_CO_MAU_MAU");
            });

            modelBuilder.Entity<CoSize>(entity =>
            {
                entity.HasKey(e => new { e.MaSp, e.MaSize, e.Id });

                entity.ToTable("CO_SIZE");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_SP");

                entity.Property(e => e.MaSize)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_SIZE");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.MaSizeNavigation)
                    .WithMany(p => p.CoSizes)
                    .HasForeignKey(d => d.MaSize)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CO_SIZE_CO_SIZE2_SIZE");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.CoSizes)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CO_SIZE_CO_SIZE_SANPHAM");
            });

            modelBuilder.Entity<CtDdh>(entity =>
            {
                entity.HasKey(e => new { e.MaDdh, e.MaSp });

                entity.ToTable("CT_DDH");

                entity.Property(e => e.MaDdh)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_DDH");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_SP");

                entity.Property(e => e.Dg).HasColumnName("DG");

                entity.Property(e => e.Mau)
                    .HasMaxLength(50)
                    .HasColumnName("MAU");

                entity.Property(e => e.Size)
                    .HasMaxLength(50)
                    .HasColumnName("SIZE");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.HasOne(d => d.MaDdhNavigation)
                    .WithMany(p => p.CtDdhs)
                    .HasForeignKey(d => d.MaDdh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_DDH_CT_DDH_DONDATHA");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.CtDdhs)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_DDH_CT_DDH2_SANPHAM");
            });

            modelBuilder.Entity<CtDn>(entity =>
            {
                entity.HasKey(e => new { e.MaDn, e.MaSp });

                entity.ToTable("CT_DN");

                entity.Property(e => e.MaDn)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_DN");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_SP");

                entity.Property(e => e.Dg).HasColumnName("DG");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.HasOne(d => d.MaDnNavigation)
                    .WithMany(p => p.CtDns)
                    .HasForeignKey(d => d.MaDn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_DN_CT_DN_DONNHAP");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.CtDns)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_DN_CT_DN2_SANPHAM");
            });

            modelBuilder.Entity<CtGh>(entity =>
            {
                entity.HasKey(e => new { e.MaSp, e.MaGh });

                entity.ToTable("CT_GH");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_SP");

                entity.Property(e => e.MaGh)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_GH");

                entity.Property(e => e.Mau)
                    .HasMaxLength(50)
                    .HasColumnName("MAU");

                entity.Property(e => e.Size)
                    .HasMaxLength(50)
                    .HasColumnName("SIZE");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.HasOne(d => d.MaGhNavigation)
                    .WithMany(p => p.CtGhs)
                    .HasForeignKey(d => d.MaGh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_GH_CT_GH2_GIOHANG");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.CtGhs)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_GH_CT_GH_SANPHAM");
            });

            modelBuilder.Entity<CtHd>(entity =>
            {
                entity.HasKey(e => new { e.MaSp, e.MaHd });

                entity.ToTable("CT_HD");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_SP");

                entity.Property(e => e.MaHd)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_HD");

                entity.Property(e => e.Dg).HasColumnName("DG");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.HasOne(d => d.MaHdNavigation)
                    .WithMany(p => p.CtHds)
                    .HasForeignKey(d => d.MaHd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_HD_CT_HD2_HOADON");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.CtHds)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_HD_CT_HD_SANPHAM");
            });

            modelBuilder.Entity<CtT>(entity =>
            {
                entity.HasKey(e => new { e.MaSp, e.MaTs });

                entity.ToTable("CT_TS");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_SP");

                entity.Property(e => e.MaTs)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_TS");

                entity.Property(e => e.Donvi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DONVI");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.CtTs)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_TS_CT_TS_SANPHAM");

                entity.HasOne(d => d.MaTsNavigation)
                    .WithMany(p => p.CtTs)
                    .HasForeignKey(d => d.MaTs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_TS_CT_TS2_THONGSOS");
            });

            modelBuilder.Entity<Cuahang>(entity =>
            {
                entity.HasKey(e => e.MaCh)
                    .IsClustered(false);

                entity.ToTable("CUAHANG");

                entity.Property(e => e.MaCh)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_CH");

                entity.Property(e => e.DiachiCh)
                    .HasMaxLength(100)
                    .HasColumnName("DIACHI_CH");

                entity.Property(e => e.MaNql)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MA_NQL");

                entity.Property(e => e.SdtCh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SDT_CH");

                entity.Property(e => e.TenCh)
                    .HasMaxLength(150)
                    .HasColumnName("TEN_CH");
            });

            modelBuilder.Entity<DanhgiaSanpham>(entity =>
            {
                entity.HasKey(e => new { e.MaSp, e.Id })
                    .HasName("PK_DANHGIA");

                entity.ToTable("DANHGIA_SANPHAM");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_SP");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.DanhGia).HasMaxLength(999);

                entity.Property(e => e.NgayDanhGia).HasColumnType("datetime");

                entity.Property(e => e.TenKh)
                    .HasMaxLength(100)
                    .HasColumnName("Ten_Kh");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.DanhgiaSanphams)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DANHGIA_SANPHAM");
            });

            modelBuilder.Entity<DoanhThuNam>(entity =>
            {
                entity.HasKey(e => new { e.Thang, e.Nam, e.Id })
                    .HasName("PK__DoanhThu__179BF0BA37873977");

                entity.ToTable("DoanhThuNam");

                entity.Property(e => e.Thang).HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<DoanhThuQuy>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Quy, e.Nam })
                    .HasName("PK__DoanhThu__3D781EDA15690DD0");

                entity.ToTable("DoanhThuQuy");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Quy).HasMaxLength(50);
            });

            modelBuilder.Entity<DoanhThuThang>(entity =>
            {
                entity.HasKey(e => e.Thang)
                    .HasName("PK__DoanhThu__2DD4F54A25C93CDE");

                entity.ToTable("DoanhThuThang");

                entity.Property(e => e.Thang).ValueGeneratedNever();
            });

            modelBuilder.Entity<Dondathang>(entity =>
            {
                entity.HasKey(e => e.MaDdh);

                entity.ToTable("DONDATHANG");

                entity.Property(e => e.MaDdh)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_DDH");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(140)
                    .HasColumnName("DIACHI");

                entity.Property(e => e.MaKh)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_KH");

                entity.Property(e => e.Thoigian).HasColumnType("datetime");

                entity.Property(e => e.TinhTrang).HasMaxLength(50);

                entity.Property(e => e.TongDdh).HasColumnName("TONG_DDH");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.Dondathangs)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DONDATHANG_KHACHHANG");
            });

            modelBuilder.Entity<Donnhap>(entity =>
            {
                entity.HasKey(e => e.MaDn)
                    .IsClustered(false);

                entity.ToTable("DONNHAP");

                entity.Property(e => e.MaDn)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_DN");

                entity.Property(e => e.MaNcc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_NCC");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_NV");

                entity.Property(e => e.NgaylapHd)
                    .HasColumnType("datetime")
                    .HasColumnName("NGAYLAP_HD");

                entity.Property(e => e.TongDn).HasColumnName("TONG_DN");

                entity.HasOne(d => d.MaNccNavigation)
                    .WithMany(p => p.Donnhaps)
                    .HasForeignKey(d => d.MaNcc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DONNHAP_CO__ON_NHACUNGC");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.Donnhaps)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DONNHAP_LAP__ON_NHANVIEN");
            });

            modelBuilder.Entity<Giohang>(entity =>
            {
                entity.HasKey(e => e.MaGh)
                    .IsClustered(false);

                entity.ToTable("GIOHANG");

                entity.Property(e => e.MaGh)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_GH");

                entity.Property(e => e.MaKh)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_KH");

                entity.Property(e => e.Ngaydat)
                    .HasColumnType("datetime")
                    .HasColumnName("NGAYDAT");

                entity.Property(e => e.Tongtien).HasColumnName("TONGTIEN");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.Giohangs)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GIOHANG_RELATIONS_KHACHHAN");
            });

            modelBuilder.Entity<Hinhanh>(entity =>
            {
                entity.HasKey(e => e.MaHa)
                    .IsClustered(false);

                entity.ToTable("HINHANH");

                entity.Property(e => e.MaHa).HasColumnName("MA_HA");

                entity.Property(e => e.Ha1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("HA_1");

                entity.Property(e => e.Ha2)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("HA_2");

                entity.Property(e => e.Ha3)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("HA_3");

                entity.Property(e => e.HaBia)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("HA_BIA");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_SP");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.Hinhanhs)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HINHANH_GOM_SANPHAM");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.MaHd)
                    .IsClustered(false);

                entity.ToTable("HOADON");

                entity.Property(e => e.MaHd)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_HD");

                entity.Property(e => e.DiachiHd)
                    .HasMaxLength(140)
                    .HasColumnName("DIACHI_HD");

                entity.Property(e => e.MaKh)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_KH");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_NV");

                entity.Property(e => e.NgaylapHd)
                    .HasColumnType("datetime")
                    .HasColumnName("NGAYLAP_HD");

                entity.Property(e => e.TongHd).HasColumnName("TONG_HD");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HOADON_CO_HD_KHACHHAN");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HOADON_TAO_BOI_NHANVIEN");
            });

            modelBuilder.Entity<Hx>(entity =>
            {
                entity.HasKey(e => e.MaHsx)
                    .IsClustered(false);

                entity.ToTable("HXS");

                entity.Property(e => e.MaHsx)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_HSX");

                entity.Property(e => e.TenHsx)
                    .HasMaxLength(120)
                    .HasColumnName("TEN_HSX");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.MaKh)
                    .IsClustered(false);

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.MaKh)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_KH");

                entity.Property(e => e.DiachiKh)
                    .HasMaxLength(500)
                    .HasColumnName("DIACHI_KH");

                entity.Property(e => e.EmailKh)
                    .HasMaxLength(100)
                    .HasColumnName("Email_Kh");

                entity.Property(e => e.SdtKh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SDT_KH");

                entity.Property(e => e.TenKh)
                    .HasMaxLength(400)
                    .HasColumnName("TEN_KH");

                entity.Property(e => e.TenTk)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TEN_TK");

                entity.HasOne(d => d.TenTkNavigation)
                    .WithMany(p => p.Khachhangs)
                    .HasForeignKey(d => d.TenTk)
                    .HasConstraintName("FK_KHACHHAN_CHO_TAIKHOAN");
            });

            modelBuilder.Entity<Khuyenmai>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("KHUYENMAI");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_SP");

                entity.Property(e => e.Thoigian)
                    .HasColumnType("datetime")
                    .HasColumnName("THOIGIAN");

                entity.Property(e => e.Tile).HasColumnName("TILE");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.Khuyenmais)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KHUYENMA_CO_SANPHAM");
            });

            modelBuilder.Entity<LoaiSp>(entity =>
            {
                entity.HasKey(e => e.MaLoai)
                    .IsClustered(false);

                entity.ToTable("LOAI_SP");

                entity.Property(e => e.MaLoai)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_LOAI");

                entity.Property(e => e.Tenloai)
                    .HasMaxLength(200)
                    .HasColumnName("TENLOAI");
            });

            modelBuilder.Entity<Mau>(entity =>
            {
                entity.HasKey(e => e.Mamau)
                    .IsClustered(false);

                entity.ToTable("MAU");

                entity.Property(e => e.Mamau)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MAMAU");

                entity.Property(e => e.Tenmau)
                    .HasMaxLength(100)
                    .HasColumnName("TENMAU");
            });

            modelBuilder.Entity<Nhacungcap>(entity =>
            {
                entity.HasKey(e => e.MaNcc)
                    .IsClustered(false);

                entity.ToTable("NHACUNGCAP");

                entity.Property(e => e.MaNcc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_NCC");

                entity.Property(e => e.DiachiNcc)
                    .HasMaxLength(500)
                    .HasColumnName("DIACHI_NCC");

                entity.Property(e => e.SdtNcc)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SDT_NCC")
                    .IsFixedLength();

                entity.Property(e => e.TenNcc)
                    .HasMaxLength(400)
                    .HasColumnName("TEN_NCC");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .IsClustered(false);

                entity.ToTable("NHANVIEN");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_NV");

                entity.Property(e => e.ChucvuNv)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CHUCVU_NV");

                entity.Property(e => e.DcNv)
                    .HasMaxLength(400)
                    .HasColumnName("DC_NV");

                entity.Property(e => e.GtNv)
                    .HasMaxLength(10)
                    .HasColumnName("GT_NV");

                entity.Property(e => e.HtenNv)
                    .HasMaxLength(400)
                    .HasColumnName("HTEN_NV");

                entity.Property(e => e.LuongNv).HasColumnName("LUONG_NV");

                entity.Property(e => e.MaCh)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_CH");

                entity.Property(e => e.NsNv)
                    .HasColumnType("datetime")
                    .HasColumnName("NS_NV");

                entity.Property(e => e.TenTk)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TEN_TK");

                entity.HasOne(d => d.MaChNavigation)
                    .WithMany(p => p.Nhanviens)
                    .HasForeignKey(d => d.MaCh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NHANVIEN_CO_NV_CUAHANG");

                entity.HasOne(d => d.TenTkNavigation)
                    .WithMany(p => p.Nhanviens)
                    .HasForeignKey(d => d.TenTk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NHANVIEN_SU_DUNG_TAIKHOAN");
            });

            modelBuilder.Entity<QuanLyNv>(entity =>
            {
                entity.ToTable("QuanLyNV");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Chucvu).HasMaxLength(50);

                entity.Property(e => e.TenNv)
                    .HasMaxLength(50)
                    .HasColumnName("TenNV");
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.HasKey(e => e.MaSp)
                    .IsClustered(false);

                entity.ToTable("SANPHAM");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_SP");

                entity.Property(e => e.Baohanh).HasColumnName("BAOHANH");

                entity.Property(e => e.GiaSp).HasColumnName("GIA_SP");

                entity.Property(e => e.MaHsx)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_HSX");

                entity.Property(e => e.MaLoai)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_LOAI");

                entity.Property(e => e.Mota)
                    .HasMaxLength(1000)
                    .HasColumnName("MOTA");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.TenSp)
                    .HasMaxLength(200)
                    .HasColumnName("TEN_SP");

                entity.Property(e => e.TinhTrang)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaHsxNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.MaHsx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SANPHAM_SAN_XUAT_HXS");

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.MaLoai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SANPHAM_LOAI_LOAI_SP");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.HasKey(e => e.MaSize)
                    .IsClustered(false);

                entity.ToTable("SIZE");

                entity.Property(e => e.MaSize)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_SIZE");

                entity.Property(e => e.TenSize)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("TEN_SIZE");
            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasKey(e => e.TenTk)
                    .IsClustered(false);

                entity.ToTable("TAIKHOAN");

                entity.Property(e => e.TenTk)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TEN_TK");

                entity.Property(e => e.Matkhau)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("MATKHAU");

                entity.Property(e => e.Quyensd)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("QUYENSD");

                entity.Property(e => e.TrangThai)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Thongsosp>(entity =>
            {
                entity.HasKey(e => e.MaTs)
                    .IsClustered(false);

                entity.ToTable("THONGSOSP");

                entity.Property(e => e.MaTs)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_TS");

                entity.Property(e => e.TenTs)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TEN_TS");
            });

            modelBuilder.Entity<Tonkho>(entity =>
            {
                entity.HasKey(e => new { e.MaSp, e.MaCh });

                entity.ToTable("TONKHO");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_SP");

                entity.Property(e => e.MaCh)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MA_CH");

                entity.Property(e => e.Dg).HasColumnName("DG");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.HasOne(d => d.MaChNavigation)
                    .WithMany(p => p.Tonkhos)
                    .HasForeignKey(d => d.MaCh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TONKHO_TONKHO2_CUAHANG");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.Tonkhos)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TONKHO_TONKHO_SANPHAM");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
