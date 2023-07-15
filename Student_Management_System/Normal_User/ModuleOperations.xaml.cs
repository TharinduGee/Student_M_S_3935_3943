using Student_Management_System.Models;
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
    /// Interaction logic for ModuleOperations.xaml
    /// </summary>
    public partial class ModuleOperations : Window
    {
        public ModuleOperations()
        {
            DataContext = new ModuleOperations_WindowVM();
            InitializeComponent();
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
