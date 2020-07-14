using System;
using System.Collections.Generic;
using System.Text;

namespace ISCProject_Models
{
    public class Profile
    {
        public int NumPost { get; set; }
        public int NumFollowing { get; set; }
        public int NumFollower { get; set; }
        public string Info { get; set; }
        public string Username { get; set; }
        public bool IsFollowing { get; set; }
    }
}
