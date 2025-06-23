using System.Text;
using DTO;
using DTO.Models;
using DTO.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Semestrovka.Extensions;

var builder = WebApplication.CreateBuilder(args);

// ⚡️ 1️⃣ JWT Options

// ⚡️ 2️⃣ Identity + EF
builder.Services.AddIdentity<User, IdentityRole>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddAuthorization();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/login";           // Страница для логина
    options.AccessDeniedPath = "/access-denied"; // Страница для отказа в доступе (необязательно)
});

// ⚡️ 3️⃣ JWT Auth (Bearer)


// ⚡️ 4️⃣ DI для остальных сервисов


// ⚡️ 5️⃣ Дополнительно
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// ⚡️ 6️⃣ EF Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// ⚡️ 7️⃣ Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<DoctorRepository>();

// ⚡️ BUILD
var app = builder.Build();

// ⚡️ Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

// ⚡️ Routing
app.UseRouting();

// ⚡️ Auth
app.UseAuthentication();
app.UseAuthorization();

// ⚡️ Route mapping
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=GetLogin}/{id?}");
app.MapRazorPages();


app.SeedRolesAsync();

// ⚡️ Swagger
app.UseSwagger();
app.UseSwaggerUI();

// ⚡️ 404


// ⚡️ Run
app.Run();
