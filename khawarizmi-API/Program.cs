using khawarizmi.BL.Managers;
using khawarizmi.DAL.Context;
using khawarizmi.DAL.Repositories;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Configuration
var connectionString = builder.Configuration.GetConnectionString("connStr");
builder.Services.AddDbContext<KhawarizmiContext>(options => options.UseSqlServer(connectionString));

#region Repositories
builder.Services.AddScoped<ICoursesRepo, CoursesRepo>();
builder.Services.AddScoped<ICategoriesRepo, CategoriesRepo>();
builder.Services.AddScoped<ITagsRepo, TagsRepo>();
#endregion

#region Managers
builder.Services.AddScoped<ICoursesManager, CoursesManager>();
builder.Services.AddScoped<ICategoriesManager, CategoriesManager>();
builder.Services.AddScoped<ITagsManager, TagsManager>();
#endregion

#region Cors Service
var corsPolicy = "corsPolicy";

builder.Services.AddCors(options => 
{
    options.AddPolicy(corsPolicy, builder => 
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
