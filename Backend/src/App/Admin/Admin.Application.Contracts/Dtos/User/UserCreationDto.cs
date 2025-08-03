namespace Dkd.App.Admin.Application.Contracts.Dtos;

public class UserCreationDto : UserCreationAndUpdationDto
{
    /// <summary>
    /// Account
    /// </summary>
    public string Account { get; set; } = string.Empty;
}
