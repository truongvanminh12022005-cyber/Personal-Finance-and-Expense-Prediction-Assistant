using Fepa.Application.Interfaces;
using Fepa.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Fepa.Application.Services
{
    /*
    public class RoleService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<RoleService> _logger;

        // Roles: Admin, Premium, User, Guest
        private static readonly Dictionary<string, List<string>> RolePermissions = new()
        {
            { "Admin", new List<string> { "read", "write", "delete", "manage_users", "view_reports" } },
            { "Premium", new List<string> { "read", "write", "delete", "view_reports" } },
            { "User", new List<string> { "read", "write", "delete" } },
            { "Guest", new List<string> { "read" } }
        };

        public RoleService(IUserRepository userRepository, ILogger<RoleService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        // public async Task<string> GetUserRoleAsync(Guid userId)
        // {
        //     var user = await _userRepository.GetByIdAsync(userId);
        //     if (user == null)
        //         throw new InvalidOperationException("Người dùng không tồn tại");

        //     return user.Role ?? "User";  // Default role: User
        // }

        // public async Task AssignRoleAsync(Guid userId, string role)
        // {
        //     if (!RolePermissions.ContainsKey(role))
        //         throw new InvalidOperationException("Role không hợp lệ");

        //     var user = await _userRepository.GetByIdAsync(userId);
        //     if (user == null)
        //         throw new InvalidOperationException("Người dùng không tồn tại");

        //     user.Role = role;
        //     await _userRepository.UpdateAsync(user);
        //     _logger.LogInformation($"Assigned role {role} to user {userId}");
        // }

        // public async Task RemoveRoleAsync(Guid userId)
        // {
        //     var user = await _userRepository.GetByIdAsync(userId);
        //     if (user == null)
        //         throw new InvalidOperationException("Người dùng không tồn tại");

        //     user.Role = "User";  // Reset to default role
        //     await _userRepository.UpdateAsync(user);
        //     _logger.LogInformation($"Removed role for user {userId}");
        // }

        // public async Task<bool> HasPermissionAsync(Guid userId, string permission)
        // {
        //     var userRole = await GetUserRoleAsync(userId);
        //     if (!RolePermissions.TryGetValue(userRole, out var permissions))
        //         return false;

        //     return permissions.Contains(permission);
        // }

        // public List<string> GetRolePermissions(string role)
        // {
        //     return RolePermissions.TryGetValue(role, out var permissions)
        //         ? permissions
        //         : new List<string>();
        // }
    }
    */
}
