namespace Dkd.App.Admin.Application.Contracts.Dtos;

/// <summary>
/// Menu
/// </summary>
[Serializable]
public class MenuDto : MenuCreationDto
{
    /// <summary>
    /// Menu ID
    /// </summary>
    public long Id { get; set; }
}
