
namespace Dkd.App.Admin.Application.Contracts.DtoValidators;
public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
{
    public UserRegisterDtoValidator()
    {
        RuleFor(x => x.Mobile)
            .NotEmpty().WithMessage("شماره موبایل نمی‌تواند خالی باشد")
            .NotNull().WithMessage("شماره موبایل نمی‌تواند خالی باشد")
            .Matches(@"^09[0-9]{9}$").WithMessage("فرمت شماره موبایل صحیح نیست"); // فرض بر اینکه شماره موبایل ایرانی است

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("نام نمی‌تواند خالی باشد")
            .NotNull().WithMessage("نام نمی‌تواند خالی باشد")
            .MinimumLength(2).WithMessage("نام باید حداقل 2 کاراکتر باشد");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("رمز عبور نمی‌تواند خالی باشد")
            .NotNull().WithMessage("رمز عبور نمی‌تواند خالی باشد")
            .MinimumLength(6).WithMessage("رمز عبور باید حداقل 6 کاراکتر باشد");

        RuleFor(x => x.RePassword)
            .NotEmpty().WithMessage("تکرار رمز عبور نمی‌تواند خالی باشد")
            .NotNull().WithMessage("تکرار رمز عبور نمی‌تواند خالی باشد");

        RuleFor(x => x)
            .Must(x => x.Password == x.RePassword)
            .WithMessage("رمز عبور و تکرار آن باید یکسان باشند");
    }
}
