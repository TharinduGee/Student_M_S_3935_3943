using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

namespace Student_Management_System.Normal_User {
    /// <summary>
    /// Interaction logic for Normal_User_Main_Window.xaml
    /// </summary>
    public partial class Normal_User_Main_Window : Window {
        public Normal_User_Main_Window() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            var Add_new_User = new Add_New_Student();
            Add_new_User.Show();
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            var ModuleWindow = new ModuleOperations();
            ModuleWindow.Show();
        }


        private void Button_Click3(object sender, RoutedEventArgs e) {
            var AddModulestudentWindow = new Add_Modules_To_Student();
            AddModulestudentWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var Add_GradesWindow =  new Add_Grades();
            Add_GradesWindow.Show();
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Drag(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
