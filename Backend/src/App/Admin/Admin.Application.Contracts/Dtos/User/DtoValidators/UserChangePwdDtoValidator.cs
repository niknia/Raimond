namespace Dkd.App.Admin.Application.Contracts.DtoValidators;

public class UserChangePwdDtoValidator : AbstractValidator<UserProfileChangePwdDto>
{
    public UserChangePwdDtoValidator()
    {
        RuleFor(x => x.OldPassword).NotEmpty();
        RuleFor(x => x.NewPassword).NotEmpty().Length(5, UserConsts.Password_Maxlength);
        RuleFor(x => x.ConfirmPassword).NotEmpty().Length(5, UserConsts.Password_Maxlength)
                                  .Must((dto, rePassword) =>
                                  {
                                      return dto.NewPassword == rePassword;
                                  })
                                  .WithMessage("Confirm password must match new password");
    }
}
