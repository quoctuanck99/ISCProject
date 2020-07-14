﻿using System;
using System.Collections.Generic;

namespace ISCProject_Models
{
    public partial class User
    {
        public User()
        {
            Comment = new HashSet<Comment>();
            FavoritePost = new HashSet<FavoritePost>();
            Participant = new HashSet<Participant>();
            Post = new HashSet<Post>();
            Report = new HashSet<Report>();
        }

        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
        public DateTime Dob { get; set; }
        public bool Gender { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
        public string Avatar { get; set; }
        public bool IsAgency { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<FavoritePost> FavoritePost { get; set; }
        public virtual ICollection<Participant> Participant { get; set; }
        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<Report> Report { get; set; }
    }
}
