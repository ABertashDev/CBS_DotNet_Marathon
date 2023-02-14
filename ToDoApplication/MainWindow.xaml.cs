using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

        private string fileName = "data.bin";

        ObservableCollection<Task> taskList = new ObservableCollection<Task>();

        public MainWindow()
        {
            InitializeComponent();

            //Task t1 = new Task("First task", "First task full description");
            //Task t2 = new Task("Second task", "Second task full description");
            //Task t3 = new Task("Third task", "Third task full description");

            //taskList.Add(t1);
            //taskList.Add(t2);
            //taskList.Add(t3);

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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NewTaskWindow window = new NewTaskWindow();
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            if (window.ShowDialog() == true)
            {
                taskList.Add(window.Result);  
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            int index = ToDoListBox.SelectedIndex;
            if (index != -1)
            {
                taskList.RemoveAt(index);
            }
        }

        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {
            int index = ToDoListBox.SelectedIndex;
            if (index != -1)
            {
                taskList[index].IsCompleted = !taskList[index].IsCompleted;
            }

            if (NotCompletedRadioButton.IsChecked.Value == true)
            {
                NotCompletedRadioButton_Checked(sender, e);
            }

            if (CompletedRadioButton.IsChecked.Value == true)
            {
                CompletedRadioButton_Checked(sender, e);
            }
        }

        private void AllRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ToDoListBox.ItemsSource = taskList;
            CompleteButton.Content = "Complete";
        }

        private void NotCompletedRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ToDoListBox.ItemsSource = taskList.Where(t => !t.IsCompleted);
            CompleteButton.Content = "Complete";
        }

        private void CompletedRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ToDoListBox.ItemsSource = taskList.Where(t => t.IsCompleted);
            CompleteButton.Content = "Restore";
        }

        private void Window_Closed(object sender, EventArgs e)
        {

            BinaryFormatter formatter = new BinaryFormatter();            
            Stream file = File.OpenWrite(fileName);
            formatter.Serialize(file, taskList);
            file.Close();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            if (File.Exists(fileName))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Stream file = File.OpenRead(fileName);
                taskList = formatter.Deserialize(file) as ObservableCollection<Task>;
                file.Close();
            }

            NotCompletedRadioButton.IsChecked = true;
            NotCompletedRadioButton_Checked(sender, e);

        }
    }
}
