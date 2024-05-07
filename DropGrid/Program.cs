using DropGrid.Middleware;
using DropGrid.Services;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllersWithViews();

services.AddSingleton<IGameCacheService, GameCacheService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(ep =>
{
    ep.MapControllers();
});

app.MapWhen(context => context.Request.Path.StartsWithSegments("/api"), builder =>
{
    builder.UseMiddleware<SampleApiKeyMiddleware>();
});

app.Run();
