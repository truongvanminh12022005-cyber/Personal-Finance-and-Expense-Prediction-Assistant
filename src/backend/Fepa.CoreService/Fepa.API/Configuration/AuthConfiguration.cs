using Microsoft.Extensions.DependencyInjection;
using Fepa.Application.Interfaces;
using Fepa.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Fepa.API.Configuration
{
    public static class AuthConfiguration
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Email Service Configuration
            services.AddScoped<IEmailService>(provider =>
                new EmailService(configuration, provider.GetRequiredService<ILogger<EmailService>>()));

            // OTP Service Configuration
            services.AddScoped<IOtpService, OtpService>();

            // Token Service Configuration (ĐÃ SỬA LẠI: CHỈ TRUYỀN 2 THAM SỐ)
            var jwtKey = configuration["Jwt:Key"] ?? "";
            var jwtIssuer = configuration["Jwt:Issuer"];
            var jwtAudience = configuration["Jwt:Audience"];

            services.AddScoped<ITokenService>(provider =>
                new TokenService(
                    configuration,
                    provider.GetRequiredService<IUserRepository>()
                    // Đã xóa dòng Logger vì TokenService của bạn không cần nó
                ));

            // JWT Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                        ValidateIssuer = true,
                        ValidIssuer = jwtIssuer,
                        ValidateAudience = true,
                        ValidAudience = jwtAudience,
                        ValidateLifetime = true
                    };
                });

            // Authorization Policies
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("PremiumUser", policy => policy.RequireRole("Premium", "Admin"));
                options.AddPolicy("VerifiedEmail", policy => policy.RequireClaim("EmailVerified", "true"));
            });

            return services;
        }
    }
}