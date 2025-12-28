/*using Fepa.Domain.Entities;

namespace Fepa.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task<IEnumerable<User>> GetAllAsync();
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
        Task<User?> GetByEmailAsync(string email);
    }
}
*/
using Fepa.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Fepa.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
        
        // --- BỔ SUNG HÀM NÀY ĐỂ TRÁNH LỖI ---
        Task<User?> GetByEmailAsync(string email);
    }
}