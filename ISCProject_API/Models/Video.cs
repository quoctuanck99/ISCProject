using System;
using System.Collections.Generic;

namespace ISCProject_API.Models
{
    public partial class Video
    {
        public Video()
        {
            PostVideo = new HashSet<PostVideo>();
        }

        public int VideoId { get; set; }
        public string VideoName { get; set; }
        public DateTime DateUploaded { get; set; }

        public virtual ICollection<PostVideo> PostVideo { get; set; }
    }
}
