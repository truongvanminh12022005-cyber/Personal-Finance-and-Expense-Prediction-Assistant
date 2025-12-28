using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using Fepa.Application.DTOs.Auth;
using Fepa.Application.Interfaces;
using Fepa.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Fepa.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration; 

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            // Kiểm tra email
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
            {
                throw new Exception("Email này đã được sử dụng.");
            }

            // Mã hóa mật khẩu
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // Tạo User mới
            var newUser = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = passwordHash,
                Role = "User"
            };

            // Lưu vào DB
            await _userRepository.AddAsync(newUser);
        }

        // CHỨC NĂNG ĐĂNG NHẬP 
        public async Task<string> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            
            if (user == null || user.PasswordHash != request.Password)
            {
                throw new Exception("Tài khoản hoặc mật khẩu không đúng.");
            }
            

            return GenerateJwtToken(user);
        }
        //  HÀM TẠO TOKEN 
        private string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

            // Tạo các thông tin đính kèm vào vé (Claims)
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            // Cấu hình chữ ký số
            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            // Tạo Token
            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(3), // Token hết hạn sau 3 tiếng
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}