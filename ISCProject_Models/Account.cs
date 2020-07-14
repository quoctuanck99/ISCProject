using System;
using System.Collections.Generic;

namespace ISCProject_Models
{
    public partial class Account
    {
        public Account()
        {
            AccountRole = new HashSet<AccountRole>();
        }

        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<AccountRole> AccountRole { get; set; }
    }
}
