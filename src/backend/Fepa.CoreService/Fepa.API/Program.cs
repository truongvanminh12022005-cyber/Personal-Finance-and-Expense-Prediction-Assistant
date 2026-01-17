using Fepa.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Fepa.Application.Interfaces;
using Fepa.Application.Services;
using Fepa.Infrastructure.Repositories;
using Fepa.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("--> PHIEN BAN CODE MOI: FIX CORS (ALLOW PORT 3000) <--");

// -----------------------------------------------------------------------------
// 1. Cấu hình CORS (QUAN TRỌNG: Sửa lại để chấp nhận React App)
// -----------------------------------------------------------------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Chỉ định rõ nguồn Frontend
              .AllowAnyMethod()                     // Cho phép GET, POST, PUT, DELETE...
              .AllowAnyHeader();                    // Cho phép gửi Token (Authorization)
    });
});

// 2. Đăng ký các dịch vụ cơ bản
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3. Đăng ký kết nối Database
builder.Services.AddDbContext<FepaDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 4. Đăng ký Dependency Injection (DI)
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();

// 5. Đăng ký Auth Services (JWT, Email, OTP...)
builder.Services.AddAuthServices(builder.Configuration);

// Đăng ký Logic chính
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// --- Cấu hình Pipeline (Middleware) ---

// 1. Swagger (Tài liệu API)
if (app.Environment.IsDevelopment() || app.Environment.IsProduction()) // Cho hiện cả lúc chạy Docker
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 2. Kích hoạt CORS (Phải đặt TRƯỚC Authentication)
app.UseCors("AllowReactApp");

// 3. Xác thực & Phân quyền
app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

// --- Data Seeding (Tạo dữ liệu mẫu) ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<FepaDbContext>();
        // Tự động tạo bảng
        context.Database.Migrate();

        // Tự động tạo Admin
        await DbInitializer.SeedAsync(services);
    }
    catch (Exception ex)
    {
        Console.WriteLine("--> LOI KHI KHOI TAO DATABASE: " + ex.Message);
    }
}

app.Run();