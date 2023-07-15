using Student_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Admin_User
{
    public partial class AddNewUserWindowVM
    {
        //[ObservableProperty] public string username;
        //[ObservableProperty] public string password;
        //[ObservableProperty] public string usertype;

        //[ObservableProperty]
        //ObservableCollection<LoginDetails> login;
        //[ObservableProperty]
        public List<LoginDetails> Login { get; set; }
        /*
        [RelayCommand]
        public void CreateUser()
        {
            try
            {
                LoginDetails d = new LoginDetails()
                {
                    //Password = PasswordBox.PasswordCharProperty;
                    
                    Username = username,
                    Password = password,
                    UserType = "Normal User"
                };
                using (var db = new DatabaseContext())
                {
                    db.Login.Add(d);
                    db.SaveChanges();
                    LoadLoginDetails();
                    MessageBoxResult result = MessageBox.Show("Student succesfully Added", "Done");
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result11 = MessageBox.Show("Invalid data", "Done");
            }
        }
        */
        public void LoadLoginDetails() {
            using (var db = new DatabaseContext()) {
                var list = db.Login.ToList();
                Login = new List<LoginDetails>(list);
            }
        }
    }
}
