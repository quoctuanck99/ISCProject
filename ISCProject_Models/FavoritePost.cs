using System;
using System.Collections.Generic;

namespace ISCProject_Models
{
    public partial class FavoritePost
    {
        public int PostId { get; set; }
        public int AccountId { get; set; }

        public virtual User Account { get; set; }
        public virtual Post Post { get; set; }
    }
}
