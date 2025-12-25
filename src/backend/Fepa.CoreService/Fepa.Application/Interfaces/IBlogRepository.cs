using Fepa.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Fepa.Application.Interfaces
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Blog>> GetAllAsync(); 
        Task<Blog?> GetByIdAsync(Guid id);     
        Task AddAsync(Blog blog);             
        Task UpdateAsync(Blog blog);           
        Task DeleteAsync(Guid id);             
    }
}