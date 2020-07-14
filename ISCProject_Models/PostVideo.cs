using System;
using System.Collections.Generic;

namespace ISCProject_Models
{
    public partial class PostVideo
    {
        public int PostId { get; set; }
        public int VideoId { get; set; }

        public virtual Post Post { get; set; }
        public virtual Video Video { get; set; }
    }
}
