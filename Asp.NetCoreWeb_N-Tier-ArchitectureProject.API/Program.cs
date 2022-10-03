using Asp.NetCoreWeb_N_Tier_ArchitectureProject.API.Filters;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories.Categories;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories.Products;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories.Repositories;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories.Repositories.Categories;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories.Repositories.Products;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories.UnitofWorks;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Service.Mapping;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Service.Services;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Service.Services.Categories;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Service.Services.Products;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Service.Validation;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Services;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.UnitofWorks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ValidateFilterAttribute());
}).AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<ProductDTOValidator>());

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitofWork, UnitofWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddDbContext<AppDBContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
    {
        options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDBContext))?.GetName().Name);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
