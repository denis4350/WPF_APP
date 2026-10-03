using System;

namespace ProjectManager.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Priority { get; set; }

        public string Status { get; set; }

        public DateTime Deadline { get; set; }

        public ProjectTask()
        {
            Name = "";
            Priority = "MEDIUM";
            Status = "В работе";
            Deadline = DateTime.Now.AddDays(7);
        }
    }
}