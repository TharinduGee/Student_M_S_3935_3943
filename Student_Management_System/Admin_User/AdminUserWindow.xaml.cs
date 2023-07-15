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

namespace Student_Management_System.Admin_User
{
    /// <summary>
    /// Interaction logic for AdminUserWindow.xaml
    /// </summary>
    public partial class AdminUserWindow : Window
    {
        //[ObservableProperty]
        //ObservableCollection<LoginDetails> Login;
        private AddNewUserWindowVM viewModel;
        public AdminUserWindow() {
            viewModel = new AddNewUserWindowVM();
            DataContext = viewModel;
            InitializeComponent();
            viewModel.LoadLoginDetails();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

            string username = UsernameText.Text;
            string password = PasswordText.Password;
            string usertype = "Normal User";



            LoginDetails d = new LoginDetails() {
                Username = username,
                Password = password,
                UserType = usertype
            };
            using (var db = new DatabaseContext()) {
                var newlogin = db.Login.FirstOrDefault(d => d.Username == username);

                if (newlogin != null) {
                    MessageBoxResult result = MessageBox.Show("Username already exists. Enter a new username.", "Error");
                }
                else {
                    db.Login.Add(d);
                    db.SaveChanges();
                    MessageBoxResult result = MessageBox.Show("Student succesfully Added", "Done");
                    viewModel.LoadLoginDetails();

                    MainWindow Window = new MainWindow();
                    //Application.Current.MainWindow = new LoginWindow();
                    Window.Show();
                    //this.Hide();
                }


            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Application.Current.Shutdown();
            this.Close();
        }

        private void Drag(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        /*
        public void Loadlogindetails()
        {
            using (var db = new DatabaseContext())
            {
                var list = db.Login.ToList();
                Login = new ObservableCollection<LoginDetails>(list);
            }
        }
        */
    }
}

