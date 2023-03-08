using FluentValidation;
using StudentAttendance.Api.Controllers.Users.Dto;
using StudentAttendance.Core.Domains.Users.Services;

namespace StudentAttendance.Api.Validators;

public class CreateUserValidator : AbstractValidator<UserRequest>
{
    public CreateUserValidator(IUserService userService)
    {
        RuleFor(it => it.Email)
            .NotEmpty()
            .EmailAddress();
        RuleFor(it => it.Role)
            .NotEmpty();
        RuleFor(x => x)
            .Must(user =>userService.GetUserByEmail(user.Email).Result==null!)
            .WithMessage("Email: Пользователь с таким email уже существует");
    }
}