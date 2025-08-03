    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curenrollmentsDto
    /// </summary>
    [Serializable()]
    public class CurEnrollmentsSearchPagedDto : SearchPagedDto
     {
                 public long ClassId { get; set; }
        
        public DateTime? EnrolledAt { get; set; }
        public string? Status { get; set; }
        public long StudentId { get; set; }
     }
