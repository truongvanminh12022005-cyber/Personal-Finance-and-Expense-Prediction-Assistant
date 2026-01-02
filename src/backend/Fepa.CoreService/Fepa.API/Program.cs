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

Console.WriteLine("--> PHIEN BAN: AUTO RESET & SEED ADMIN <--");

// 1. CORS
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Database
builder.Services.AddDbContext<FepaDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. DI (Dependency Injection)
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
builder.Services.AddScoped<IVerificationTokenRepository, VerificationTokenRepository>();
builder.Services.AddScoped<ITokenService>(p => new TokenService(builder.Configuration, p.GetRequiredService<IUserRepository>()));
builder.Services.AddScoped<IEmailService>(p => new EmailService(builder.Configuration, p.GetRequiredService<ILogger<EmailService>>()));
builder.Services.AddScoped<IOtpService, OtpService>();
builder.Services.AddScoped<EmailVerificationService>();
builder.Services.AddScoped<PasswordResetService>();
builder.Services.AddScoped<RefreshTokenService>();
builder.Services.AddScoped<GoogleOAuthService>();
builder.Services.AddScoped<FacebookOAuthService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddHttpClient();

// 4. JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters {
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

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// 5. AUTO RESET & SEED
using (var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<FepaDbContext>();
    try {
        Console.WriteLine("--> DANG LAM SACH DATABASE...");
        // Xóa sạch user cũ bị lỗi format mật khẩu
        await context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE \"Users\" RESTART IDENTITY CASCADE;");
        // Tạo lại admin chuẩn
        await DbInitializer.SeedAsync(services);
    } catch (Exception ex) {
        Console.WriteLine("--> LOI DB: " + ex.Message);
    }
}

app.Run();