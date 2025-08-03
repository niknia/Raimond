    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// curenrollmentsDto
    /// </summary>
    [Serializable()]
    public class CurEnrollmentsSearchPagedDto : SearchPagedDto
     {
                 public long ClassId { get; set; }
        public long Createby { get; set; }
        public DateTime Createtime { get; set; }
        public DateTime? EnrolledAt { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
        public string? Status { get; set; }
        public long StudentId { get; set; }
     }
    