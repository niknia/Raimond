    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// sysmenuDto
    /// </summary>
    [Serializable()]
    public class SysMenuDto : OutputFullAuditInfoDto
     {
             /// <summary>
        /// Always Show Single Child Route
        /// </summary>
        public bool Alwaysshow { get; set; }
        /// <summary>
        /// Component Configuration
        /// </summary>
        public string Component { get; set; }
        /// <summary>
        /// Creator
        /// </summary>
        public long Createby { get; set; }
        /// <summary>
        /// Creation Time/Registration Time
        /// </summary>
        public DateTime Createtime { get; set; }
        /// <summary>
        /// Icon
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// Enable Page Cache
        /// </summary>
        public bool Keepalive { get; set; }
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
        /// <summary>
        /// Order Number
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// Route Parameters
        /// </summary>
        public string Params { get; set; }
        /// <summary>
        /// Parent Menu ID
        /// </summary>
        public long Parentid { get; set; }
        /// <summary>
        /// Parent Menu IDs
        /// </summary>
        public string Parentids { get; set; }
        /// <summary>
        /// Permission Code
        /// </summary>
        public string Perm { get; set; }
        /// <summary>
        /// Redirect Route Path
        /// </summary>
        public string Redirect { get; set; }
        /// <summary>
        /// Route Name
        /// </summary>
        public string Routename { get; set; }
        /// <summary>
        /// Route Path
        /// </summary>
        public string Routepath { get; set; }
        /// <summary>
        /// Menu Type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Is Visible
        /// </summary>
        public bool Visible { get; set; }
     }
    