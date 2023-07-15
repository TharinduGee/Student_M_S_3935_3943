using CommunityToolkit.Mvvm.ComponentModel;
using Student_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Add_New_User.xaml
    /// </summary>
    public partial class Add_New_Student : Window {
        public Add_New_Student() {
            DataContext = new AddNewStudent_WindowVM();
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

        private void getselecteddata(object sender, SelectionChangedEventArgs e) {
            DataGrid dg = (DataGrid)sender;
            var selectedstudent = dg.SelectedValue as Student;
            if (selectedstudent != null) {
                selectedid.Text = selectedstudent.Id.ToString();
                //selectedfirstname.Text = selectedstudent.FirstName.ToString();
            }
            else {
                selectedid.Text = "Not working";
            }
        }

        
    }
}
