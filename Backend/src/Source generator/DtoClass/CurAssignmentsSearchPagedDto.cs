    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// curassignmentsDto
    /// </summary>
    [Serializable()]
    public class CurAssignmentsSearchPagedDto : SearchPagedDto
     {
                 public long ClassId { get; set; }
        public long Createby { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime Createtime { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public int? MaxScore { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
        public string? Title { get; set; }
     }
    