using EFCore.Controllers;
using EFCore.Services;
using Microsoft.EntityFrameworkCore;
// using EFCore.Data; // Nhớ check namespace của AppDbContext

var builder = WebApplication.CreateBuilder(args);

// 1. Đọc Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Đăng ký DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// ==================================================
// 👇 PHẦN BỔ SUNG QUAN TRỌNG ĐỂ CHẠY SWAGGER 👇
// ==================================================

// Đăng ký Controllers (API)
builder.Services.AddControllers();

// Đăng ký Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ==================================================

// Đăng ký Razor Pages (nếu bạn vẫn muốn giữ)
builder.Services.AddRazorPages();

// Đăng ký ProductService
builder.Services.AddScoped<ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// ==================================================
// 👇 KÍCH HOẠT SWAGGER UI 👇
// ==================================================
// Luôn bật Swagger (hoặc chỉ bật khi IsDevelopment tuỳ bạn)
app.UseSwagger();
app.UseSwaggerUI();
// ==================================================

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers(); // Map các API Controller

app.Run();