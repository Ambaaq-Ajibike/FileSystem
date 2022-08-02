using System;
using OOP.Models;
using System.IO;
namespace OOP.Repositories
{
    public class TeacherRepositories
    {
        List<Teacher> teachers = new List<Teacher>();
        string Teachersfile = "C:\\Users\\ADMIN\\Desktop\\File\\Files\\teacherFile.txt";
        public TeacherRepositories()
        {
            ReadTeachersFromFile();
        }
        private void ReadTeachersFromFile()
        {
            try
            {
                 if(File.Exists(Teachersfile))
                 {
                    var allteachers = File.ReadAllLines(Teachersfile);
                    foreach (var t in allteachers)
                    {
                    teachers.Add(Teacher.ToTeacher(t));
                    }
                }
                else
                {
                    string path = "C:\\Users\\ADMIN\\Desktop\\File\\Files";
                    Directory.CreateDirectory(path);
                    string filename = "teacherFile.txt";
                    string fullpath = Path.Combine(path, filename);
                    File.Create(fullpath);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            
        }
        public Teacher RegisterTeachers()
        {
            System.Console.WriteLine("Enter first name");
            var _firstname = Console.ReadLine();
            System.Console.WriteLine("Enter last name");
            var _lastname = Console.ReadLine();
            System.Console.WriteLine("Enter phone number");
            var _phonenumber = Console.ReadLine();
            System.Console.WriteLine("Enter Email");
            var _email = Console.ReadLine();
            System.Console.WriteLine("Enter teacher ID");
            var _id = int.Parse(Console.ReadLine());
            var teacher = new Teacher(_firstname, _lastname, _phonenumber, _email, _id);
            teachers.Add(teacher);
            AddTeacherToFile(teacher);
            return teacher;
        }
        public void PrintTeachers(Teacher teacher)
        {
            System.Console.WriteLine(teacher.ToString());
        }
        public void UpdateTeachers()
        {
            System.Console.WriteLine("Enter the ID of student you want to update");
            var Id = int.Parse(Console.ReadLine());
            var teacher = GetTeacherByID(Id);
            if (teacher != null)
            {
                 System.Console.WriteLine("Enter student first name");
                var _firstname = Console.ReadLine();            
                System.Console.WriteLine("Enter student last name");
                var _lastname = Console.ReadLine();            
                System.Console.WriteLine("Enter student age");
                var _age = int.Parse(Console.ReadLine());    
                teacher._FirstName = _firstname;
                teacher._LastName = _lastname;
                 RefreshFile();
                 System.Console.WriteLine($"Teacher with id: {Id} is updated successfully.");
            }
            else
            {
                 System.Console.WriteLine($"Teacher with id: {Id} is not found.");
            }          
        }
        private void AddTeacherToFile(Teacher teacher)
        {
            try
            {
                using(StreamWriter write = new StreamWriter(Teachersfile))
                {
                    write.WriteLine(teacher.ToString());
                }
            }
            catch (System.Exception ex)
            {
                 System.Console.WriteLine(ex.Message);
            }
            
        }
        private void RefreshFile()
        {
            try
            {
                foreach (var teacher in teachers)
                {
                    using(StreamWriter write = new StreamWriter(Teachersfile))
                 {
                    write.WriteLine(teacher.ToString());
                 }
                }
            }
            catch (System.Exception ex)
            {
                 System.Console.WriteLine(ex.Message);
            }
           
        }
        public Teacher GetTeacherByID(int Id)
        {
            foreach (var teacher in teachers)
            {
                if(teacher._ID == Id)
                {
                    return teacher;
                } 
            }
            return null;
        }
        public void GetAll()
        {
            if(teachers.Count == 0)
            {
               System.Console.WriteLine("No is registered yet"); 
            }
            else
            {
                foreach (var teacher in teachers)
                {
                    PrintTeachers(teacher);
                }
            }
        }
        public void Delete()
        {
            System.Console.WriteLine("Enter the ID of student you want to delete");
            var id = int.Parse(Console.ReadLine());
            var teacher = GetTeacherByID(id);
            if(teacher != null)
            {
                teachers.Remove(teacher);
                RefreshFile();
                 System.Console.WriteLine($"Teacher with id: {id} was deleted successfully.");
            }
            else
            {
                System.Console.WriteLine($"Teacher with id: {id} is not found.");                
            }
        }
    }
}