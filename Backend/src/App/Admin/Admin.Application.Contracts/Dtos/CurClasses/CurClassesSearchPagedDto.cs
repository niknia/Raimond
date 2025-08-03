    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curclassesDto
    /// </summary>
    [Serializable()]
    public class CurClassesSearchPagedDto : SearchPagedDto
     {
                 public long CourseId { get; set; }
        public DateTime? EndDate { get; set; }
        public int? MaxStudents { get; set; }
        public DateTime? StartDate { get; set; }
        public string? Status { get; set; }
        public long TeacherId { get; set; }
     }
