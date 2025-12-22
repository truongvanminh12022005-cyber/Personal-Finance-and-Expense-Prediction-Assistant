using Fepa.Application.DTOs.Auth;
using Fepa.Application.Interfaces;
using Fepa.Domain.Entities;

namespace Fepa.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            // 1. Kiểm tra email đã tồn tại chưa
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
            {
                throw new Exception("Email này đã được sử dụng.");
            }

            // 2. Mã hóa mật khẩu
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // 3. Tạo User mới
            var newUser = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = passwordHash,
                Role = "User"
            };

            // 4. Lưu vào DB
            await _userRepository.AddAsync(newUser);
        }
    }
}