using System;
using System.Collections.Generic;

namespace ISCProject_Models
{
    public partial class Report
    {
        public Report()
        {
            ReportPost = new HashSet<ReportPost>();
            ReportUser = new HashSet<ReportUser>();
        }

        public int ReportId { get; set; }
        public int AccountId { get; set; }
        public string Reason { get; set; }
        public bool IsClosed { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual User Account { get; set; }
        public virtual ICollection<ReportPost> ReportPost { get; set; }
        public virtual ICollection<ReportUser> ReportUser { get; set; }
    }
}
