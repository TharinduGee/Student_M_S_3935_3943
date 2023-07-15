using FluentAssertions.Equivalency;
using Student_Management_System;
using FluentAssertions;
using System.Windows;

namespace Student_Management_System.Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestClearFunction()
        {

            Student_Management_System.Normal_User.AddNewStudent_WindowVM m = new  Student_Management_System.Normal_User.AddNewStudent_WindowVM();
            m.Clear();
            m.Address.Should().Be("");
            m.Age.Should().Be(0);
            m.Dob.Should().Be(null);
            m.Id.Should().Be(0);
            m.Firstname.Should().Be("");
            m.Lastname.Should().Be("");
           
        }


        [Fact]
        public void insertExceptionTest()
        {
            Student_Management_System.Normal_User.AddNewStudent_WindowVM m = new Normal_User.AddNewStudent_WindowVM();
            m.Firstname = "test";
            m.Lastname = "test";
            m.Id = 90;
            m.Dob = "2000";
            m.Age = 23;
            m.Address = "dfsfs";

       
            
            var ex  = Record.Exception(() => m.InsertStudent());
            ex.Message.Should().Be("");           
            //Assert.True(ex.Message.Equals(""));

        }
    }
}