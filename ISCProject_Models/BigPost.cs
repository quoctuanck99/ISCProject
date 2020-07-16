using System;
using System.Collections.Generic;
using System.Text;

namespace ISCProject_Models
{
    public class BigPost
    {
        public int PostId { get; set; }
        public string Avatar { get; set; }
        public string Username { get; set; }
        public string Checkin { get; set; }
        public int AccountId { get; set; }
        public string Description { get; set; }
        public bool IsFavorite { get; set; }
        public DateTime DateCreated { get; set; }
        public List<Image> Images { get; set; }
        public List<Comment> Comments { get; set; }
        public List<HashTag> hashTags { get; set; }
    }
}
