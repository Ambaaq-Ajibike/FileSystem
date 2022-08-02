using System;
using OOP.Models;
using OOP.Repositories;

namespace OOP
{
    class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("=====Welcome====");
            System.Console.WriteLine("Enter 1 to for student or 2 to for teacher");
            int num = int.Parse(Console.ReadLine());  
            if (num == 1)
            {
                StudentMenu();  
            } 
            else if (num == 2)
            {
                TeachersMenu();
            }
            else
            {
                
            }         
                      
        }
        public static void StudentMenu()
        {
            var check = true;
             StudentRepositories st = new StudentRepositories();
            while (check)
            {
                   
                    System.Console.WriteLine("Enter 1 to register student");
                    System.Console.WriteLine("Enter 2 to delete student");
                    System.Console.WriteLine("Enter 3 to update student");
                    System.Console.WriteLine("Enter 4 to get student");
                    int choice = int.Parse(Console.ReadLine());            
                    if (choice == 1)
                    {
                        st.RegisterStudent();
                    }
                    else if (choice == 2)
                    {
                        st.Delete();
                    }
                    else if(choice == 4)
                    {
                        st.GetAll();
                    }
                    else if (choice == 3)
                    {
                        st.UpdateStudent();
                    }
                    else 
                    {
                        break;
                    }
                  
                    
            }
        } 
        public static void TeachersMenu()
        {
            var check = true;
           TeacherRepositories teach = new TeacherRepositories();
            while (check)
            {
                    System.Console.WriteLine("Enter 1 to register teacher");
                    System.Console.WriteLine("Enter 2 to delete teacher");
                    System.Console.WriteLine("Enter 3 to update teacher");
                    System.Console.WriteLine("Enter 4 to get teacher");
                    int choice = int.Parse(Console.ReadLine());            
                    if (choice == 1)
                    {
                        teach.RegisterTeachers();
                    }
                    else if (choice == 2)
                    {
                        teach.Delete();
                    }
                    else if(choice == 4)
                    {
                        teach.GetAll();
                    }
                    else if (choice == 3)
                    {
                        teach.UpdateTeachers();
                    }
                    else 
                    {
                        break;
                    }
                  
                    
            }
        }  
    }
}