using System;
using System.Collections.Generic;

namespace ISCProject_API.Models
{
    public partial class Follow
    {
        public int AccountId { get; set; }
        public int FollowingId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Account Following { get; set; }
    }
}
