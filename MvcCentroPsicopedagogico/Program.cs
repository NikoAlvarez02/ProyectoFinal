using Microsoft.EntityFrameworkCore;
using MvcCentroPsicopedagogico.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Agregar servicios de sesión
builder.Services.AddSession(); // ← AGREGÁ ESTA LÍNEA
builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/Login/Login"; // Redirige acá si no está autenticado
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ✅ Habilitar el middleware de sesión
app.UseSession(); // ← AGREGÁ ESTA LÍNEA ANTES de Authorization
app.UseAuthentication(); // ✅ luego autenticación
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
