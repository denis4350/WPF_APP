using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ProjectManager.Models;
using ProjectManager.Windows;

namespace ProjectManager
{
    public partial class ProjectsPage : Page
    {
        private ObservableCollection<Project> projects;

        public ProjectsPage(
            ObservableCollection<Project> projectCollection)
        {
            InitializeComponent();

            projects = projectCollection;

            ProjectsList.ItemsSource = projects;
        }

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            Window owner = System.Windows.Window.GetWindow(this);

            ProjectDialog dialog = new ProjectDialog();

            dialog.Owner = owner;

            bool? result = dialog.ShowDialog();

            if (result == true &&
                dialog.CreatedProject != null)
            {
                Project project = dialog.CreatedProject;

                project.Id = GetNextProjectId();

                projects.Add(project);

                ProjectsList.ItemsSource = null;
                ProjectsList.ItemsSource = projects;
            }
        }

        private int GetNextProjectId()
        {
            int maxId = 0;

            foreach (Project project in projects)
            {
                if (project.Id > maxId)
                    maxId = project.Id;
            }

            return maxId + 1;
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button == null)
                return;

            Project project =
                button.DataContext as Project;

            if (project == null)
                return;

            MessageBox.Show(
                "Название: " + project.Name +
                "\n\nОписание: " + project.Description +
                "\n\nСтатус: " + project.Status +
                "\n\nПрогресс: " + project.Progress + "%" +
                "\n\nСрок: " +
                project.Deadline.ToShortDateString(),
                "Информация о проекте",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button == null)
                return;

            Project project =
                button.DataContext as Project;

            if (project == null)
                return;

            Window owner =
                System.Windows.Window.GetWindow(this);

            ProjectDialog dialog =
                new ProjectDialog(project);

            dialog.Owner = owner;

            bool? result =
                dialog.ShowDialog();

            if (result == true &&
                dialog.CreatedProject != null)
            {
                int index =
                    projects.IndexOf(project);

                if (index >= 0)
                {
                    projects[index] =
                        dialog.CreatedProject;
                }

                ProjectsList.ItemsSource = null;
                ProjectsList.ItemsSource = projects;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button == null)
                return;

            Project project =
                button.DataContext as Project;

            if (project == null)
                return;

            MessageBoxResult result =
                MessageBox.Show(
                    "Удалить проект \"" +
                    project.Name +
                    "\"?",
                    "Удаление проекта",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                projects.Remove(project);

                ProjectsList.ItemsSource = null;
                ProjectsList.ItemsSource = projects;
            }
        }
    }
}