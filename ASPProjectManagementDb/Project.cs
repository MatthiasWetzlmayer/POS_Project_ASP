using System;
using System.Collections.Generic;

namespace ASPProjectManagementDb
{
    public partial class Project
    {
        public Project()
        {
            TeamMembers = new HashSet<TeamMember>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectTypeId { get; set; }

        public virtual ProjectType ProjectType { get; set; }
        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
}
