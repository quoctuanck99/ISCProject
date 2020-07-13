using System;
using System.Collections.Generic;

namespace ISCProject_API.Models
{
    public partial class HashTag
    {
        public HashTag()
        {
            PostTag = new HashSet<PostTag>();
        }

        public int TagId { get; set; }
        public string TagName { get; set; }

        public virtual ICollection<PostTag> PostTag { get; set; }
    }
}
