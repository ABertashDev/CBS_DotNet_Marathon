using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Task> taskList = new List<Task>();

        public MainWindow()
        {
            InitializeComponent();

            Task t1 = new Task("First task", "First task full description");
            Task t2 = new Task("Second task", "Second task full description");
            Task t3 = new Task("Third task", "Third task full description");

            taskList.Add(t1);
            taskList.Add(t2);
            taskList.Add(t3);

            ToDoListBox.ItemsSource = taskList;
            ToDoListBox.DisplayMemberPath = "Name";

        }

        private void ToDoListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            Task? selected = ToDoListBox.SelectedItem as Task;

            if (selected != null)
            {
                MessageBox.Show(selected.Description);
            }

        }
    }
}
