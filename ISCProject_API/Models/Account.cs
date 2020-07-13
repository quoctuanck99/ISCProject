using System;
using System.Collections.Generic;

namespace ISCProject_API.Models
{
    public partial class Account
    {
        public Account()
        {
            AccountRole = new HashSet<AccountRole>();
            FollowAccount = new HashSet<Follow>();
            FollowFollowing = new HashSet<Follow>();
            ReportAccount = new HashSet<ReportAccount>();
        }

        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<AccountRole> AccountRole { get; set; }
        public virtual ICollection<Follow> FollowAccount { get; set; }
        public virtual ICollection<Follow> FollowFollowing { get; set; }
        public virtual ICollection<ReportAccount> ReportAccount { get; set; }
    }
}
