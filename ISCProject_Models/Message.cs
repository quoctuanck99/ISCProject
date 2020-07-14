using System;
using System.Collections.Generic;

namespace ISCProject_Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public int? ParticipantId { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Participant Participant { get; set; }
    }
}
