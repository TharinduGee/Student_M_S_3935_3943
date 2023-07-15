using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Models {
    public class Student {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        //public List<Module> Modules { get; set; }
        //public DateOnly DoB { get; set; } = new DateOnly();

        public string DoB { get; set; } = string.Empty;
        public double GPA { get; set; } = 0;

    }
}
