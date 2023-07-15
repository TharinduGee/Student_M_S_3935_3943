using Student_Management_System.Admin_User;
using Student_Management_System.Normal_User;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Student_Management_System {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            string username = UsernameText.Text;
            string password = PasswordText.Password;
            string usertype = UserTypeText.Text;

            using (DatabaseContext context = new DatabaseContext()) {
                bool userFound = context.Login.Any(LoginDetails => LoginDetails.Username == username && LoginDetails.Password == password && LoginDetails.UserType == usertype);

                if (userFound) {
                    GrantAccess();
                    //Close();
                }

                else {
                    MessageBox.Show("User not Found!", "Invalid User");
                }
            }
        }
        private void Drag(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void GrantAccess() {
            if (UserTypeText.Text == "Normal User") {
                var Window = new Normal_User_Main_Window();
                Window.Show();
            }

            else {
                var window = new AdminUserWindow();
                window.Show();
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WindowState= WindowState.Minimized;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
