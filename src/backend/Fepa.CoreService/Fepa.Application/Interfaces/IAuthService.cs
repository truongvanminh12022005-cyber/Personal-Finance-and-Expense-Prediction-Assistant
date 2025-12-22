using Fepa.Application.DTOs.Auth;

namespace Fepa.Application.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterRequest request);
    }
}