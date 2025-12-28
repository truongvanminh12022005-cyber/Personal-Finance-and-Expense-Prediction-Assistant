using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization; // Chỉ giữ 1 dòng này thôi
using Fepa.Application.Interfaces;
using Fepa.Domain.Entities;

namespace Fepa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // 1. LẤY DANH SÁCH
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        // 2. XÓA USER
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userRepository.DeleteAsync(id);
            return NoContent();
        }

        // 3. TẠO MỚI (QUAN TRỌNG: Đã mở cửa cho người lạ)
        [HttpPost]
        [AllowAnonymous] 
        public async Task<IActionResult> Create(User user)
        {
            // Kiểm tra email trùng
            var existUser = await _userRepository.GetByEmailAsync(user.Email);
            if (existUser != null) return BadRequest("Email này đã có người dùng!");

            user.Id = Guid.NewGuid();
            await _userRepository.AddAsync(user);
            return Ok(user);
        }

        // 4. CẬP NHẬT
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, User user)
        {
            var existingUser = await _userRepository.GetByEmailAsync(user.Email);
            if (existingUser == null) return NotFound();

            existingUser.FullName = user.FullName;
            await _userRepository.UpdateAsync(existingUser);
            return NoContent();
        }
    }
}