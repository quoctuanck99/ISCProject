using System;
using System.Collections.Generic;

namespace ISCProject_API.Models
{
    public partial class PostImage
    {
        public int PostId { get; set; }
        public int ImageId { get; set; }

        public virtual Image Image { get; set; }
        public virtual Post Post { get; set; }
    }
}
