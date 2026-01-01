using FluentValidation;
using Fepa.Application.DTOs.Auth;

namespace Fepa.Application.Validators
{
    /*
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            // RuleFor(x => x.FullName)
            //     .NotEmpty().WithMessage("Tên không được để trống")
            //     .MinimumLength(3).WithMessage("Tên phải ít nhất 3 ký tự")
            //     .MaximumLength(100).WithMessage("Tên không được vượt quá 100 ký tự");

            // RuleFor(x => x.Email)
            //     .NotEmpty().WithMessage("Email không được để trống")
            //     .EmailAddress().WithMessage("Email không hợp lệ");

            // RuleFor(x => x.Password)
            //     .NotEmpty().WithMessage("Mật khẩu không được để trống")
            //     .MinimumLength(8).WithMessage("Mật khẩu phải ít nhất 8 ký tự")
            //     .Matches("[A-Z]").WithMessage("Mật khẩu phải có ít nhất 1 chữ cái viết hoa")
            //     .Matches("[0-9]").WithMessage("Mật khẩu phải có ít nhất 1 chữ số")
            //     .Matches("[!@#$%^&*]").WithMessage("Mật khẩu phải có ít nhất 1 ký tự đặc biệt (!@#$%^&*)");
        }
    }
    */

    /*
    public class PasswordValidator
    {
        // public bool IsValidPassword(string password)
        // {
        //     if (password?.Length < 8) return false;
        //     if (!password.Any(char.IsUpper)) return false;
        //     if (!password.Any(char.IsDigit)) return false;
        //     if (!password.Any(c => "!@#$%^&*".Contains(c))) return false;
        //     return true;
        // }
    }
    */
}
