using System;
using System.Collections.Generic;

namespace ISCProject_Models
{
    public partial class Ads
    {
        public int PostId { get; set; }
        public int AgeFrom { get; set; }
        public int AgeTo { get; set; }

        public virtual Post Post { get; set; }
    }
}
