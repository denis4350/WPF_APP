using System.Collections.ObjectModel;
using System.Windows.Controls;
using ProjectManager.Models;

namespace ProjectManager
{
    public partial class StatisticsPage : Page
    {
        public StatisticsPage(
            ObservableCollection<Project> projects,
            ObservableCollection<ProjectTask> tasks)
        {
            InitializeComponent();

            int totalProgress = 0;
            int completed = 0;

            foreach (Project project in projects)
            {
                totalProgress += project.Progress;

                if (project.Progress >= 100 ||
                    project.Status == "Завершён")
                {
                    completed++;
                }
            }

            int average = 0;

            if (projects.Count > 0)
                average = totalProgress / projects.Count;

            AverageProgressText.Text =
                average + "%";

            AverageProgressBar.Value =
                average;

            CompletedText.Text =
                completed.ToString();

            StatisticsList.ItemsSource =
                projects;
        }
    }
}