using System;
using System.Collections.Generic;

namespace ASPProjectManagementDb
{
    public partial class Employee
    {
        public Employee()
        {
            TeamMembers = new HashSet<TeamMember>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public int ProfessionId { get; set; }

        public virtual Profession Profession { get; set; }
        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
}
