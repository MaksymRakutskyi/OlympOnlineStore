using Microsoft.EntityFrameworkCore;
using OlympOnlineStore.API.Data.Entities;

namespace OlympOnlineStore.API.Data;

public class OlympOnlineStoreDbContext : DbContext
{
    public OlympOnlineStoreDbContext()
    {
    }
    
    public OlympOnlineStoreDbContext(DbContextOptions<OlympOnlineStoreDbContext> options) : base(options)
    {
    }
    
    public virtual DbSet<UserEntity> Users { get; set; }
    public virtual DbSet<CarEntity> Cars { get; set; }
    public virtual DbSet<CarImageEntity> CarImages { get; set; }
    public virtual DbSet<BookingEntity> Bookings { get; set; }
    public virtual DbSet<PaymentEntity> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(e => e.UserId).HasName("PK_Users");
            entity.HasIndex(e => e.Email).IsUnique().HasDatabaseName("UQ_Users_Email");
            entity.HasIndex(e => e.PhoneNumber).IsUnique().HasDatabaseName("UQ_Users_PhoneNumber");
            entity.Property(e => e.UserId).IsRequired().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(255);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Email).IsRequired(false).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(255);
            entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(64);
            entity.Property(e => e.PasswordSalt).IsRequired().HasMaxLength(32);
            entity.Property(e => e.Role).IsRequired().HasConversion<int>();
            entity.Property(e => e.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
        });

        modelBuilder.Entity<CarEntity>(entity => { 
            entity.ToTable("Cars"); 
            entity.HasKey(e => e.CarId).HasName("PK_Cars"); 
            entity.Property(e => e.CarId).IsRequired().HasDefaultValueSql("NEWID()"); 
            entity.Property(e => e.Brand).IsRequired().HasMaxLength(255); 
            entity.Property(e => e.Model).IsRequired().HasMaxLength(255); 
            entity.Property(e => e.Year).IsRequired(); 
            entity.Property(e => e.Transmission).IsRequired().HasConversion<int>(); 
            entity.Property(e => e.PricePerDay).IsRequired(false).HasColumnType("decimal(18,2)"); 
            entity.Property(e => e.PricePerWeek).IsRequired(false).HasColumnType("decimal(18,2)"); 
            entity.Property(e => e.PricePerMonth).IsRequired(false).HasColumnType("decimal(18,2)"); 
            entity.Property(e => e.Availability).IsRequired(); 
            entity.Property(e => e.Description).IsRequired(false).HasMaxLength(1000); 
        });
        
        modelBuilder.Entity<CarImageEntity>(entity => { 
            entity.ToTable("CarImages");
            entity.HasKey(e => e.ImageId).HasName("PK_CarImages");
            entity.Property(e => e.ImageId).IsRequired().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.CarId).IsRequired();
            entity.Property(e => e.ImageBase64).IsRequired();
            entity.Property(e => e.Order).IsRequired();
            entity.HasOne(ci => ci.CarEntity)
                .WithMany(c => c.ImageEntities)
                .HasForeignKey(ci => ci.CarId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<BookingEntity>(entity => { 
            entity.ToTable("Bookings"); 
            entity.HasKey(e => e.BookingId).HasName("PK_Bookings"); 
            entity.Property(e => e.BookingId).IsRequired().HasDefaultValueSql("NEWID()"); 
            entity.Property(e => e.UserId).IsRequired(); 
            entity.Property(e => e.CarId).IsRequired(); 
            entity.Property(e => e.StarDate).IsRequired(); 
            entity.Property(e => e.EndDate).IsRequired(); 
            entity.Property(e => e.TotalPrice).IsRequired().HasColumnType("decimal(18,2)"); 
            entity.Property(e => e.BookingStatus).IsRequired().HasConversion<int>(); 
            entity.Property(e => e.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
            entity.HasOne(b => b.UserEntity)
                .WithMany(u => u.BookingEntities)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade); 
            entity.HasOne(b => b.CarEntity)
                .WithMany(c => c.BookingEntities)
                .HasForeignKey(b => b.CarId)
                .OnDelete(DeleteBehavior.Cascade); 
        });
        
        modelBuilder.Entity<PaymentEntity>(entity => { 
            entity.ToTable("Payments"); 
            entity.HasKey(e => e.PaymentId).HasName("PK_Payments"); 
            entity.Property(e => e.PaymentId).IsRequired().HasDefaultValueSql("NEWID()"); 
            entity.Property(e => e.BookingId).IsRequired(); 
            entity.Property(e => e.Amount).IsRequired().HasColumnType("decimal(18,2)"); 
            entity.Property(e => e.PaymentMethod).IsRequired().HasConversion<int>(); 
            entity.Property(e => e.PaymentStatus).IsRequired().HasConversion<int>(); 
            entity.Property(e => e.PaymentDate).IsRequired().HasDefaultValueSql("GETDATE()");
            entity.HasOne(p => p.BookingEntity)
                .WithMany(b => b.PaymentEntities)
                .HasForeignKey(p => p.BookingId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}