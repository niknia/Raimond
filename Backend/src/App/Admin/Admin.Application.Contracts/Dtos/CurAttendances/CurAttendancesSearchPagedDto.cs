    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curattendancesDto
    /// </summary>
    [Serializable()]
    public class CurAttendancesSearchPagedDto : SearchPagedDto
     {
                 public long ClassId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime SessionDate { get; set; }
        public string? Status { get; set; }
        public long StudentId { get; set; }
        public DateTime? UpdatedAt { get; set; }
     }
