using System;
using System.Collections.Generic;

namespace ISCProject_API.Models
{
    public partial class ReportPost
    {
        public int ReportId { get; set; }
        public int PostId { get; set; }

        public virtual Post Post { get; set; }
        public virtual Report Report { get; set; }
    }
}
