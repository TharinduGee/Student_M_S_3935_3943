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

namespace Student_Management_System.Normal_User
{
    /// <summary>
    /// Interaction logic for Add_Grades.xaml
    /// </summary>
    public partial class Add_Grades : Window
    {
        public Add_Grades()
        {
            DataContext = new Add_GradesVM();   
            InitializeComponent();
        }

        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Status.Text = "Unsaved";
            Save_click.Content = "Save";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Save_click.Content = "Saved";
            Status.Text = "Saved";
        }

        private void Drag(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Application.Current.Shutdown();
            this.Close();
        }

    }
}
