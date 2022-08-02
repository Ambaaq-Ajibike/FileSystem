using System;
namespace OOP.Models
{
    public class Student
    {
        public int ID{get; set;}
        public string FirstName{get; set;}
        public string LastName{get; set;}
        public int Age{get; set;}
        public string Address{get; set;}
        public string PhoneNumber{get; set;}
        public string Email{get; set;}
        public string Password{get; set;}
        public string HashSalt{get; set;}
        public int DepartmentID{get; set;}    
        public Student(int id, string firstname, string lastname, int age, string address, string phonenumber, string email)
        {
            ID = id;
            FirstName = firstname;
            LastName = lastname;
            Age = age;
            Address = address;
            PhoneNumber = phonenumber;
            Email = email;
        }
        public override string ToString()
        {
            return $"{ID}\t{FirstName}\t{LastName}\t{Age}\t{Address}\t{PhoneNumber}\t{Email}";
        }
        public static Student ToStudent(string student)
        {
            var studentStr = student.Split("\t");
            int id = int.Parse(studentStr[0]);
            var firstname = studentStr[1];
            var lastname = studentStr[2];
            var age = int.Parse(studentStr[3]);
            var address = studentStr[4];
            var phonenumber = studentStr[5];
            var email = studentStr[6];
            return new Student(id, firstname, lastname, age, address, phonenumber, email); 

        }
    }
}