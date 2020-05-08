using System;
using System.Collections.Generic;

namespace ASPProjectManagementDb
{
    public partial class ProjectType
    {
        public ProjectType()
        {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
