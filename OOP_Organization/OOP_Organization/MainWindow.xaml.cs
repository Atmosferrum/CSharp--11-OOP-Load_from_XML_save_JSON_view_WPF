using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OOP_Organization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string path = "new.xml"; //Path to Comapny DATA

        Repository repository; //Repository for Company DATA
        
        /// <summary>
        /// Main Initializator
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            repository = new Repository(path);

            ShowCompany(repository);
        }

        /// <summary>
        /// Method to show TreeView of a Comapny
        /// </summary>
        /// <param name="repository">Repository with Company DATA</param>
        private void ShowCompany(Repository repository)
        {
            Brush background = new LinearGradientBrush(Colors.Turquoise, Colors.Teal, 45);
            Brush border = new LinearGradientBrush(Colors.Teal, Colors.Turquoise, 45);
            TreeViewItem item = new TreeViewItem
            {
                Header = $"{repository.company.Name}" +
                         $"\nNumber of Employees : {repository.company.NumberOfEmployees}" +
                         $"\nNumber of Departments : {repository.company.NumberOfDepartments}",
                Background = background,
                HorizontalAlignment = HorizontalAlignment.Left,
                BorderThickness = new Thickness(5),
                BorderBrush = border,
                FontSize = 16
            };

            Main_Tree.Items.Add(item);

            if (repository.company.employees.Count > 0)
                ShowEmployee(repository.company.employees, item);

            if (repository.company.departments.Count > 0)                
                    ShowDepartment(repository.company.departments, item);
        }

        /// <summary>
        /// Method to ADD Employee to TreeView (Company version)
        /// </summary>
        /// <param name="employees">List of Employees to SHOW</param>
        /// <param name="treeView">TreeView to ADD Employees</param>
        private void ShowEmployee(List<Employee> employees, TreeView treeView)
        {
            Brush background = new LinearGradientBrush(Colors.DeepSkyBlue, Colors.Teal, 45);
            Brush border = new LinearGradientBrush(Colors.Teal, Colors.DeepSkyBlue, 45);

            foreach (Employee emply in employees)
            {
                TreeViewItem item = new TreeViewItem
                {
                    Header = $"{emply.Name} {emply.LastName} {emply.Age}" +
                             $"\n{emply.GetType().Name}" +
                             $"\n{emply.Salary}$" +
                             $"\nDays Worked : {emply.DaysWorked}",
                    Background = background,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    BorderThickness = new Thickness(5),
                    BorderBrush = border,
                    FontSize = 12,
                };

                treeView.Items.Add(item);
            }    
        }

        /// <summary>
        /// Method to ADD Employee to TreeViewItem (Departments version)
        /// </summary>
        /// <param name="employees">List of Employees to SHOW</param>
        /// <param name="treeViewItem">TreeViewItem to ADD Employees</param>
        private void ShowEmployee(List<Employee> employees, TreeViewItem treeViewItem)
        {
            Brush background = new LinearGradientBrush(Colors.DeepSkyBlue, Colors.Teal, 45);
            Brush border = new LinearGradientBrush(Colors.Teal, Colors.DeepSkyBlue, 45);
            foreach (Employee emply in employees)
            {
                if(emply is HeadOfDepartment)
                {
                    if (emply.Salary < 1300)
                        emply.Salary = 1300;
                }

                TreeViewItem item = new TreeViewItem
                {
                    Header = $"{emply.Name} {emply.LastName} {emply.Age}" +
                              $"\n{emply.GetType().Name}" +
                              $"\n{emply.Salary}$" +
                              $"\nDays Worked : {emply.DaysWorked}",
                    Background = background,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    BorderThickness = new Thickness(5),
                    BorderBrush = border,
                    FontSize = 12,
                };

                treeViewItem.Items.Add(item);
            }
        }

        /// <summary>
        /// Method to ADD Employee to TreeView (Comapny version)
        /// </summary>
        /// <param name="departments">List of Departments to SHOW</param>
        /// <param name="treeView">TreeView to ADD Department</param>
        private void ShowDepartment(List<Department> departments, TreeView treeView)
        {
            foreach (Department dept in departments)
            {
                Brush background = new LinearGradientBrush(Colors.Turquoise, Colors.Teal, 45);
                Brush border = new LinearGradientBrush(Colors.Teal, Colors.Turquoise, 45);
                TreeViewItem item = new TreeViewItem
                {
                    Header = $"{dept.Name}" +
                              $"\nNumber of Employees : {dept.NumberOfEmployees}" +
                              $"\nNumber of Departments : {dept.NumberOfDepartments}",
                    Background = background,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    BorderThickness = new Thickness(5),
                    BorderBrush = border,
                    FontSize = 16
                };

                if (dept.employees.Count > 0)
                    ShowEmployee(dept.employees, item);

                if (dept.departments.Count > 0)
                    ShowDepartment(dept.departments, item);

                treeView.Items.Add(item);
            }
        }

        /// <summary>
        /// Method to ADD Employee to TreeViewItem (Department version)
        /// </summary>
        /// <param name="departments">List of Departments to SHOW</param>
        /// <param name="treeViewItem">TreeViewItem to ADD Department</param>
        private void ShowDepartment(List<Department> departments, TreeViewItem treeViewItem)
        {
            foreach (Department dept in departments)
            {
                Brush background = new LinearGradientBrush(Colors.Turquoise, Colors.Teal, 45);
                Brush border = new LinearGradientBrush(Colors.Teal, Colors.Turquoise, 45);
                TreeViewItem item = new TreeViewItem
                {
                    Header = $"{dept.Name}" +
                              $"\nNumber of Employees : {dept.NumberOfEmployees}" +
                              $"\nNumber of Departments : {dept.NumberOfDepartments}",
                    Background = background,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    BorderThickness = new Thickness(5),
                    BorderBrush = border,
                    FontSize = 16
                };

                if (dept.employees.Count > 0)
                    ShowEmployee(dept.employees, item);

                if (dept.departments.Count > 0)
                    ShowDepartment(dept.departments, item);

                treeViewItem.Items.Add(item);
            }
        }
    }
}
