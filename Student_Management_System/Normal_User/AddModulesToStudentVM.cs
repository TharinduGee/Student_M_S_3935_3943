using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Student_Management_System.Models;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D.Converters;

namespace Student_Management_System.Normal_User
{
    public partial class AddModulesToStudentVM : ObservableObject {

       

        [ObservableProperty]
        public int  selectedId;

        [ObservableProperty]
        public int selectedModuleId;

        [ObservableProperty]
        public string firstName;


        [ObservableProperty]
        public Module selection;

   

        [ObservableProperty]
        ObservableCollection<int> comboId;

        [ObservableProperty]
        ObservableCollection<Result> selectedModules;

        [RelayCommand]
        public void GetSelectedStudent()
        {
            try
            {
                using (var db = new DatabaseContext())
                {



                    Student searched = db.Students.Find(SelectedId);
                    if (searched == null)
                    {
                        MessageBox.Show("There is no student by that ID", "Error");
                        return;
                    }

                    FirstName = searched.FirstName.ToString();
                    //var selected_list = searched.Modules.ToList();
                    //SelectedModules = new ObservableCollection<Module>(selected_list);
                    LoadSelectedModules(SelectedId);

                }
            }
            catch
            {
                MessageBox.Show("No result found", "No");
            }

        }


        [RelayCommand]
        public void SelectModule()
        {
            try
            {
                using (var db = new DatabaseContext())
                {



                    Module searched = db.Modules.Find(SelectedModuleId);
                    if (searched == null)
                    {
                        MessageBox.Show("Invalid Module ID", "Error");
                        return;
                    }
                    //MessageBox.Show("You have selected a module");


                }

                Result r = new Result()
                {
                    StudentId = SelectedId,
                    ModuleID = SelectedModuleId,
                    Grade = 0
                };
                using (var db = new DatabaseContext())
                {
                    db.Results.Add(r);
                    db.SaveChanges();
                    MessageBoxResult result = MessageBox.Show("Module succesfully Added to student", "Done");
                    LoadSelectedModules(SelectedId);
                }
            }
            catch
            {
                MessageBox.Show("Error", "No");
            }

        }





        [RelayCommand]
        public void LoadSelectedModules(int selectedid)
        {
            using (var db = new DatabaseContext())
            {
                //var list = db.Modules.ToList();
                var list = db.Results.Where(R => R.StudentId == selectedid).ToList();
                SelectedModules = new ObservableCollection<Result>(list);
            }
        }




    



        public AddModulesToStudentVM() {
            
           
        }




    }
}
