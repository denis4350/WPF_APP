using System.Collections.ObjectModel;
using System.Windows.Controls;
using ProjectManager.Models;

namespace ProjectManager
{
    public partial class HomePage : Page
    {
        public HomePage(
            ObservableCollection<Project> projects,
            ObservableCollection<ProjectTask> tasks)
        {
            InitializeComponent();

            ProjectsCountText.Text = projects.Count.ToString();
            TasksCountText.Text = tasks.Count.ToString();

            int completed = 0;

            foreach (Project project in projects)
            {
                if (project.Progress >= 100 ||
                    project.Status == "Завершён")
                {
                    completed++;
                }
            }

            CompletedCountText.Text = completed.ToString();

            ProjectsList.ItemsSource = projects;
        }
    }
}