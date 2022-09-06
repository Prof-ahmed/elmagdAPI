using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Domain.shopdb
{
    public partial class shopdbContext : DbContext
    {
        public shopdbContext()
        {
        }

        public shopdbContext(DbContextOptions<shopdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<CusCart> CusCarts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-HJB5TPB;Database=shopdb;Trusted_Connection=False;user id=magdy;password=5020786");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brand");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BrandName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("brand_name");

                entity.Property(e => e.IsAvailable).HasColumnName("is_available");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("cart");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.ItemsNumber).HasColumnName("items_number");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("money")
                    .HasColumnName("total_price");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_customer_cart");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("color");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ColorValue)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("color_value");

                entity.Property(e => e.IsAvailable).HasColumnName("is_available");
            });

            modelBuilder.Entity<CusCart>(entity =>
            {
                entity.ToTable("cus_cart");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.ColorId).HasColumnName("color_id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");

                entity.Property(e => e.SizeId).HasColumnName("size_id");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CusCarts)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK_cus_cart_cart");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.CusCarts)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK_cus_cart_color");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.CusCarts)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_cus_cart_item");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.CusCarts)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .HasConstraintName("FK_cus_cart_payment_method");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.CusCarts)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK_cus_cart_size");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserPassward)
                    .HasMaxLength(100)
                    .HasColumnName("user_passward");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("item");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.ItemDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("item_description");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("item_name");

                entity.Property(e => e.PicName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("pic_name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__item__brand_id__403A8C7D");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("payment_method");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsAvailable).HasColumnName("is_available");

                entity.Property(e => e.PaymentDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("payment_description");

                entity.Property(e => e.PaymentName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("payment_name");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("size");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IsAvailable).HasColumnName("is_available");

                entity.Property(e => e.SizeValue)
                    .HasMaxLength(10)
                    .HasColumnName("size_value");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
