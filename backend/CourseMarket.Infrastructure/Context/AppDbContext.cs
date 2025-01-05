using CourseMarket.Domain.Common;
using CourseMarket.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using File = CourseMarket.Domain.Entities.File;

namespace CourseMarket.Infrastructure.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<Course> Courses { get; set; }

    public DbSet<Basket> Baskets { get; set; }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Payment> Payments { get; set; }

    // Table per Hierarchy (TPH) inheritance 
    public DbSet<File> Files { get; set; }
    public DbSet<CourseImageFile> CourseImageFiles { get; set; }
    public DbSet<InvoiceFile> InvoiceFiles { get; set; }

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