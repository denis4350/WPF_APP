using ProjectManager.Models;
using ProjectManager.Windows;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProjectManager
{
    public partial class MainWindow : System.Windows.Window
    {
        private ObservableCollection<Project> projects;
        private ObservableCollection<ProjectTask> tasks;

        public MainWindow()
        {
            InitializeComponent();

            projects = new ObservableCollection<Project>();
            tasks = new ObservableCollection<ProjectTask>();

            LoadTestData();

            MainFrame.Navigate(new HomePage(projects, tasks));
        }

        private void LoadTestData()
        {
            projects.Add(new Project
            {
                Id = 1,
                Name = "Корпоративный портал",
                Description = "Разработка корпоративного портала",
                Status = "В работе",
                Progress = 75,
                Deadline = DateTime.Now.AddDays(15)
            });

            projects.Add(new Project
            {
                Id = 2,
                Name = "Мобильное приложение",
                Description = "Приложение для сотрудников",
                Status = "В работе",
                Progress = 45,
                Deadline = DateTime.Now.AddDays(30)
            });

            projects.Add(new Project
            {
                Id = 3,
                Name = "Система аналитики",
                Description = "Анализ и визуализация данных",
                Status = "Завершён",
                Progress = 100,
                Deadline = DateTime.Now.AddDays(-5)
            });

            tasks.Add(new ProjectTask
            {
                Id = 1,
                Name = "Разработать авторизацию",
                Priority = "HIGH",
                Status = "В работе",
                Deadline = DateTime.Now.AddDays(3)
            });

            tasks.Add(new ProjectTask
            {
                Id = 2,
                Name = "Создать главную страницу",
                Priority = "MEDIUM",
                Status = "Выполнено",
                Deadline = DateTime.Now.AddDays(-2)
            });

            tasks.Add(new ProjectTask
            {
                Id = 3,
                Name = "Провести тестирование",
                Priority = "LOW",
                Status = "Запланировано",
                Deadline = DateTime.Now.AddDays(7)
            });
        }

        private void Navigation_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button == null)
                return;

            string tag = button.Tag as string;

            if (tag == "Home")
            {
                PageTitle.Text = "Главная";
                PageDescription.Text = "Обзор текущего состояния проектов";

                MainFrame.Navigate(
                    new HomePage(projects, tasks));
            }
            else if (tag == "Projects")
            {
                PageTitle.Text = "Проекты";
                PageDescription.Text = "Управление проектами";

                MainFrame.Navigate(
                    new ProjectsPage(projects));
            }
            else if (tag == "Tasks")
            {
                PageTitle.Text = "Задачи";
                PageDescription.Text = "Список текущих задач";

                MainFrame.Navigate(
                    new TasksPage(tasks));
            }
            else if (tag == "Statistics")
            {
                PageTitle.Text = "Статистика";
                PageDescription.Text = "Анализ выполнения проектов";

                MainFrame.Navigate(
                    new StatisticsPage(projects, tasks));
            }
            else if (tag == "Settings")
            {
                PageTitle.Text = "Настройки";
                PageDescription.Text = "Настройки приложения";

                MainFrame.Navigate(
                    new SettingsPage());
            }
        }

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            ProjectDialog dialog = new ProjectDialog();
            dialog.Owner = this;

            bool? result = dialog.ShowDialog();

            if (result == true && dialog.CreatedProject != null)
            {
                Project project = dialog.CreatedProject;

                project.Id = GetNextProjectId();

                projects.Add(project);

                MainFrame.Navigate(
                    new ProjectsPage(projects));

                PageTitle.Text = "Проекты";
                PageDescription.Text = "Управление проектами";
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
 
            public void SetDarkTheme()
        {
            Background =
                new SolidColorBrush(
                    Color.FromRgb(30, 34, 40));

            MainFrame.Background =
                new SolidColorBrush(
                    Color.FromRgb(30, 34, 40));

            PageTitle.Foreground =
                new SolidColorBrush(Colors.White);

            PageDescription.Foreground =
                new SolidColorBrush(
                    Color.FromRgb(180, 185, 195));
        }

        public void SetLightTheme()
        {
            Background =
                new SolidColorBrush(
                    Color.FromRgb(244, 246, 248));

            MainFrame.Background =
                new SolidColorBrush(
                    Color.FromRgb(244, 246, 248));

            PageTitle.Foreground =
                new SolidColorBrush(
                    Color.FromRgb(32, 36, 43));

            PageDescription.Foreground =
                new SolidColorBrush(
                    Color.FromRgb(123, 132, 145));
        }
    }
}