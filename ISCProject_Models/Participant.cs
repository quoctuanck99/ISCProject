using System;
using System.Collections.Generic;

namespace ISCProject_Models
{
    public partial class Participant
    {
        public Participant()
        {
            Message = new HashSet<Message>();
        }

        public int ParticipantId { get; set; }
        public int? AccountId { get; set; }
        public int? RoomId { get; set; }
        public string NickName { get; set; }

        public virtual User Account { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<Message> Message { get; set; }
    }
}
