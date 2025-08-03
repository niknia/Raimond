    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curusersDto
    /// </summary>
    [Serializable()]
    public class CurUsersSearchPagedDto : SearchPagedDto
     {
        public DateTime? CreatedAt { get; set; }
        public string? Email { get; set; }
        public string? EmployeeNumber { get; set; }
        public string FullName { get; set; }
        public string? NationalCode { get; set; }
        public long? OrganizationId { get; set; }
        public string? Phone { get; set; }
        public string Role { get; set; }
        public string? Status { get; set; }
        public DateTime? UpdatedAt { get; set; }
     }
