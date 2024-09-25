using ChocolateApp.Data;
using ChocolateApp.Data.Abstract;
using ChocolateApp.Data.Concrete.EfCore.Repositories;
using ChocolateApp.Entity.Concrete;
using ChocolateApp.Service.Abstract;
using ChocolateApp.Service.Concrete;
using ChocolateApp.Shared.Helpers.Abstract;
using ChocolateApp.Shared.Helpers.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using ChocolateApp.Api.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    
    options.JsonSerializerOptions.MaxDepth=64;
});
//builder.Services.AddDbContext<ChocolateAppDbContext>(options=>options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<ChocolateApp.Data.ChocolateAppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentityCore<CustomUserClass>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ChocolateApp.Data.ChocolateAppDbContext>();


builder.Services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
builder.Services.AddScoped<IChocolateRepository, EfCoreChocolateRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IChocolateService, ChocolateService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICartRepository, EfCoreCartRepository>();
builder.Services.AddScoped<IOrderRepository, EfCoreOrderRepository>();
builder.Services.AddScoped<IImageHelper, ImageHelper>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();