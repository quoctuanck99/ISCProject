using System;
using System.Collections.Generic;

namespace ISCProject_Models
{
    public partial class Report
    {
        public Report()
        {
            ReportAccount = new HashSet<ReportAccount>();
            ReportPost = new HashSet<ReportPost>();
        }

        public int ReportId { get; set; }
        public int? AccountId { get; set; }
        public string Reason { get; set; }
        public bool IsClosed { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual User Account { get; set; }
        public virtual ICollection<ReportAccount> ReportAccount { get; set; }
        public virtual ICollection<ReportPost> ReportPost { get; set; }
    }
}
