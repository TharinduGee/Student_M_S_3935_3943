using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Student_Management_System.Normal_User
{
    public partial class Add_GradesVM : ObservableObject
    {

        [ObservableProperty]
        public int studentId;

        [ObservableProperty]
        public int moduleId;


        [ObservableProperty]
        ObservableCollection<Result> studentResults;



        [RelayCommand]
        public void SelectStudent()
        {
            try
            {
                using (var db = new DatabaseContext())
                {


                    Student searched = db.Students.Find(StudentId);
                    if (searched == null)
                    {
                        MessageBox.Show("There is no student by that ID");
                        return;
                    }

                    
                    LoadSelectedModules(StudentId);

                }
            }
            catch
            {
                MessageBox.Show("No result found", "No");
               
            }
        }

        [RelayCommand]
        public void Save()
        {
            
            
            try
            {
                
                foreach(var r in StudentResults)
                {
                    using (var db = new DatabaseContext())
                    {
                        Result s = db.Results.Find(r.Id);
                        if (s == null)
                        {
                            MessageBox.Show("Error: Please Refresh the table and enter again");
                            //isOk = false;
                            return;
                        }
                        s.Grade = r.Grade;
                        db.SaveChanges();
                        

                    }
                    

                }
                
                MessageBox.Show("Grades saved.");
                
                
            }
            catch {
                MessageBox.Show("Unhandled Exception", "Error");
            }

            double tot = 0;
            double tot_cred = 0;
            try
            {
                foreach (var r in studentResults)
                {
                    using (var db = new DatabaseContext())
                    {
                        Module m = db.Modules.Find(r.ModuleID);
                        int cred = m.Credit;
                        tot_cred += cred;
                        tot += cred * r.Grade;
                    }
                }

                using (var db = new DatabaseContext())
                {
                    Student s = db.Students.Find(StudentId);
                    s.GPA = tot / tot_cred;
                    db.SaveChanges();
                }

                MessageBox.Show("GPA calculated", "Successful");


            }
            catch
            {
                MessageBox.Show("Unhandled Exception");
            }


        }

        public void LoadSelectedModules(int id)
        {
            using (var db = new DatabaseContext())
            {
                //var list = db.Modules.ToList();
                var list = db.Results.Where(R => R.StudentId == id).ToList();
                StudentResults = new ObservableCollection<Result>(list);
            }
        }

    }
}
