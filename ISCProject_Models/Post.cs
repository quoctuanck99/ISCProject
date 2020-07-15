using System;
using System.Collections.Generic;

namespace ISCProject_Models
{
    public partial class Post
    {
        public Post()
        {
            Comment = new HashSet<Comment>();
            FavoritePost = new HashSet<FavoritePost>();
            PostImage = new HashSet<PostImage>();
            PostTag = new HashSet<PostTag>();
            PostVideo = new HashSet<PostVideo>();
            ReportPost = new HashSet<ReportPost>();
        }

        public int PostId { get; set; }
        public int? AccountId { get; set; }
        public string Description { get; set; }
        public int NumbFavorite { get; set; }
        public DateTime DateCreated { get; set; }
        public string Checkin { get; set; }
        public bool IsAds { get; set; }

        public virtual User Account { get; set; }
        public virtual Ads Ads { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<FavoritePost> FavoritePost { get; set; }
        public virtual ICollection<PostImage> PostImage { get; set; }
        public virtual ICollection<PostTag> PostTag { get; set; }
        public virtual ICollection<PostVideo> PostVideo { get; set; }
        public virtual ICollection<ReportPost> ReportPost { get; set; }
    }
}
