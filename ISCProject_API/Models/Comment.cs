using System;
using System.Collections.Generic;

namespace ISCProject_API.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int? PostId { get; set; }
        public int? AccountId { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual User Account { get; set; }
        public virtual Post Post { get; set; }
    }
}
