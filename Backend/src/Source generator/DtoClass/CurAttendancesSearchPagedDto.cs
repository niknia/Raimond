    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// curattendancesDto
    /// </summary>
    [Serializable()]
    public class CurAttendancesSearchPagedDto : SearchPagedDto
     {
                 public long ClassId { get; set; }
        public long Createby { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime Createtime { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
        public DateTime SessionDate { get; set; }
        public string? Status { get; set; }
        public long StudentId { get; set; }
        public DateTime? UpdatedAt { get; set; }
     }
    