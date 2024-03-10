using DreamsHub.Context;
using DreamsHub.Models.Infra.ControllerComponent;
using DreamsHub.Repository;
using DreamsHub.Repository.Interface;
using DreamsHub.Services;
using DreamsHub.Services.Interface;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddDbContext<ContextModel>(x => x.UseSqlServer(connectionString));

builder.Services.AddTransient<IViewRenderService, ViewRenderService>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<ITransacaoRepository, TransacaoRepository>();
builder.Services.AddTransient<ITransacaoService, TransacaoService>();
builder.Services.AddTransient<ICategoriaService, CategoriaService>();

WebApplication app = builder.Build();

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

app.Run();