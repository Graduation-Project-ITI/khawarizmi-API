using khawarizmi.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Permissions;
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
    public DbSet<UserCourses> UserCourses => Set<UserCourses>();

    public KhawarizmiContext(DbContextOptions<KhawarizmiContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>().ToTable("Users");

        builder.Entity<Course>()
            .Property(c => c.IsPublished)
            .HasDefaultValue(false);

        builder.Entity<Feedback>()
            .HasOne(f => f.User)
            .WithMany(u => u.Feedbacks)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Restrict); // to prevent multiple cascading paths and cycles

        builder.Entity<UserCourses>()
            .HasOne(uc => uc.User)
            .WithMany(u => u.UserCourses)
            .HasForeignKey(uc => uc.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        #region Data Seeding

        builder.Entity<Category>()
            .HasData(
            new { Id = 1, Name = "Web Development" },
            new { Id = 2, Name = "Mobile Development" },
            new { Id = 3, Name = "Database Design & Development" },
            new { Id = 4, Name = "Data Science" },
            new { Id = 5, Name = "Programming Languages" },
            new { Id = 6, Name = "Game Development" },
            new { Id = 7, Name = "Software Testing" },
            new { Id = 8, Name = "Software Engineering" },
            new { Id = 9, Name = "Software Development Tools" },
            new { Id = 10, Name = "No-Code Development" }
            );

        builder.Entity<Tag>()
            .HasData(
            new { Id=1, Name = "JavaScript"},
            new { Id=2, Name = "CSS"},
            new { Id=3, Name = "Angular"},
            new { Id=4, Name = "Node.js"},
            new { Id=5, Name = "Asp.Net Core"},
            new { Id=6, Name = "TypeScript"},
            new { Id=7, Name = "Next.js"},
            new { Id=8, Name = "React Js"},
            new { Id=9, Name = "Python"},
            new { Id=10, Name = "AI"},
            new { Id=11, Name = "Machine Learning"},
            new { Id=12, Name = "Deep Learning"},
            new { Id=13, Name = "Natural Language Processing"},
            new { Id=14, Name = "Data Analysis"},
            new { Id=15, Name = "R (Programming Language)"},
            new { Id=16, Name = "Deep Learning"},
            new { Id=17, Name = "Chatgpt"},
            new { Id=18, Name = "Google Flutter"},
            new { Id=19, Name = "Android Development"},
            new { Id=20, Name = "IOS Development"},
            new { Id=21, Name = "React Native"},
            new { Id=22, Name = "Dart"},
            new { Id=23, Name = "Swift"},
            new { Id=24, Name = "SwiftUI"},
            new { Id=25, Name = "Kotlin"},
            new { Id=26, Name = "C#"},
            new { Id=27, Name = "C++"},
            new { Id=28, Name = "Java"},
            new { Id=29, Name = "C (Programming Language)"},
            new { Id=30, Name = "Spring Framework"},
            new { Id=31, Name = "Object Oriented Programming"},
            new { Id=32, Name = "Unity"},
            new { Id=33, Name = "Unreal Engine"},
            new { Id=34, Name = "Game Development Fundamentals"},
            new { Id=35, Name = "2D Game Development"},
            new { Id=36, Name = "3D Game Development"},
            new { Id=37, Name = "SQL"},
            new { Id=38, Name = "NOSQL"},
            new { Id=39, Name = "MongoDB"},
            new { Id=40, Name = "Postgres"},
            new { Id=41, Name = "SQL Server"},
            new { Id=42, Name = "Oracle SQL"},
            new { Id=43, Name = "Postman"},
            new { Id=44, Name = "Automation Testing"},
            new { Id=45, Name = "API Testing"},
            new { Id=46, Name = "Data Structure"},
            new { Id=47, Name = "Algorithms"},
            new { Id=48, Name = "Microservices"},
            new { Id=49, Name = "Software Architecture"},
            new { Id=50, Name = "Back End Web Development"},
            new { Id=51, Name = "Front End Web Development"},
            new { Id=52, Name = "Docker"},
            new { Id=53, Name = "Kubernetes"},
            new { Id=54, Name = "Git"},
            new { Id=55, Name = "Github"},
            new { Id=56, Name = "Jira"},
            new { Id=57, Name = "DevOps"},
            new { Id=58, Name = "Jenkins"},
            new { Id=59, Name = "WordPress"},
            new { Id=60, Name = "Web Design"},
            new { Id=61, Name = "Microsoft Power Platform"},
            new { Id=62, Name = "Wix"},
            new { Id=63, Name = "Elementor"}
            );

        builder.Entity<Category>()
            .HasMany(c => c.Tags)
            .WithMany(t => t.Categories)
            .UsingEntity<Dictionary<string, object>>(
                "CategoryTag",
                j => j.HasData(
                        new{ CategoriesId= 1, TagsId=1 },
                        new{ CategoriesId= 1, TagsId=2 },
                        new{ CategoriesId= 1, TagsId=3 },
                        new{ CategoriesId= 1, TagsId=4 },
                        new{ CategoriesId= 1, TagsId=5 },
                        new{ CategoriesId= 1, TagsId=6 },
                        new{ CategoriesId= 1, TagsId=7 },
                        new{ CategoriesId= 1, TagsId=8 },

                        new{ CategoriesId= 4, TagsId=9 },
                        new{ CategoriesId= 4, TagsId=10 },
                        new{ CategoriesId= 4, TagsId=11 },
                        new{ CategoriesId= 4, TagsId=12 },
                        new{ CategoriesId= 4, TagsId=13 },
                        new{ CategoriesId= 4, TagsId=14 },
                        new{ CategoriesId= 4, TagsId=15 },
                        new{ CategoriesId= 4, TagsId=16 },
                        new{ CategoriesId= 4, TagsId=17 },

                        new{ CategoriesId= 2, TagsId=18 },
                        new{ CategoriesId= 2, TagsId=19 },
                        new{ CategoriesId= 2, TagsId=20 },
                        new{ CategoriesId= 2, TagsId=21 },
                        new{ CategoriesId= 2, TagsId=22 },
                        new{ CategoriesId= 2, TagsId=23 },
                        new{ CategoriesId= 2, TagsId=24 },
                        new{ CategoriesId= 2, TagsId=25 },
                        
                        new{ CategoriesId= 5, TagsId=26 },
                        new{ CategoriesId= 5, TagsId=27 },
                        new{ CategoriesId= 5, TagsId=28 },
                        new{ CategoriesId= 5, TagsId=29 },
                        new{ CategoriesId= 5, TagsId=30 },
                        new{ CategoriesId= 5, TagsId=31 },
                        new{ CategoriesId= 5, TagsId=15 },
                        new{ CategoriesId= 5, TagsId=9 },
                        new{ CategoriesId= 5, TagsId=1 },
                        new{ CategoriesId= 5, TagsId=8 },

                        new{ CategoriesId= 6, TagsId=32 },
                        new{ CategoriesId= 6, TagsId=33 },
                        new{ CategoriesId= 6, TagsId=34 },
                        new{ CategoriesId= 6, TagsId=35 },
                        new{ CategoriesId= 6, TagsId=36 },
                        
                        new{ CategoriesId= 3, TagsId=37 },
                        new{ CategoriesId= 3, TagsId=38 },
                        new{ CategoriesId= 3, TagsId=39 },
                        new{ CategoriesId= 3, TagsId=40 },
                        new{ CategoriesId= 3, TagsId=41 },
                        new{ CategoriesId= 3, TagsId=42 },

                        new{ CategoriesId= 7, TagsId=43 },
                        new{ CategoriesId= 7, TagsId=44 },
                        new{ CategoriesId= 7, TagsId=45 },

                        new{ CategoriesId= 8, TagsId=46 },
                        new{ CategoriesId= 8, TagsId=47 },
                        new{ CategoriesId= 8, TagsId=48 },
                        new{ CategoriesId= 8, TagsId=49 },
                        new{ CategoriesId= 8, TagsId=50 },
                        
                        new{ CategoriesId= 9, TagsId=51 },
                        new{ CategoriesId= 9, TagsId=52 },
                        new{ CategoriesId= 9, TagsId=53 },
                        new{ CategoriesId= 9, TagsId=54 },
                        new{ CategoriesId= 9, TagsId=55 },
                        new{ CategoriesId= 9, TagsId=56 },
                        new{ CategoriesId= 9, TagsId=57 },
                        new{ CategoriesId= 9, TagsId=58 },

                        new{ CategoriesId= 10, TagsId=59 },
                        new{ CategoriesId= 10, TagsId=60 },
                        new{ CategoriesId= 10, TagsId=61 },
                        new{ CategoriesId= 10, TagsId=62 },
                        new{ CategoriesId= 10, TagsId=63 }

                    ));
        #endregion
    }
}
