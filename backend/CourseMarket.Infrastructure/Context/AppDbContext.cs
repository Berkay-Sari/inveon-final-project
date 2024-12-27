using CourseMarket.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CourseMarket.Infrastructure.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Course>()
            .HasOne(c => c.Instructor)
            .WithMany(u => u!.Courses)
            .HasForeignKey(c => c.InstructorId);
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Buyer)
            .WithMany(u => u!.Orders)
            .HasForeignKey(o => o.BuyerId);
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Course)
            .WithMany(c => c!.Orders)
            .HasForeignKey(o => o.CourseId);
        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Order)
            .WithOne(o => o!.Payment)
            .HasForeignKey<Payment>(p => p.OrderId);
    }
}