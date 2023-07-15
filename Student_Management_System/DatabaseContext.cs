using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Management_System.Models;

namespace Student_Management_System {
    public class DatabaseContext : DbContext{

        //path of the database
        private readonly string _path = @"C:\Users\Tharindu\Downloads\Student_Management_System\Student_Management_System\Student_Management_System\Temp\Student.db";

        //override the onconfig method
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlite($"Data source = {_path}");

        public DbSet<Student> Students { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<LoginDetails> Login { get; set; }

        public DbSet<Result> Results { get; set; }
    }
}

//Add-Migration Migration_name
//Update-Database