using System;
using System.Collections.Generic;

namespace ISCProject_Models
{
    public partial class PostTag
    {
        public int PostId { get; set; }
        public int TagId { get; set; }

        public virtual Post Post { get; set; }
        public virtual HashTag Tag { get; set; }
    }
}
