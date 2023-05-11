using khawarizmi.BL.Managers;
using khawarizmi.DAL.Context;
using khawarizmi.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using khawarizmi.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using khawarizmi.BL.Managers.StorageService;
using Microsoft.Extensions.Azure;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;
using khawarizmi.BL.Managers.Lessons;
using khawarizmi.DAL.Repositories.Lessons;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Configuration
var connectionString = builder.Configuration.GetConnectionString("connStr");
builder.Services.AddDbContext<KhawarizmiContext>(options => options.UseSqlServer(connectionString));

// service for storing data to MS Azure Blob Storage
builder.Services.AddAzureClients(options=>
{
    options.AddBlobServiceClient(builder.Configuration.GetSection("Storage:ConnectionString").Value); // might be an issue here
});

#region IdentityManager
builder.Services.AddIdentity<User, IdentityRole>(
    options =>
    {
       
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.User.RequireUniqueEmail = true;
        
    }
).AddEntityFrameworkStores<KhawarizmiContext>();
#endregion

#region Repositories
builder.Services.AddScoped<ICoursesRepo, CoursesRepo>();
builder.Services.AddScoped<ICategoriesRepo, CategoriesRepo>();
builder.Services.AddScoped<ITagsRepo, TagsRepo>();
builder.Services.AddScoped<ILessonRepo, LessonRepo>();
#endregion

#region Managers
builder.Services.AddScoped<ICoursesManager, CoursesManager>();
builder.Services.AddScoped<ICategoriesManager, CategoriesManager>();
builder.Services.AddScoped<ITagsManager, TagsManager>();
builder.Services.AddTransient<IStorageService, StorageService>();
builder.Services.AddScoped<ILessonsManager, LessonsManager>();
#endregion

#region JWTBearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "AuthSchema";
    options.DefaultChallengeScheme = "AuthSchema";
}).AddJwtBearer("AuthSchema",options=>{

    var SecretKeyinString = builder.Configuration.GetValue<string>("SecretKey")?? "";
    var secretKeyinBytes= Encoding.ASCII.GetBytes(SecretKeyinString);
    var secretkey= new SymmetricSecurityKey(secretKeyinBytes);
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        IssuerSigningKey = secretkey,
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

#endregion

#region Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AllowUsers",
        builder => builder.RequireClaim(ClaimTypes.Role, "User"));
    options.AddPolicy("AllowAdmin",
        builder => builder.RequireClaim(ClaimTypes.Role, "Admin"));
});

#endregion

#region Cors

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

#endregion

// increasing the maximum multipart body length limit to 10MB
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 20 * 1024 * 1024;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyCorsPolicy");

app.UseHttpsRedirection();

// to serve satatic files
app.UseStaticFiles(new StaticFileOptions
{
    // now we can access any file in the "Uploads" folder like this:
    // https://<hostname>/Uploads/Images/red-rose.jpg or
    // https://<hostname>/Uploads/Videos/video.mp4
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Uploads")),
    RequestPath = "/Uploads"
});

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();