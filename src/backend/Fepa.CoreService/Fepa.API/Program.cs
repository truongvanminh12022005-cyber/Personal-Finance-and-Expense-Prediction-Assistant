using Fepa.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Fepa.Application.Interfaces;
using Fepa.Application.Services;
using Fepa.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("--> PHIEN BAN CODE MOI: CO DATA SEEDING (AUTO ADMIN) <--");

// 1. Cấu hình CORS (Cho phép Web Admin truy cập)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// 2. Đăng ký các dịch vụ (Services)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3. Đăng ký kết nối Database
builder.Services.AddDbContext<FepaDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 4. Đăng ký Dependency Injection (DI)
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();

// 5. Cấu hình xác thực bằng JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

var app = builder.Build();

// --- Cấu hình Pipeline (Middleware) ---

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); // Có thể comment lại nếu chạy Docker nội bộ bị lỗi SSL

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// --- PHẦN QUAN TRỌNG: TỰ ĐỘNG TẠO BẢNG & ADMIN ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        // Gọi hàm SeedAsync từ file DbInitializer.cs
        // Hàm này sẽ tự động: 
        // 1. Chạy Migration (Tạo bảng)
        // 2. Tạo Admin mặc định (admin@fepa.com / 123456)
        await DbInitializer.SeedAsync(services);
    }
    catch (Exception ex)
    {
        Console.WriteLine("--> LOI KHI KHOI TAO DATABASE: " + ex.Message);
    }
}
// --------------------------------------------------

app.Run();