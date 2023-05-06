using khawarizmi.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.DAL.Context;

public class KhawarizmiContext : IdentityDbContext<User>
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Feedback> Feedbacks => Set<Feedback>();
    public DbSet<Lesson> Lessons => Set<Lesson>();
    public DbSet<Tag> Tags => Set<Tag>();

    public KhawarizmiContext(DbContextOptions<KhawarizmiContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>().ToTable("Users");

        builder.Entity<Feedback>()
            .HasOne(f => f.User)
            .WithMany(u => u.Feedbacks)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Restrict); // to prevent multiple cascading paths and cycles

        builder.Entity<Course>()
            .Property(c => c.IsPublished)
            .HasDefaultValue(false);
    }
}
