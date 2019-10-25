using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBFirst
{
    public partial class FirstDBContext : DbContext
    {
        public FirstDBContext()
        {
        }

        public FirstDBContext(DbContextOptions<FirstDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<ProductAudits> ProductAudits { get; set; }
        public virtual DbSet<ProductCategories> ProductCategories { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Products2> Products2 { get; set; }
        public virtual DbSet<ProspectiveCustomers> ProspectiveCustomers { get; set; }
        public virtual DbSet<Salaries> Salaries { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<Test> Test { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=.\\SQLEXPRESS;Database=FirstDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasIndex(e => e.City)
                    .HasName("idx_Customer_City");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Lastname).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(2);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.Firstname).HasMaxLength(50);

                entity.Property(e => e.Lastname).HasMaxLength(50);

                entity.HasOne(d => d.ReportsTo)
                    .WithMany(p => p.InverseReportsTo)
                    .HasForeignKey(d => d.ReportsToId)
                    .HasConstraintName("FK_Employees_Employees");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetails_Orders");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Customers");
            });

            modelBuilder.Entity<ProductAudits>(entity =>
            {
                entity.HasKey(e => e.ChangeId)
                    .HasName("PK__product___F4EFE596F55062AF");

                entity.ToTable("product_audits");

                entity.Property(e => e.ChangeId).HasColumnName("change_id");

                entity.Property(e => e.Operation)
                    .IsRequired()
                    .HasColumnName("operation")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("product_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<ProductCategories>(entity =>
            {
                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.Department).HasMaxLength(50);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Products_Products");
            });

            modelBuilder.Entity<Products2>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__products__47027DF569CA6651");

                entity.ToTable("products2");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("product_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProspectiveCustomers>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Firstname).HasMaxLength(50);

                entity.Property(e => e.Lastname).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(2);
            });

            modelBuilder.Entity<Salaries>(entity =>
            {
                entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.Property(e => e.OrderDate).HasColumnType("date");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
