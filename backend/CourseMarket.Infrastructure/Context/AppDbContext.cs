using CourseMarket.Domain.Common;
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
                PasswordHash = hasher.HashPassword(null!, "aslan1905"),
                FirstName = "Fatih",
                LastName = "Terim"
            },
            new AppUser
            {
                Id = userId,
                UserName = "user1",
                NormalizedUserName = "USER1",
                PasswordHash = hasher.HashPassword(null!, "aslan1905"),
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

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var entries = ChangeTracker.Entries<IAuditEntity>();
        var now = DateTime.UtcNow;

        foreach (var entry in entries)
        {
            _ = entry.State switch
            {
                EntityState.Added  => entry.Entity.CreatedDate = now,
                EntityState.Modified => entry.Entity.UpdatedDate = now,
                _ => DateTime.UtcNow
            };
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}