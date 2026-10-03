using System.Collections.ObjectModel;
using System.Windows.Controls;
using ProjectManager.Models;

namespace ProjectManager
{
    public partial class TasksPage : Page
    {
        public TasksPage(
            ObservableCollection<ProjectTask> tasks)
        {
            InitializeComponent();

            TasksList.ItemsSource = tasks;
        }
    }
}