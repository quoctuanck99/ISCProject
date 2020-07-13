using System;
using System.Collections.Generic;

namespace ISCProject_API.Models
{
    public partial class AccountRole
    {
        public int AccountId { get; set; }
        public int RoleId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Role Role { get; set; }
    }
}
