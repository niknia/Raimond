    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// curclassesDto
    /// </summary>
    [Serializable()]
    public class CurClassesCreationDto : InputDto
     {
                 public long CourseId { get; set; }
        public long Createby { get; set; }
        public DateTime Createtime { get; set; }
        public DateTime? EndDate { get; set; }
        public int? MaxStudents { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
        public DateTime? StartDate { get; set; }
        public string? Status { get; set; }
        public long TeacherId { get; set; }
     }
    