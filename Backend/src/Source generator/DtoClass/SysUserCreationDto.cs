    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// sysuserDto
    /// </summary>
    [Serializable()]
    public class SysUserCreationDto : InputDto
     {
             /// <summary>
        /// Account
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// Avatar Path
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// Birthday
        /// </summary>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// Creator
        /// </summary>
        public long Createby { get; set; }
        /// <summary>
        /// Creation Time/Registration Time
        /// </summary>
        public DateTime Createtime { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        public string? FkMenu { get; set; }
        /// <summary>
        /// Department ID
        /// </summary>
        public long FkOrganization { get; set; }
        public string? FkRole { get; set; }
        public long? FkUserType { get; set; }
        /// <summary>
        /// Gender
        /// </summary>
        public int Gender { get; set; }
        public bool IsConfirmed { get; set; }
        /// <summary>
        /// Mobile Number
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// Last Updated By
        /// </summary>
        public long Modifyby { get; set; }
        /// <summary>
        /// Last Update Time
        /// </summary>
        public DateTime Modifytime { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        public string? NationalCode { get; set; }
        public string? OtpToken { get; set; }
        public DateTime? Otpvalidto { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Password Salt
        /// </summary>
        public string Salt { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        public bool Status { get; set; }
     }
    