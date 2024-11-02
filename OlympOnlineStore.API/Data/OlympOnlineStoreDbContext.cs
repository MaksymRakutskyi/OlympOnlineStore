using Microsoft.EntityFrameworkCore;
using OlympOnlineStore.API.Data.Entities;

namespace OlympOnlineStore.API.Data;

public class OlympOnlineStoreDbContext : DbContext
{
    // private readonly IConfiguration _configuration;
    //
    // public OlympOnlineStoreDbContext(IConfiguration configuration)
    // {
    //     _configuration = configuration;
    // }

    // public OlympOnlineStoreDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
    // {
    //     _configuration = configuration;
    // }

    public OlympOnlineStoreDbContext()
    {
    }

    public OlympOnlineStoreDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public virtual DbSet<UserEntity> Users { get; set; }
    public virtual DbSet<CarEntity> Cars { get; set; }
    public virtual DbSet<BookingEntity> Bookings { get; set; }
    public virtual DbSet<PaymentEntity> Payments { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     if (optionsBuilder.IsConfigured)
    //         return;
    //     
    //     optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserEntity>()
            .ToTable("Users")
            .HasKey(e => e.UserId).HasName("PK_Users");

        modelBuilder.Entity<CarEntity>()
            .ToTable("Cars")
            .HasKey(e => e.CarId).HasName("PK_Cars");
        
        modelBuilder.Entity<BookingEntity>()
            .ToTable("Bookings")
            .HasKey(e => e.BookingId).HasName("PK_Bookings");
        
        modelBuilder.Entity<PaymentEntity>()
            .ToTable("Payments")
            .HasKey(e => e.PaymentId).HasName("PK_Payments");
        
        modelBuilder.Entity<BookingEntity>()
            .HasOne(b => b.UserEntity)
            .WithMany(u => u.BookingEntities)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BookingEntity>()
            .HasOne(b => b.CarEntity)
            .WithMany(c => c.BookingEntities)
            .HasForeignKey(b => b.CarId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PaymentEntity>()
            .HasOne(p => p.BookingEntity)
            .WithMany(b => b.PaymentEntities)
            .HasForeignKey(p => p.BookingId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}