namespace Dkd.Shared.Application.Contracts.Dtos;

public static class SearchPagedDtoExtension
{
    /// <summary>
    /// Calculate the number of rows to skip for the query
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static int SkipRows(this SearchPagedDto dto) => (dto.PageIndex - 1) * dto.PageSize;
}
