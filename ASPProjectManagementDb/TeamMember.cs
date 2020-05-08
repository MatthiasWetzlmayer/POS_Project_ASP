using System;
using System.Collections.Generic;

namespace ASPProjectManagementDb
{
    public partial class TeamMember
    {
        public int Id { get; set; }
        public int SequenceNr { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
    }
}
