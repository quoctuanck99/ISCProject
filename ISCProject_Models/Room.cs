using System;
using System.Collections.Generic;

namespace ISCProject_Models
{
    public partial class Room
    {
        public Room()
        {
            Participant = new HashSet<Participant>();
        }

        public int RoomId { get; set; }
        public string RoomName { get; set; }

        public virtual ICollection<Participant> Participant { get; set; }
    }
}
