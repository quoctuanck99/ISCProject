using System;
using System.Collections.Generic;

namespace ISCProject_Models
{
    public partial class ReportUser
    {
        public int ReportId { get; set; }
        public int AccountId { get; set; }

        public virtual User Account { get; set; }
        public virtual Report Report { get; set; }
    }
}
