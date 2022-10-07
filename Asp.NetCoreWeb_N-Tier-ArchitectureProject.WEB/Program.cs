using Autofac.Extensions.DependencyInjection;
using Autofac;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.WEB.Modules;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories;
using Microsoft.EntityFrameworkCore;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Service.Mapping;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddDbContext<AppDBContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
    {
        options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDBContext))?.GetName().Name);
    });
});


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new RepoServiceModule());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
