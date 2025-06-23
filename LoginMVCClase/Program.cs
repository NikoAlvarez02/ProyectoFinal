var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddAuthentication("Cookies").AddCookie("Cookies", options =>
{
    options.LoginPath = "/Login/Login";
    options.AccessDeniedPath = "/Login/Login";

    options.ExpireTimeSpan = TimeSpan.FromMinutes(2);

    // Si querés que se renueve con cada request activa
    options.SlidingExpiration = true;
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
