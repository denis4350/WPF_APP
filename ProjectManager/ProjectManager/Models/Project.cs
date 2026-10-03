using System;

namespace ProjectManager.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public int Progress { get; set; }

        public DateTime Deadline { get; set; }

        public Project()
        {
            Name = "";
            Description = "";
            Status = "В работе";
            Progress = 0;
            Deadline = DateTime.Now.AddDays(30);
        }
    }
}