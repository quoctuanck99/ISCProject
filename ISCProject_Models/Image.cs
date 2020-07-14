using System;
using System.Collections.Generic;

namespace ISCProject_Models
{
    public partial class Image
    {
        public Image()
        {
            PostImage = new HashSet<PostImage>();
        }

        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public DateTime DateUploaded { get; set; }

        public virtual ICollection<PostImage> PostImage { get; set; }
    }
}
