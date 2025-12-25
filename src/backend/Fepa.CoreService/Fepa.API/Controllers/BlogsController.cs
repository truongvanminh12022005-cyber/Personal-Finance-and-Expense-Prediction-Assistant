using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Fepa.Application.Interfaces;
using Fepa.Domain.Entities;

namespace Fepa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize] 
    public class BlogsController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;

        public BlogsController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        // Lấy danh sách
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await _blogRepository.GetAllAsync();
            return Ok(blogs);
        }

        // Lấy chi tiết 1 bài
        [HttpPut("{id}")]
public async Task<IActionResult> Update(Guid id, Blog blog)
{
    if (id != blog.Id) return BadRequest();

    
    var existingBlog = await _blogRepository.GetByIdAsync(id);
    if (existingBlog == null) return NotFound();

    existingBlog.Title = blog.Title;
    existingBlog.Content = blog.Content;
    existingBlog.ImageUrl = blog.ImageUrl;
    existingBlog.Author = blog.Author;
    
    await _blogRepository.UpdateAsync(existingBlog);
    return NoContent();
}

        // Thêm bài mới
        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            blog.Id = Guid.NewGuid(); 
            blog.CreatedAt = DateTime.UtcNow; 
            await _blogRepository.AddAsync(blog);
            return Ok(blog);
        }

        // Xóa bài
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _blogRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}