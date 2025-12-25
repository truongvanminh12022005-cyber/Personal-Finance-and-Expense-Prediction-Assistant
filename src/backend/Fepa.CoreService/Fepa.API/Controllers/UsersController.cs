using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
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

        // LẤY DANH SÁCH
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        // XÓA USER
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userRepository.DeleteAsync(id);
            return NoContent(); 
        }

        // CREATE
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            // Kiểm tra xem email đã tồn tại chưa
            var existUser = await _userRepository.GetByEmailAsync(user.Email);
            if (existUser != null) return BadRequest("Email này đã có người dùng!");

            user.Id = Guid.NewGuid();
            
            await _userRepository.AddAsync(user);
            return Ok(user);
        }

        // UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, User user)
        {
            
            var existingUser = await _userRepository.GetByEmailAsync(user.Email); 
            
            if (existingUser == null) return NotFound();

            // Cập nhật tên mới
            existingUser.FullName = user.FullName;
            
            // Gọi lệnh lưu xuống Database
            await _userRepository.UpdateAsync(existingUser);
            return NoContent();
        }
    }
}