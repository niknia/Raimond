namespace Dkd.App.Admin.Application.Contracts.DtoValidators;

public class RoleUpdationDtoValidator : AbstractValidator<RoleUpdationDto>
{
    public RoleUpdationDtoValidator()
    {
        Include(new RoleCreationDtoValidator());
    }
}
