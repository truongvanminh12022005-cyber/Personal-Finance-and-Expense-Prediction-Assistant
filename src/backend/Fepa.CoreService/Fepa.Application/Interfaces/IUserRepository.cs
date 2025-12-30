using Fepa.Domain.Entities;

namespace Fepa.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
        
        Task<User?> GetByEmailAsync(string email);
    }
}