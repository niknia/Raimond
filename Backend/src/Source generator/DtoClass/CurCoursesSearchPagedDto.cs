    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// curcoursesDto
    /// </summary>
    [Serializable()]
    public class CurCoursesSearchPagedDto : SearchPagedDto
     {
                 public string? Code { get; set; }
        public long? CourseTypeId { get; set; }
        public long Createby { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime Createtime { get; set; }
        public string? Description { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
        public int? PracticalHours { get; set; }
        public string? Proposal { get; set; }
        public long? QualificationId { get; set; }
        public long? SpecializationId { get; set; }
        public long? TeachingMethodId { get; set; }
        public int? TheoreticalHours { get; set; }
        public string Title { get; set; }
     }
    