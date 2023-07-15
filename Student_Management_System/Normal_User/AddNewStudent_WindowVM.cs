using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Models;

namespace Student_Management_System.Normal_User {
    public partial class AddNewStudent_WindowVM : ObservableObject{

        [ObservableProperty] public int id;
        [ObservableProperty] public string firstname;
        [ObservableProperty] public string lastname;
        [ObservableProperty] public int age;
   
        [ObservableProperty] public string address;
        [ObservableProperty] public string dob;

        [ObservableProperty] public string selectedID;

        [ObservableProperty]
        ObservableCollection<Student> students;

        [RelayCommand]
        public void InsertStudent() {
            
            try {
                Student p = new Student() {
                    Id = Id,
                    FirstName = Firstname,
                    LastName = Lastname,
                    Address = Address,
                    Age = Age,
                    //Modules = new List<Module>(),
                    DoB = Dob,
                };
                using (var db = new DatabaseContext()) {
                    db.Students.Add(p);
                    db.SaveChanges();
                    LoadStudent();
                    MessageBoxResult result = MessageBox.Show("Student successfully Added", "Done");
                    Clear();
                }
            }
            catch (Exception ex) {
                MessageBoxResult result11 = MessageBox.Show("Check your data.", "Invalid");
                Clear();
            }

            
        }


        [RelayCommand]
        public void DeleteStudent() {
            try {
                int id = Id;
                if (id == 0) {
                    MessageBoxResult result1 = MessageBox.Show("You should enter the id of student", "Error");
                    return;
                }
                using (var db = new DatabaseContext()) {
                    Student s = db.Students.Find(id);
                    
                    db.Students.Remove(s);
                    db.SaveChanges();
                    LoadStudent();
                    MessageBoxResult result = MessageBox.Show("Student successfully Deleted", "Done");
                    Clear();
                }
            }
            catch (Exception ex) {
                MessageBoxResult result = MessageBox.Show("Invalid ID", "Error");
                Clear();
            }     

        }

        [RelayCommand ]
        public void Editstudent() {
            try {
                int id = Id;
                
                using (var db = new DatabaseContext()) {
                    Student s = db.Students.Find(id);
                    if (Firstname != null) {
                        s.FirstName = Firstname;
                    }
                    if (Lastname != null) {
                        s.LastName = Lastname;
                    }
                    if (Address != null) {
                        s.Address = Address;
                    }
                    if (Age != 0) {
                        s.Age = Age;
                    }
                    if (Dob != null)
                    {
                        s.DoB = Dob;
                    }

                    db.SaveChanges();
                    LoadStudent();
                    MessageBox.Show("Successfully edited", "Done");
                    Clear();
                }
                }
            catch {
                MessageBox.Show("Invalid Data", "Error");
                Clear();
            }
        }

        [RelayCommand]
        public void search() {
            try {
                using (var db = new DatabaseContext()) {



                    var searched = db.Students.Where(s => s.Id == id);
                    Students = new ObservableCollection<Student>(searched);

                }
            }
            catch {
                MessageBox.Show("No result found", "Failed");
            }

        }


        public void Clear()
        {
            Id = 0;
            SelectedID = "";
            Firstname = "";
            Lastname = "";
            Age = 0;
            Dob = "";
            Address = "";

        }

        [RelayCommand]
        public void Refresh() {
            LoadStudent();
            Clear();
        }


        public void LoadStudent() {
            using (var db = new DatabaseContext()) {
                var list = db.Students.ToList();
                Students = new ObservableCollection<Student>(list);
            }
        }

        public AddNewStudent_WindowVM() {
            LoadStudent();
        }

    }
}
