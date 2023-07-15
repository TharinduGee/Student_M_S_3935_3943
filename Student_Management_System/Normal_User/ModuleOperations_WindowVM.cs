using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Student_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace Student_Management_System.Normal_User
{
    public partial class ModuleOperations_WindowVM : ObservableObject
    {
        [ObservableProperty] public int moduleiD;
        [ObservableProperty] public string code;
        [ObservableProperty] public string modulename;
        [ObservableProperty] public int credit;
       

        [ObservableProperty] public string selectedID;

        [ObservableProperty]
        ObservableCollection<Module> modules;

        [RelayCommand]
        public void InsertModule()
        {

            try
            {
                Module m = new Module()
                {
                    ModuleID = ModuleiD,
                    Code = Code,
                    ModuleName = Modulename,
                    Credit = Credit
                    
                };
                using (var db = new DatabaseContext())
                {
                    db.Modules.Add(m);
                    db.SaveChanges();
                    LoadModule();
                    Clear();
                    MessageBoxResult result = MessageBox.Show("Module successfully Added", "Done");
                }
            }
            catch (Exception ex)
            {
                Clear();
                MessageBoxResult result11 = MessageBox.Show("Invalid data", "Error");
            }


        }

        public void Clear()
        {
            ModuleiD = 0;
            Modulename = "";
            Credit = 0;
            Code = "";
        }

        [RelayCommand]
        public void DeleteModule()
        {
            try
            {
                int moduleiD = ModuleiD;
                if (moduleiD == 0)
                {
                    MessageBoxResult result1 = MessageBox.Show("You should enter the Module ID of module");
                    return;
                }
                using (var db = new DatabaseContext())
                {
                    Module m = db.Modules.Find(moduleiD);

                    db.Modules.Remove(m);
                    db.SaveChanges();
                    LoadModule();
                    MessageBoxResult result = MessageBox.Show("Module successfully Deleted", "Done");
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show("Invalid Module ID", "Done");
            }

        }

        [RelayCommand]
        public void EditModule()
        {
            try
            {
                int moduleiD = ModuleiD;

                using (var db = new DatabaseContext())
                {
                    Module m = db.Modules.Find(moduleiD);
                    if (ModuleiD != 0)
                    {
                        m.ModuleID = ModuleiD;
                    }
                    if (Code != null)
                    {
                        m.Code = Code;
                    }
                    if (Modulename != null)
                    {
                        m.ModuleName = Modulename;
                    }
                    if (Credit != null)
                    {
                        m.Credit = Credit;
                    }
                    

                    db.SaveChanges();
                    LoadModule();
                    Clear();
                    MessageBox.Show("Successfully edited.", "Done");
                }
            }
            catch
            {
                Clear();
                MessageBox.Show("Invalid Data", "Error");
            }
        }
        [RelayCommand]
        public void Search() {
            try {
                using (var db = new DatabaseContext()) {



                    var searched = db.Modules.Where(s => s.ModuleID == ModuleiD );
                    Modules = new ObservableCollection<Module>(searched);

                }
            }
            catch {
                MessageBox.Show("No result found", "Error");
            }

        }

        [RelayCommand]
        public void Refresh() {
            LoadModule();
            SelectedID = "";
            Clear();
        }


        public void LoadModule()
        {
            using (var db = new DatabaseContext())
            {
                var list = db.Modules.ToList();
                Modules = new ObservableCollection<Module>(list);
            }
        }

        public ModuleOperations_WindowVM()
        {
            LoadModule();
        }
    }
}
