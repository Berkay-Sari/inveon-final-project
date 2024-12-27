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
            .HasForeignKey(c => c.InstructorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Buyer)
            .WithMany(u => u!.Orders)
            .HasForeignKey(o => o.BuyerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Course)
            .WithMany(c => c!.Orders)
            .HasForeignKey(o => o.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Order)
            .WithOne(o => o!.Payment)
            .HasForeignKey<Payment>(p => p.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Payment>()
            .HasOne(p => p.User)
            .WithMany(u => u!.Payments)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Seed Data
        var instructorId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var instructorRoleId = Guid.NewGuid();
        modelBuilder.Entity<IdentityRole<Guid>>().HasData(
            new IdentityRole<Guid>
            {
                Id = instructorRoleId,
                Name = "Instructor",
                NormalizedName = "INSTRUCTOR"
            }
        );

        var hasher = new PasswordHasher<AppUser>();

        modelBuilder.Entity<AppUser>().HasData(
            new AppUser
            {
                Id = instructorId,
                UserName = "instructor1",
                NormalizedUserName = "INSTRUCTOR1",
                PasswordHash = hasher.HashPassword(null, "aslan1905"),
                FirstName = "Fatih",
                LastName = "Terim"
            },
            new AppUser
            {
                Id = userId,
                UserName = "user1",
                NormalizedUserName = "USER1",
                PasswordHash = hasher.HashPassword(null, "aslan1905"),
                FirstName = "Arda",
                LastName = "Turan"
            }
        );

        modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
            new IdentityUserRole<Guid>
            {
                RoleId = instructorRoleId,
                UserId = instructorId
            }
        );
    }
}