using System.Text.Json.Serialization;

namespace Dkd.App.Admin.Application.Contracts.Dtos;

/// <summary>
/// Menu
/// </summary>
[Serializable]
public class MenuTreeDto : MenuDto
{
    /// <summary>
    /// Child menus
    /// </summary>
    [JsonPropertyOrder(100)]
    public List<MenuTreeDto> Children { get; set; } = [];
}
