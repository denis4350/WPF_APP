using System;
using System.Windows;
using ProjectManager.Models;

namespace ProjectManager.Windows
{
    public partial class ProjectDialog : System.Windows.Window
    {
        public Project CreatedProject { get; private set; }

        public ProjectDialog()
        {
            InitializeComponent();
        }

        public ProjectDialog(Project project)
        {
            InitializeComponent();

            CreatedProject = project;

            ProjectNameTextBox.Text =
                project.Name;

            ProjectDescriptionTextBox.Text =
                project.Description;

            Title = "Изменение проекта";
        }

        private void Create_Click(
            object sender,
            RoutedEventArgs e)
        {
            string name =
                ProjectNameTextBox.Text.Trim();

            string description =
                ProjectDescriptionTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                HandyControl.Controls.MessageBox.Warning(
                    "Необходимо указать название проекта",
                    "Предупреждение");

                return;
            }

            if (CreatedProject == null)
            {
                CreatedProject = new Project();
            }

            CreatedProject.Name = name;

            CreatedProject.Description =
                description;

            CreatedProject.Status =
                "В работе";

            if (CreatedProject.Progress == 0)
            {
                CreatedProject.Progress = 0;
            }

            if (CreatedProject.Deadline == DateTime.MinValue)
            {
                CreatedProject.Deadline =
                    DateTime.Now.AddDays(30);
            }

            DialogResult = true;
        }

        private void Cancel_Click(
            object sender,
            RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}