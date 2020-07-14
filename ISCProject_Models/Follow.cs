﻿using System;
using System.Collections.Generic;

namespace ISCProject_Models
{
    public partial class Follow
    {
        public int AccountId { get; set; }
        public int FollowingId { get; set; }

        public virtual User Account { get; set; }
        public virtual User Following { get; set; }
    }
}
