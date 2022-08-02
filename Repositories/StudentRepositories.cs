using System;
using OOP.Models;
using System.IO;
namespace OOP.Repositories
{
    public class StudentRepositories
    {
        List<Student> students = new List<Student>();
        string file = "C:\\Users\\ADMIN\\Desktop\\File\\Files\\studentFile.txt";
        public StudentRepositories()                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
        {
            ReadStudentFromFile();
        }
        private void ReadStudentFromFile()
        {
            try
            {
                if(File.Exists(file))
                {
                // var allStudent = File.ReadAllLines("Files/studentfile.txt");
                 var allStudents = File.ReadAllLines(file);
                 foreach (var s in allStudents)
                 {
                    students.Add(Student.ToStudent(s));
                 }

                }
                else
                {
                    string path = "C:\\Users\\ADMIN\\Desktop\\File\\Files";
                    Directory.CreateDirectory(path);
                    string filename = "studentFile.txt";
                    string fullpath = Path.Combine(path, filename);
                    File.Create(fullpath);
                }
            }
            catch (System.Exception ex)
            {
                 System.Console.WriteLine(ex.Message);
            }
            
        }    
        public Student RegisterStudent()
        {
            System.Console.WriteLine("Enter id");
            var id = int.Parse(Console.ReadLine());            
            System.Console.WriteLine("Enter student first name");
            var firstname = Console.ReadLine();            
            System.Console.WriteLine("Enter student last name");
            var lastname = Console.ReadLine();            
            System.Console.WriteLine("Enter student age");
            var age = int.Parse(Console.ReadLine());  
            System.Console.WriteLine("Enter the address");
            var address = Console.ReadLine();                      
            System.Console.WriteLine("Enter student phonenumber");
            var phonenumber = Console.ReadLine();
            System.Console.WriteLine("enter email");            
            var email = Console.ReadLine(); 
            var student = new Student(id, firstname, lastname, age, address, phonenumber, email); 
            students.Add(student);
            AddStudentToFile(student);
            return student;          
        }
        private void PrintStudent(Student student)
        {
            System.Console.WriteLine(student.ToString());
        }
        public void UpdateStudent()
        {
            System.Console.WriteLine("Enter the id of the student to update");
            var id = int.Parse(Console.ReadLine());
            var student = GetStudentById(id);
            if (student != null)
            {
                System.Console.WriteLine("Enter student first name");
                var firstname = Console.ReadLine();            
                System.Console.WriteLine("Enter student last name");
                var lastname = Console.ReadLine();            
                System.Console.WriteLine("Enter student age");
                var age = int.Parse(Console.ReadLine());    
                student.FirstName = firstname;
                student.LastName = lastname;
                student.Age = age;
                 RefreshFile();
                 System.Console.WriteLine($"Student with id: {id} is updated successfully.");
            }
            else
            {
                System.Console.WriteLine($"Student with this id {id} is not found");
            }      
        }
        public void Delete()
        {
            System.Console.WriteLine("Enter the id of the student to delete");
            var id = int.Parse(Console.ReadLine());
            var student = GetStudentById(id);
            if (student != null)
            {
                students.Remove(student);
                 RefreshFile();
                 System.Console.WriteLine($"Student with id: {id} is deleted successfully.");
            } 
            else
            {
                System.Console.WriteLine($"Student with this id {id} is not found");
            }              
        }
        public Student GetStudentById(int id)
        {
            foreach (var student in students)
            {
                if(student.ID == id)
                {
                    return student;
                }
            }
            return null;
        }
        private void AddStudentToFile(Student student)
        {
            try
            {
                using(StreamWriter write = new StreamWriter(file, true))
                {
                    write.WriteLine(student.ToString());
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
             using(StreamWriter write = new StreamWriter(file))
             {
                foreach (var student in students)
                {
                    write.WriteLine(student.ToString());
                }                
             }
            }
            catch (System.Exception ex)
            {
                 System.Console.WriteLine(ex.Message);
            }
            
        }
        public void GetAll()
        {
            if(students.Count == 0)
            {
                System.Console.WriteLine("no student registered");
            }
            else
            {
                foreach (var student in students)
                {
                    PrintStudent(student);
                }
            }
        }
        
    }
}