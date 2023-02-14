using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ToDoApplication
{
    /// <summary>
    /// Interaction logic for NewTaskWindow.xaml
    /// </summary>
    public partial class NewTaskWindow : Window
    {

        public Task Result { get; set; }

        public NewTaskWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (NameTextBox.Text.Length == 0)
            {
                NameTextBox.BorderBrush = Brushes.Red;
                return;
            }

            Result = new Task(NameTextBox.Text, DescriptionTextBox.Text, IsCompletedCheckBox.IsChecked.Value);
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            NameTextBox.BorderBrush = Brushes.Gray;
        }
    }
}
