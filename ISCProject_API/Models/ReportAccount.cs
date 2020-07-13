using System;
using System.Collections.Generic;

namespace ISCProject_API.Models
{
    public partial class ReportAccount
    {
        public int ReportId { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Report Report { get; set; }
    }
}
