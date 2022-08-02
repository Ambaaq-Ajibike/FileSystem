using System;


namespace OOP.Models
{
    public class Teacher
    {
        public string _FirstName{get; set;}
        public string _LastName{get; set;}
        public string _PhoneNumber{get; set;}
        public string _Email{get; set;}
        public int _ID{get; set;}
        public Teacher(string _firstname, string _lastname, string _phonenumber,string _email, int _id)
        {
            _FirstName = _firstname;
            _LastName = _lastname;
           _PhoneNumber = _phonenumber;
            _Email = _email;
            _ID = _id;
        }
        public override string ToString()
        {
            return $"First Name: {_FirstName}\tLast Name: { _LastName}\t Email: { _Email}\t ID: {_ID}";
        }
        public static Teacher ToTeacher(string teacher)
        {
            var teachert = teacher.Split("\t");
            var _firstname = teachert[0];
            var _lastname = teachert[1];
            var _phonenumber = teachert[2];
            var _email = teachert[3];
            var _id = int.Parse(teachert[4]);
            return new Teacher(_firstname, _lastname, _phonenumber, _email, _id);
        }
    }
}